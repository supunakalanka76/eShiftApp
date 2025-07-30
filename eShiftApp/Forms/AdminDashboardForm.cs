using eShiftApp.Database;
using eShiftApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShiftApp.Forms
{
    public partial class AdminDashboardForm : Form
    {
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private DataTable jobTable = new DataTable();
        private DataTable productTable = new DataTable();

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            LoadJobData();
            LoadCustomerData();
            LoadLoadData();
            LoadTransportData();
            LoadReportData();
            LoadProductData();
        }

        private void LoadJobData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT JobID, CustomerID, StartLocation, EndLocation, JobDate, Description, Status FROM Jobs";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                jobTable.Clear();
                adapter.Fill(jobTable);
                dgvJobs.DataSource = jobTable;

                // Color-code job rows by status
                foreach (DataGridViewRow row in dgvJobs.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString();
                    if (status == "Accepted")
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (status == "Declined")
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }

                // Friendly column headers
                dgvJobs.Columns["JobID"].HeaderText = "Job ID";
                dgvJobs.Columns["CustomerID"].HeaderText = "Customer ID";
                dgvJobs.Columns["StartLocation"].HeaderText = "From";
                dgvJobs.Columns["EndLocation"].HeaderText = "To";
                dgvJobs.Columns["JobDate"].HeaderText = "Date";
                dgvJobs.Columns["Description"].HeaderText = "Job Description";
                dgvJobs.Columns["Status"].HeaderText = "Status";
            }
        }

        private void UpdateJobStatus(int jobId, string newStatus)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                // Get current status
                SqlCommand checkCmd = new SqlCommand("SELECT Status FROM Jobs WHERE JobID = @id", conn);
                checkCmd.Parameters.AddWithValue("@id", jobId);
                string currentStatus = checkCmd.ExecuteScalar()?.ToString();

                if (currentStatus == "Declined" && newStatus == "Accepted")
                {
                    MessageBox.Show("You can't accept a job that has already been declined.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentStatus == "Accepted" && newStatus == "Declined")
                {
                    MessageBox.Show("You can't decline a job that has already been accepted.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentStatus == "Accepted" && newStatus == "Accepted")
                {
                    MessageBox.Show("Job is already accepted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (currentStatus == "Declined" && newStatus == "Declined")
                {
                    MessageBox.Show("Job is already declined.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // All other transitions are allowed
                SqlCommand cmd = new SqlCommand("UPDATE Jobs SET Status = @status WHERE JobID = @id", conn);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", jobId);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Job marked as {newStatus}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadJobData();
            }
        }


        private void btnAcceptJob_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to accept this job?", "Confirm Accept", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);
                    UpdateJobStatus(jobId, "Accepted");
                }
            }
        }

        private void btnDeclineJob_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to decline this job?", "Confirm Decline", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);
                    UpdateJobStatus(jobId, "Declined");
                }
            }
        }

        private void btnViewJobProducts_Click(object sender, EventArgs e)
        {
            if (dgvJobs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a job to view its products.", "Select Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int jobId = Convert.ToInt32(dgvJobs.SelectedRows[0].Cells["JobID"].Value);

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
            SELECT p.ProductName, jp.Quantity, p.Price, (jp.Quantity * p.Price) AS Total
            FROM JobProducts jp
            JOIN Products p ON jp.ProductID = p.ProductID
            WHERE jp.JobID = @jobId", conn);
                cmd.Parameters.AddWithValue("@jobId", jobId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("No products were added for this job.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string details = "Products used in Job #" + jobId + ":\n\n";
                foreach (DataRow row in table.Rows)
                {
                    details += $"{row["ProductName"]} - Qty: {row["Quantity"]}, Price: Rs.{row["Price"]}, Total: Rs.{row["Total"]}\n";
                }

                MessageBox.Show(details, "Job Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnRefreshJobs_Click(object sender, EventArgs e)
        {
            LoadJobData();
        }

        private void LoadCustomerData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT CustomerID, FullName, Address, Phone, Email FROM Customers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvCustomers.DataSource = table;

                dgvCustomers.Columns["CustomerID"].HeaderText = "ID";
                dgvCustomers.Columns["FullName"].HeaderText = "Full Name";
                dgvCustomers.Columns["Address"].HeaderText = "Address";
                dgvCustomers.Columns["Phone"].HeaderText = "Phone";
                dgvCustomers.Columns["Email"].HeaderText = "Email";
            }
        }

        private void btnRefreshCustomers_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            form.ShowDialog();
            if (form.IsSaved)
            {
                LoadCustomerData();
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);
                var form = new CustomerForm(customerId);
                form.ShowDialog();
                if (form.IsSaved)
                {
                    LoadCustomerData();
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);
                var confirm = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = DBHelper.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", customerId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Customer deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomerData();
                    }
                }
            }
        }

        private void LoadLoadData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT l.LoadID, l.JobID, l.Description, l.Weight, 
                   t.LorryID, t.DriverName, t.AssistantName
            FROM Loads l
            LEFT JOIN TransportUnits t ON l.TransportID = t.TransportID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvLoads.DataSource = table;

                dgvLoads.Columns["LoadID"].HeaderText = "Load ID";
                dgvLoads.Columns["JobID"].HeaderText = "Job ID";
                dgvLoads.Columns["Description"].HeaderText = "Description";
                dgvLoads.Columns["Weight"].HeaderText = "Weight (kg)";
                dgvLoads.Columns["LorryID"].HeaderText = "Lorry ID";
                dgvLoads.Columns["DriverName"].HeaderText = "Driver";
                dgvLoads.Columns["AssistantName"].HeaderText = "Assistant";
            }
        }

        private void btnRefreshLoads_Click(object sender, EventArgs e)
        {
            LoadLoadData();
        }

        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            var form = new LoadForm();
            form.ShowDialog();
            if (form.IsSaved)
                LoadLoadData();
        }

        private void btnEditLoad_Click(object sender, EventArgs e)
        {
            if (dgvLoads.SelectedRows.Count > 0)
            {
                int loadId = Convert.ToInt32(dgvLoads.SelectedRows[0].Cells["LoadID"].Value);
                var form = new LoadForm(loadId);
                form.ShowDialog();
                if (form.IsSaved)
                    LoadLoadData();
            }
        }

        private void btnDeleteLoad_Click(object sender, EventArgs e)
        {
            if (dgvLoads.SelectedRows.Count > 0)
            {
                int loadId = Convert.ToInt32(dgvLoads.SelectedRows[0].Cells["LoadID"].Value);
                var confirm = MessageBox.Show("Delete this load?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = DBHelper.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Loads WHERE LoadID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", loadId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Load deleted.");
                        LoadLoadData();
                    }
                }
            }
        }

        private void LoadTransportData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM TransportUnits";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTransportUnits.DataSource = table;

                dgvTransportUnits.Columns["TransportID"].HeaderText = "ID";
                dgvTransportUnits.Columns["LorryID"].HeaderText = "Lorry No.";
                dgvTransportUnits.Columns["DriverName"].HeaderText = "Driver";
                dgvTransportUnits.Columns["AssistantName"].HeaderText = "Assistant";
                dgvTransportUnits.Columns["ContainerID"].HeaderText = "CO-ID No.";
            }
        }

        private void btnRefreshTransport_Click(object sender, EventArgs e)
        {
            LoadTransportData();
        }

        private void btnAddTransport_Click(object sender, EventArgs e)
        {
            var form = new TransportForm();
            form.ShowDialog();
            if (form.IsSaved)
                LoadTransportData();
        }

        private void btnEditTransport_Click(object sender, EventArgs e)
        {
            if (dgvTransportUnits.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTransportUnits.SelectedRows[0].Cells["TransportID"].Value);
                var form = new TransportForm(id);
                form.ShowDialog();
                if (form.IsSaved)
                    LoadTransportData();
            }
        }

        private void btnDeleteTransport_Click(object sender, EventArgs e)
        {
            if (dgvTransportUnits.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTransportUnits.SelectedRows[0].Cells["TransportID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this transport unit?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = DBHelper.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM TransportUnits WHERE TransportID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Transport unit deleted.");
                        LoadTransportData();
                    }
                }
            }
        }

        private void LoadReportData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                // Total Customers
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Customers", conn);
                lblTotalCustomers.Text = "Total Customers: " + cmd1.ExecuteScalar().ToString();

                // Total Jobs
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Jobs", conn);
                lblTotalJobs.Text = "Total Jobs: " + cmd2.ExecuteScalar().ToString();

                // Jobs by Status
                SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Jobs WHERE Status='Pending'", conn);
                lblJobsPending.Text = "Pending Jobs: " + cmd3.ExecuteScalar().ToString();

                SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM Jobs WHERE Status='Accepted'", conn);
                lblJobsAccepted.Text = "Accepted Jobs: " + cmd4.ExecuteScalar().ToString();

                SqlCommand cmd5 = new SqlCommand("SELECT COUNT(*) FROM Jobs WHERE Status='Declined'", conn);
                lblJobsDeclined.Text = "Declined Jobs: " + cmd5.ExecuteScalar().ToString();

                // Total Loads
                SqlCommand cmd6 = new SqlCommand("SELECT COUNT(*) FROM Loads", conn);
                lblTotalLoads.Text = "Total Loads: " + cmd6.ExecuteScalar().ToString();

                // Total Transport Units
                SqlCommand cmd7 = new SqlCommand("SELECT COUNT(*) FROM TransportUnits", conn);
                lblTotalTransport.Text = "Total Transport Units: " + cmd7.ExecuteScalar().ToString();

                // Total Products
                SqlCommand cmd8 = new SqlCommand("SELECT COUNT (*) FROM Products", conn);
                lblProducts.Text = "Total Products: " + cmd8.ExecuteScalar().ToString();
            }
        }

        private void btnRefreshReport_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            string report = $"{lblTotalCustomers.Text}\n" +
                    $"{lblTotalJobs.Text}\n" +
                    $"{lblJobsPending.Text}\n" +
                    $"{lblJobsAccepted.Text}\n" +
                    $"{lblJobsDeclined.Text}\n" +
                    $"{lblTotalLoads.Text}\n" +
                    $"{lblTotalTransport.Text}\n" +
                    $"{lblProducts.Text}";
                    

            string path = "AdminReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            File.WriteAllText(path, report);
            MessageBox.Show("Report exported to: " + path);
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }


        private void dgvJobs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string desc = dgvJobs.SelectedRows[0].Cells["Description"].Value.ToString();
            MessageBox.Show(desc, "Job Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyJobFilters()
        {
            string keyword = txtJobSearch.Text.Trim().ToLower();
            string status = cmbJobStatusFilter.SelectedItem?.ToString() ?? "All";

            string filter = "";

            if (!string.IsNullOrEmpty(keyword))
            {
                filter += $"Convert(JobID, 'System.String') LIKE '%{keyword}%' OR " +
                          $"StartLocation LIKE '%{keyword}%' OR " +
                          $"EndLocation LIKE '%{keyword}%'";
            }

            if (status != "All")
            {
                if (!string.IsNullOrEmpty(filter))
                    filter = $"({filter}) AND ";

                filter += $"Status = '{status}'";
            }

            DataView dv = new DataView(jobTable);
            dv.RowFilter = filter;
            dgvJobs.DataSource = dv;
        }

        private void txtJobSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyJobFilters();
        }

        private void cmbJobStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyJobFilters();
        }

        private void btnClearJobSearch_Click(object sender, EventArgs e)
        {
            txtJobSearch.Clear();
            cmbJobStatusFilter.SelectedIndex = 0;
        }

        private void LoadProductData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT ProductID, ProductName, Description, Price, Category, Quantity FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                productTable.Clear();
                adapter.Fill(productTable);
                dgvProducts.DataSource = productTable;

                dgvProducts.Columns["ProductID"].HeaderText = "ID";
                dgvProducts.Columns["ProductName"].HeaderText = "Name";
                dgvProducts.Columns["Description"].HeaderText = "Description";
                dgvProducts.Columns["Price"].HeaderText = "Price (Rs.)";
                dgvProducts.Columns["Category"].HeaderText = "Category";
                dgvProducts.Columns["Quantity"].HeaderText = "Quantity";

                // Highlight out-of-stock products in red
                bool hasOutOfStock = false;
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (int.TryParse(row.Cells["Quantity"].Value?.ToString(), out int qty))
                    {
                        if (qty == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.DarkRed;
                            hasOutOfStock = true;
                        }
                        else if (qty <= 5)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightYellow; // low stock warning
                        }
                    }
                }

                // Show message if at least one product is out of stock
                if (hasOutOfStock)
                {
                    MessageBox.Show("⚠ Some products are out of stock!", "Product Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnRefreshProducts_Click(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            form.ShowDialog();
            if (form.IsSaved)
                LoadProductData();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
                var form = new ProductForm(id);
                form.ShowDialog();
                if (form.IsSaved)
                    LoadProductData();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
                var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = DBHelper.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Product deleted.");
                        LoadProductData();
                    }
                }
            }
        }

        private void btnRequestJob_Click(object sender, EventArgs e)
        {
            
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
