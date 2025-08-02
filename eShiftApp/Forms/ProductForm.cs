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
    public partial class ProductForm : Form
    {
        private int productId = -1;
        public bool IsSaved { get; private set; } = false;
        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(int id) : this()
        {
            productId = id;
            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductID=@id", conn);
                cmd.Parameters.AddWithValue("@id", productId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtProductName.Text = reader["ProductName"].ToString();
                    txtProductDesc.Text = reader["Description"].ToString();
                    txtProductPrice.Text = reader["Price"].ToString();
                    txtProductCategory.Text = reader["Category"].ToString();
                    txtProductQuantity.Text = reader["Quantity"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtProductName.Text.Trim();
            string description = txtProductDesc.Text.Trim();
            string priceText = txtProductPrice.Text.Trim();
            string category = txtProductCategory.Text.Trim();
            string quantityText = txtProductQuantity.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Please fill in all required fields (Name, Price, Description, Category, Quantity).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Invalid price value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(quantityText, out decimal quantity))
            {
                MessageBox.Show("Invalid quantity value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd;

                if (productId == -1)
                {
                    // Insert
                    cmd = new SqlCommand("INSERT INTO Products (ProductName, Description, Price, Category, Quantity) VALUES (@n, @d, @p, @c, @q)", conn);
                }
                else
                {
                    // Update
                    cmd = new SqlCommand("UPDATE Products SET ProductName=@n, Description=@d, Price=@p, Category=@c, Quantity=@q WHERE ProductID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", productId);
                }

                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@d", description);
                cmd.Parameters.AddWithValue("@p", price);
                cmd.Parameters.AddWithValue("@c", category);
                cmd.Parameters.AddWithValue("@q", quantity);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsSaved = true;
            this.Close();
        }
    }
}
