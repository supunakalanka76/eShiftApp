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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtUsername.GotFocus += RemoveUsernamePlaceholder;
            txtUsername.LostFocus += SetUsernamePlaceholder;

            txtPassword.GotFocus += RemovePasswordPlaceholder;
            txtPassword.LostFocus += SetPasswordPlaceholder;
        }

        private void SetUsernamePlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Enter your email";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void RemoveUsernamePlaceholder(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter your email")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }
        private void SetPasswordPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Enter your password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void RemovePasswordPlaceholder(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter your password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                // Admins now log in using Email (not username)
                string query = "SELECT * FROM Admins WHERE Username = @u AND Password = @pw";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@pw", txtPassword.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader["FullName"].ToString();
                    MessageBox.Show($"Welcome Admin, {name}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var dashboard = new AdminDashboardForm();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Admin credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCustomerLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customers WHERE Email = @u AND Password = @p";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int customerId = Convert.ToInt32(reader["CustomerID"]);
                    string name = reader["FullName"].ToString();

                    MessageBox.Show("Customer Login Successful");
                    var dashboard = new CustomerDashboardForm(customerId);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Customer credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '•';
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Email placeholder
            txtUsername.Text = "Enter your email";
            txtUsername.ForeColor = Color.Gray;

            // Password placeholder
            txtPassword.Text = "Enter your password";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false; // Show text, not •

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }
}
