using eShiftApp.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShiftApp.Forms
{
    public partial class CustomerProfileForm : Form
    {
        private int _customerId;

        public CustomerProfileForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

            cmbCountryCode.Items.AddRange(new object[] { "+94", "+1", "+44", "+91", "+61" });
            cmbCountryCode.SelectedIndex = 0;
        }

        private void CustomerProfileForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CustomerID = @id", conn);
                cmd.Parameters.AddWithValue("@id", _customerId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFullName.Text = reader["FullName"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtPassword.Text = reader["Password"].ToString();

                    string fullPhone = reader["Phone"].ToString();

                    if (!string.IsNullOrWhiteSpace(fullPhone) && fullPhone.StartsWith("+"))
                    {
                        // Split into country code and number
                        string code = fullPhone.Substring(0, 3); // e.g. +94
                        string local = fullPhone.Substring(3);  // rest
                        cmbCountryCode.SelectedItem = code;
                        txtPhone.Text = local;
                    }
                    else
                    {
                        txtPhone.Text = fullPhone;
                    }
                }
            }
        }


        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // No masking
            }
            else
            {
                txtPassword.PasswordChar = '•';  // Mask with bullet
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            string countryCode = cmbCountryCode.Text.Trim();
            string fullPhone = countryCode + phone;

            if (!Regex.IsMatch(phone, @"^\d{7,15}$"))
            {
                MessageBox.Show("Phone number must be 7–15 digits long (numbers only).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Customers SET FullName=@name, Address=@addr, Phone=@phone, Email=@email, Password=@pass WHERE CustomerID=@id", conn);
                cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text);
                cmd.Parameters.AddWithValue("@phone", fullPhone);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@id", _customerId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
