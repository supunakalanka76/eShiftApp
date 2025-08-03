using eShiftApp.Database;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eShiftApp.Forms
{
    public partial class JobRequestForm : Form
    {
        private int _customerId;
        private string _userRole; // "Admin" or "Customer"

        public JobRequestForm(int customerId, string userRole)
        {
            InitializeComponent();
            _customerId = customerId;
            _userRole = userRole;
        }

        private void JobRequestForm_Load(object sender, EventArgs e)
        {
            
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
                                                "VALUES (@cust, @start, @end, @date, 'Pending', @desc)", conn);
                cmd.Parameters.AddWithValue("@cust", _customerId);
                cmd.Parameters.AddWithValue("@start", txtStart.Text);
                cmd.Parameters.AddWithValue("@end", txtEnd.Text);
                cmd.Parameters.AddWithValue("@date", dtpJobDate.Value);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Job request submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
