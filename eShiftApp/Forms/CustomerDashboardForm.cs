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
    public partial class CustomerDashboardForm : Form
    {
        private int _customerId;
        public CustomerDashboardForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            LoadCustomerJobs();
            LoadJobSummary();

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT FullName FROM Customers WHERE CustomerID = @id", conn);
                cmd.Parameters.AddWithValue("@id", _customerId);
                var name = cmd.ExecuteScalar()?.ToString();
                if (!string.IsNullOrEmpty(name))
                {
                    lblWelcome.Text = $"Welcome, {name}!";
                }
                else
                {
                    lblWelcome.Text = "Welcome!";
                }
            }
        }

        private void LoadCustomerJobs()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT JobID, StartLocation, EndLocation, JobDate, Description, Status FROM Jobs WHERE CustomerID = @custId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@custId", _customerId);

                

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvCustomerJobs.DataSource = table;
            }

            // Apply row colors based on status
            foreach (DataGridViewRow row in dgvCustomerJobs.Rows)
            {
                if (row.Cells["Status"].Value != null)
                {
                    string status = row.Cells["Status"].Value.ToString();
                    switch (status)
                    {
                        case "Pending":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Accepted":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Declined":
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                    }
                }
            }
        }

        private void LoadJobSummary()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                string baseQuery = "SELECT COUNT(*) FROM Jobs WHERE CustomerID = @custId AND Status = @status";
                string totalQuery = "SELECT COUNT(*) FROM Jobs WHERE CustomerID = @custId";

                // Total
                SqlCommand totalCmd = new SqlCommand(totalQuery, conn);
                totalCmd.Parameters.AddWithValue("@custId", _customerId);
                lblTotalJobs.Text = "Total Jobs: " + totalCmd.ExecuteScalar().ToString();

                // Accepted
                SqlCommand acceptedCmd = new SqlCommand(baseQuery, conn);
                acceptedCmd.Parameters.AddWithValue("@custId", _customerId);
                acceptedCmd.Parameters.AddWithValue("@status", "Accepted");
                lblAcceptedJobs.Text = "Accepted Jobs: " + acceptedCmd.ExecuteScalar().ToString();
                acceptedCmd.Parameters.Clear();

                // Pending
                acceptedCmd.Parameters.AddWithValue("@custId", _customerId);
                acceptedCmd.Parameters.AddWithValue("@status", "Pending");
                lblPendingJobs.Text = "Pending Jobs: " + acceptedCmd.ExecuteScalar().ToString();
                acceptedCmd.Parameters.Clear();

                // Declined
                acceptedCmd.Parameters.AddWithValue("@custId", _customerId);
                acceptedCmd.Parameters.AddWithValue("@status", "Declined");
                lblDeclinedJobs.Text = "Declined Jobs: " + acceptedCmd.ExecuteScalar().ToString();
            }
        }


        private void btnRequestJob_Click(object sender, EventArgs e)
        {
            var jobForm = new JobRequestForm(_customerId);
            jobForm.ShowDialog();

            // Reload jobs after adding
            LoadCustomerJobs();
        }

        private void btnViewLoads_Click(object sender, EventArgs e)
        {
            if (dgvCustomerJobs.SelectedRows.Count > 0)
            {
                int jobId = Convert.ToInt32(dgvCustomerJobs.SelectedRows[0].Cells["JobID"].Value);
                var form = new JobLoadDetailsForm(jobId);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a job to view its loads.");
            }
        }

        private void btnCancelJob_Click(object sender, EventArgs e)
        {
            if (dgvCustomerJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job.");
                return;
            }

            int jobId = Convert.ToInt32(dgvCustomerJobs.SelectedRows[0].Cells["JobID"].Value);
            string status = dgvCustomerJobs.SelectedRows[0].Cells["Status"].Value.ToString();

            if (status != "Pending")
            {
                MessageBox.Show("Only pending jobs can be canceled.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to cancel this job?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = DBHelper.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Jobs WHERE JobID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", jobId);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Job canceled.");
                LoadCustomerJobs();
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            var profileForm = new CustomerProfileForm(_customerId);
            profileForm.ShowDialog();
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                new LoginForm().Show();
                this.Hide();
            }
        }
    }
}
