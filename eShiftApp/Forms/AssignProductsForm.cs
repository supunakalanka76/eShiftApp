using eShiftApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShiftApp.Forms
{
    public partial class AssignProductsForm : Form
    {
        private int _jobId;
        private DataTable productTable = new DataTable();
        public AssignProductsForm(int jobId)
        {
            InitializeComponent();
            _jobId = jobId;
        }

        private void AssignProductsForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"Assign Products for Job #{_jobId}";
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT ProductID, ProductName, Category, Price, Quantity AS Available FROM Products", conn);
                productTable.Clear();
                adapter.Fill(productTable);
                dgvProducts.DataSource = productTable;

                dgvProducts.Columns["ProductName"].HeaderText = "Product Name";
                dgvProducts.Columns["Category"].HeaderText = "Category";
                dgvProducts.Columns["Price"].HeaderText = "Price (Rs.)";
                dgvProducts.Columns["Available"].HeaderText = "Available";

                if (!dgvProducts.Columns.Contains("Select"))
                {
                    DataGridViewCheckBoxColumn selectCol = new DataGridViewCheckBoxColumn
                    {
                        HeaderText = "Select",
                        Name = "Select"
                    };
                    dgvProducts.Columns.Insert(0, selectCol);
                }

                if (!dgvProducts.Columns.Contains("Quantity"))
                {
                    DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Qty",
                        Name = "Quantity"
                    };
                    dgvProducts.Columns.Add(qtyCol);
                }

                dgvProducts.Columns["ProductID"].Visible = false;

                // Default values
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    row.Cells["Select"].Value = false;
                    row.Cells["Quantity"].Value = "0";
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value ?? false);
                    if (!isSelected) continue;

                    int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                    int available = Convert.ToInt32(row.Cells["Available"].Value);

                    if (qty <= 0 || qty > available)
                    {
                        MessageBox.Show($"Invalid quantity for {row.Cells["ProductName"].Value}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    // Insert into JobProducts
                    SqlCommand insertCmd = new SqlCommand("INSERT INTO JobProducts (JobID, ProductID, Quantity) VALUES (@j, @p, @q)", conn);
                    insertCmd.Parameters.AddWithValue("@j", _jobId);
                    insertCmd.Parameters.AddWithValue("@p", productId);
                    insertCmd.Parameters.AddWithValue("@q", qty);
                    insertCmd.ExecuteNonQuery();

                    // Reduce product quantity
                    SqlCommand updateCmd = new SqlCommand("UPDATE Products SET Quantity = Quantity - @q WHERE ProductID = @p", conn);
                    updateCmd.Parameters.AddWithValue("@q", qty);
                    updateCmd.Parameters.AddWithValue("@p", productId);
                    updateCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Products assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
