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
    public partial class JobLoadDetailsForm : Form
    {
        private int _jobId;

        public JobLoadDetailsForm(int jobId)
        {
            InitializeComponent();
            _jobId = jobId;
        }

        private void JobLoadDetailsForm_Load(object sender, EventArgs e)
        {
            LoadLoadDetails();
        }

        private void LoadLoadDetails()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                // Optional: Get job summary
                SqlCommand jobCmd = new SqlCommand("SELECT Status FROM Jobs WHERE JobID = @id", conn);
                jobCmd.Parameters.AddWithValue("@id", _jobId);
                string status = jobCmd.ExecuteScalar()?.ToString() ?? "Unknown";

                lblJobSummary.Text = $"Job ID: {_jobId} | Status: {status}";

                // Load associated load records
                string query = @"
            SELECT l.LoadID, l.Description, l.Weight, 
                   t.LorryID, t.DriverName, t.AssistantName, t.ContainerID
            FROM Loads l
            LEFT JOIN TransportUnits t ON l.TransportID = t.TransportID
            WHERE l.JobID = @jobId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@jobId", _jobId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvLoadDetails.DataSource = table;
            }
        }

    }
}
