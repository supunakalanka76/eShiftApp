using eShiftApp.Database;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace eShiftApp.Forms
{
    public partial class JobRequestForm : Form
    {
        private int _customerId;
        private DataTable productTable = new DataTable();

        public JobRequestForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

            dgvAvailableProducts.CellClick += dgvAvailableProducts_CellClick;
            dgvAvailableProducts.CellValueChanged += dgvAvailableProducts_CellValueChanged;
            dgvAvailableProducts.CurrentCellDirtyStateChanged += dgvAvailableProducts_CurrentCellDirtyStateChanged;
        }

        private void JobRequestForm_Load(object sender, EventArgs e)
        {
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

                dgvAvailableProducts.DataSource = productTable;

                dgvAvailableProducts.Columns["ProductName"].HeaderText = "Product Name";
                dgvAvailableProducts.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvAvailableProducts.Columns["Category"].HeaderText = "Category";
                dgvAvailableProducts.Columns["Category"].Width = 120;

                dgvAvailableProducts.Columns["Price"].HeaderText = "Price (Rs.)";
                dgvAvailableProducts.Columns["Price"].Width = 90;

                dgvAvailableProducts.Columns["Available"].HeaderText = "Available";
                dgvAvailableProducts.Columns["Available"].Width = 120;


                if (!dgvAvailableProducts.Columns.Contains("Select"))
                {
                    DataGridViewCheckBoxColumn selectCol = new DataGridViewCheckBoxColumn
                    {
                        HeaderText = "Select",
                        Name = "Select"
                    };
                    dgvAvailableProducts.Columns.Insert(0, selectCol);
                }

                if (!dgvAvailableProducts.Columns.Contains("Quantity"))
                {
                    DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Qty",
                        Name = "Quantity",
                        ReadOnly = true,
                        Width = 10
                    };
                    dgvAvailableProducts.Columns.Add(qtyCol);
                }

                if (!dgvAvailableProducts.Columns.Contains("Minus"))
                {
                    DataGridViewButtonColumn minusCol = new DataGridViewButtonColumn
                    {
                        HeaderText = "Remove",
                        Name = "Minus",
                        Text = "-",
                        UseColumnTextForButtonValue = true,
                        Width = 10
                    };
                    dgvAvailableProducts.Columns.Add(minusCol);
                }

                if (!dgvAvailableProducts.Columns.Contains("Plus"))
                {
                    DataGridViewButtonColumn plusCol = new DataGridViewButtonColumn
                    {
                        HeaderText = "Add",
                        Name = "Plus",
                        Text = "+",
                        UseColumnTextForButtonValue = true,
                        Width = 20
                    };
                    dgvAvailableProducts.Columns.Add(plusCol);
                }

                dgvAvailableProducts.Columns["ProductID"].Visible = false;

                foreach (DataGridViewRow row in dgvAvailableProducts.Rows)
                {
                    row.Cells["Quantity"].Value = "0";
                    row.Cells["Select"].Value = false;
                }
            }
        }

        // When checkbox state changes
        private void dgvAvailableProducts_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAvailableProducts.IsCurrentCellDirty)
                dgvAvailableProducts.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvAvailableProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAvailableProducts.Columns.Contains("Select") &&
                e.ColumnIndex == dgvAvailableProducts.Columns["Select"].Index &&
                e.RowIndex >= 0)
            {
                var row = dgvAvailableProducts.Rows[e.RowIndex];

                bool isChecked = Convert.ToBoolean(row.Cells["Select"].Value ?? false);

                // Safely check if Quantity column exists and update
                if (isChecked && dgvAvailableProducts.Columns.Contains("Quantity"))
                {
                    int qty = 0;
                    int.TryParse(row.Cells["Quantity"].Value?.ToString(), out qty);
                    if (qty == 0)
                    {
                        row.Cells["Quantity"].Value = 1;
                    }
                }

                HighlightRowStockStatus(row);
            }
        }


        private void dgvAvailableProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvAvailableProducts.Rows[e.RowIndex];
            int qty = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
            int available = Convert.ToInt32(row.Cells["Available"].Value);

            string colName = dgvAvailableProducts.Columns[e.ColumnIndex].Name;

            if (colName == "Plus" && qty < available)
            {
                qty++;
                row.Cells["Quantity"].Value = qty;
                row.Cells["Select"].Value = qty > 0;
            }
            else if (colName == "Minus" && qty > 0)
            {
                qty--;
                row.Cells["Quantity"].Value = qty;
                row.Cells["Select"].Value = qty > 0;
            }

            HighlightRowStockStatus(row);
        }

        private void HighlightRowStockStatus(DataGridViewRow row)
        {
            int qty = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
            int available = Convert.ToInt32(row.Cells["Available"].Value);

            if (qty > available)
                row.DefaultCellStyle.BackColor = Color.LightCoral;
            else
                row.DefaultCellStyle.BackColor = Color.White;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStart.Text) || string.IsNullOrWhiteSpace(txtEnd.Text))
            {
                MessageBox.Show("Start and End location are required.");
                return;
            }

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Jobs (CustomerID, StartLocation, EndLocation, JobDate, Status, Description) " +
                                                "OUTPUT INSERTED.JobID " +
                                                "VALUES (@cust, @start, @end, @date, 'Pending', @desc)", conn);
                cmd.Parameters.AddWithValue("@cust", _customerId);
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);
                cmd.Parameters.AddWithValue("@date", dtpJobDate.Value);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                int jobId = (int)cmd.ExecuteScalar();

                foreach (DataGridViewRow row in dgvAvailableProducts.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value ?? false);
                    if (!isSelected) continue;

                    int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int qty = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                    int available = Convert.ToInt32(row.Cells["Available"].Value);

                    if (qty <= 0 || qty > available)
                    {
                        MessageBox.Show($"Invalid quantity for {row.Cells["ProductName"].Value}.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    SqlCommand insertCmd = new SqlCommand("INSERT INTO JobProducts (JobID, ProductID, Quantity) VALUES (@j, @p, @q)", conn);
                    insertCmd.Parameters.AddWithValue("@j", jobId);
                    insertCmd.Parameters.AddWithValue("@p", productId);
                    insertCmd.Parameters.AddWithValue("@q", qty);
                    insertCmd.ExecuteNonQuery();

                    SqlCommand updateCmd = new SqlCommand("UPDATE Products SET Quantity = Quantity - @q WHERE ProductID = @p", conn);
                    updateCmd.Parameters.AddWithValue("@q", qty);
                    updateCmd.Parameters.AddWithValue("@p", productId);
                    updateCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Job request submitted successfully with products.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
