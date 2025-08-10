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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            //txtAdminPassword.TextChanged += txtAdminPassword_TextChanged;
            txtCustPassword.TextChanged += txtCustPassword_TextChanged;

            // Customer fields
            txtCustName.KeyDown += InputField_KeyDown;
            txtCustAddress.KeyDown += InputField_KeyDown;
            txtCustPhone.KeyDown += InputField_KeyDown;
            txtCustEmail.KeyDown += InputField_KeyDown;
            txtCustPassword.KeyDown += InputField_KeyDown;
            txtCustConfirmPass.KeyDown += InputField_KeyDown;

            // Admin fields
            //txtAdminName.KeyDown += InputField_KeyDown;
            //txtAdminUsername.KeyDown += InputField_KeyDown;
            //txtAdminPhone.KeyDown += InputField_KeyDown;
            //txtAdminEmail.KeyDown += InputField_KeyDown;
            //txtAdminPassword.KeyDown += InputField_KeyDown;
            //txtAdminConfirmPass.KeyDown += InputField_KeyDown;
            //txtAdminCode.KeyDown += InputField_KeyDown;

            cmbCountryCode.Items.AddRange(new object[] { "+94", "+1", "+44", "+91", "+61" });
            cmbCountryCode.SelectedIndex = 0;
        }

        private bool IsCustomerFormValid()
        {
            return !string.IsNullOrWhiteSpace(txtCustName.Text) &&
                   !string.IsNullOrWhiteSpace(txtCustEmail.Text) &&
                   !string.IsNullOrWhiteSpace(txtCustPhone.Text) &&
                   !string.IsNullOrWhiteSpace(txtCustAddress.Text) &&
                   !string.IsNullOrWhiteSpace(txtCustPassword.Text) &&
                   !string.IsNullOrWhiteSpace(txtCustConfirmPass.Text);
        }

        //private bool IsAdminFormValid()
        //{
        //    return !string.IsNullOrWhiteSpace(txtAdminName.Text) &&
        //           !string.IsNullOrWhiteSpace(txtAdminUsername.Text) &&
        //           !string.IsNullOrWhiteSpace(txtAdminPhone.Text) &&
        //           !string.IsNullOrWhiteSpace(txtAdminEmail.Text) &&
        //           !string.IsNullOrWhiteSpace(txtAdminPassword.Text) &&
        //           !string.IsNullOrWhiteSpace(txtAdminConfirmPass.Text) &&
        //           !string.IsNullOrWhiteSpace(txtAdminCode.Text);
        //}

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

        //private void txtAdminPassword_TextChanged(object sender, EventArgs e)
        //{
        //    string strength = GetPasswordStrength(txtAdminPassword.Text);
        //    lblAdminPasswordStrength.Text = strength;
        //    lblAdminPasswordStrength.ForeColor = GetStrengthColor(strength);
        //}

        private void txtCustPassword_TextChanged(object sender, EventArgs e)
        {
            string strength = GetPasswordStrength(txtCustPassword.Text);
            lblCustPasswordStrength.Text = strength;
            lblCustPasswordStrength.ForeColor = GetStrengthColor(strength);
        }

        //private void btnRegisterAdmin_Click(object sender, EventArgs e)
        //{
        //    if (!IsAdminFormValid())
        //    {
        //        MessageBox.Show("Please fill all admin fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    string name = txtAdminName.Text.Trim();
        //    string username = txtAdminUsername.Text.Trim();
        //    string phone = txtAdminPhone.Text.Trim();
        //    string email = txtAdminEmail.Text.Trim();
        //    string password = txtAdminPassword.Text;
        //    string confirm = txtAdminConfirmPass.Text;
        //    string code = txtAdminCode.Text.Trim();

        //    if (password != confirm)
        //    {
        //        MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (txtAdminPassword.Text.Length < 6)
        //    {
        //        MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    using (SqlConnection conn = DBHelper.GetConnection())
        //    {
        //        conn.Open();

        //        SqlCommand checkCode = new SqlCommand("SELECT COUNT(*) FROM AdminCodes WHERE Code = @code AND IsUsed = 0", conn);
        //        checkCode.Parameters.AddWithValue("@code", code);
        //        int count = (int)checkCode.ExecuteScalar();

        //        if (count == 0)
        //        {
        //            MessageBox.Show("Invalid or used Admin Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        SqlCommand insert = new SqlCommand("INSERT INTO Admins (FullName,Email, Phone, Username, Password) VALUES (@fn, @e, @p, @u, @pw)", conn);
        //        insert.Parameters.AddWithValue("@fn", name);
        //        insert.Parameters.AddWithValue("@e", email);
        //        insert.Parameters.AddWithValue("@p", phone);
        //        insert.Parameters.AddWithValue("@u", username);
        //        insert.Parameters.AddWithValue("@pw", password);
        //        insert.ExecuteNonQuery();

        //        SqlCommand markUsed = new SqlCommand("UPDATE AdminCodes SET IsUsed = 1 WHERE Code = @code", conn);
        //        markUsed.Parameters.AddWithValue("@code", code);
        //        markUsed.ExecuteNonQuery();

        //        MessageBox.Show("Admin registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        var loginForm = new LoginForm();
        //        loginForm.Show();
        //        this.Close();
        //    }
        //}

        //private void chkAdminShowPassword_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkAdminShowPassword.Checked)
        //    {
        //        txtAdminPassword.PasswordChar = '\0'; // No masking
        //        txtAdminConfirmPass.PasswordChar = '\0';
        //    }
        //    else
        //    {
        //        txtAdminPassword.PasswordChar = '•';  // Mask with bullet
        //        txtAdminConfirmPass.PasswordChar = '•';
        //    }
        //}

        private void btnRegisterCustomer_Click(object sender, EventArgs e)
        {
            if (!IsCustomerFormValid())
            {
                MessageBox.Show("Please fill all customer fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtCustName.Text.Trim();
            string email = txtCustEmail.Text.Trim();
            string phone = txtCustPhone.Text.Trim();
            string address = txtCustAddress.Text.Trim();
            string password = txtCustPassword.Text;
            string confirm = txtCustConfirmPass.Text;

            string countryCode = cmbCountryCode.Text.Trim();
            string fullPhone = countryCode + phone;

            if (!Regex.IsMatch(phone, @"^\d{7,15}$"))
            {
                MessageBox.Show("Phone number must be 7–15 digits long (numbers only).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE Email = @e", conn);
                checkEmail.Parameters.AddWithValue("@e", email);
                if ((int)checkEmail.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Email already exists. Please use a different one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand insert = new SqlCommand("INSERT INTO Customers (FullName, Email, Phone, Address, Password) VALUES (@fn, @e, @p, @a, @pw)", conn);
                insert.Parameters.AddWithValue("@fn", name);
                insert.Parameters.AddWithValue("@e", email);
                insert.Parameters.AddWithValue("@p", fullPhone);
                insert.Parameters.AddWithValue("@a", address);
                insert.Parameters.AddWithValue("@pw", password);
                insert.ExecuteNonQuery();

                MessageBox.Show("Customer registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void chkCustShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustShowPassword.Checked)
            {
                txtCustPassword.PasswordChar = '\0'; // No masking
                txtCustConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtCustPassword.PasswordChar = '•';  // Mask with bullet
                txtCustConfirmPass.PasswordChar = '•';
            }
        }

        private void InputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the "ding" sound
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}
