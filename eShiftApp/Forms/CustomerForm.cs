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
    public partial class CustomerForm : Form
    {
        private int? _customerId = null; // null = Add, otherwise Edit
        public bool IsSaved = false;     // Used to refresh parent table
        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customers WHERE CustomerID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _customerId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtFullName.Text = reader["FullName"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    string fullPhone = reader["Phone"].ToString();

                    // Attempt to split country code and phone
                    if (fullPhone.StartsWith("+"))
                    {
                        var parts = Regex.Match(fullPhone, @"^(\+\d+)(\d+)$");
                        if (parts.Success)
                        {
                            cmbCountryCode.Text = parts.Groups[1].Value;
                            txtPhone.Text = parts.Groups[2].Value;
                        }
                        else
                        {
                            txtPhone.Text = fullPhone;
                        }
                    }
                    else
                    {
                        txtPhone.Text = fullPhone;
                    }

                    txtEmail.Text = reader["Email"].ToString();
                    txtPassword.Text = reader["Password"].ToString();
                }
            }
        }

        private string GetPasswordStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return "";

            int score = 0;

            if (password.Length >= 6) score++;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[a-z]")) score++;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Z]")) score++;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[0-9]")) score++;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, @"[\W_]")) score++;

            switch (score)
            {
                case 0:
                case 1:
                case 2:
                    return "Weak";
                case 3:
                    return "Medium";
                case 4:
                    return "Strong";
                case 5:
                    return "Very Strong";
                default:
                    return "";
            }
        }

        private Color GetStrengthColor(string strength)
        {
            switch (strength)
            {
                case "Weak":
                    return Color.Red;
                case "Medium":
                    return Color.Orange;
                case "Strong":
                    return Color.Green;
                case "Very Strong":
                    return Color.DarkGreen;
                default:
                    return Color.Black;
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';
            txtConfirmPassword.PasswordChar = '•';

            cmbCountryCode.Items.AddRange(new object[] { "+94", "+1", "+44", "+91", "+61" });
            cmbCountryCode.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Basic field validation
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Phone number validation
            if (!Regex.IsMatch(txtPhone.Text, @"^\d{7,15}$"))
            {
                MessageBox.Show("Phone number should contain only digits and be 7–15 digits long.", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Password match check
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Password strength check
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullPhone = cmbCountryCode.Text + txtPhone.Text;

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                // 5. Check for email duplication (only during Add)
                if (_customerId == null)
                {
                    SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE Email = @email", conn);
                    checkEmail.Parameters.AddWithValue("@email", txtEmail.Text);
                    if ((int)checkEmail.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Email already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 6. Prepare insert/update query
                SqlCommand cmd;
                if (_customerId == null)
                {
                    // Add mode
                    cmd = new SqlCommand("INSERT INTO Customers (FullName, Address, Phone, Email, Password) VALUES (@n, @a, @p, @e, @pw)", conn);
                }
                else
                {
                    // Edit mode
                    cmd = new SqlCommand("UPDATE Customers SET FullName=@n, Address=@a, Phone=@p, Email=@e, Password=@pw WHERE CustomerID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", _customerId);
                }

                // 7. Add parameters
                cmd.Parameters.AddWithValue("@n", txtFullName.Text);
                cmd.Parameters.AddWithValue("@a", txtAddress.Text);
                cmd.Parameters.AddWithValue("@p", fullPhone);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@pw", txtPassword.Text);

                // 8. Execute
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                IsSaved = true;
                this.Close();
            }
        }


        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // No masking
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';  // Mask with bullet
                txtConfirmPassword.PasswordChar = '•';
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblPasswordStrength.Text = GetPasswordStrength(txtPassword.Text);
            lblPasswordStrength.ForeColor = GetStrengthColor(lblPasswordStrength.Text);
        }
    }
}
