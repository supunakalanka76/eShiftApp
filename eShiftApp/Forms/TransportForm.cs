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
    public partial class TransportForm : Form
    {
        private int? _transportId = null;
        public bool IsSaved = false;
        public TransportForm() // Add mode
        {
            InitializeComponent();
        }

        public TransportForm(int transportId) // Edit mode
        {
            InitializeComponent();
            _transportId = transportId;
            LoadTransportData();
        }


        private void LoadTransportData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM TransportUnits WHERE TransportID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _transportId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtLorryID.Text = reader["LorryID"].ToString();
                    txtDriverName.Text = reader["DriverName"].ToString();
                    txtAssistantName.Text = reader["AssistantName"].ToString();
                    txtContainerID.Text = reader["ContainerID"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLorryID.Text) ||
        string.IsNullOrWhiteSpace(txtDriverName.Text) ||
        string.IsNullOrWhiteSpace(txtAssistantName.Text) ||
        string.IsNullOrWhiteSpace(txtContainerID.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query;
                SqlCommand cmd;

                if (_transportId == null)
                {
                    query = "INSERT INTO TransportUnits (LorryID, DriverName, AssistantName, ContainerID) VALUES (@lorry, @driver, @assistant, @container)";
                    cmd = new SqlCommand(query, conn);
                }
                else
                {
                    query = "UPDATE TransportUnits SET LorryID=@lorry, DriverName=@driver, AssistantName=@assistant, ContainerID=@container WHERE TransportID=@id";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", _transportId);
                }

                cmd.Parameters.AddWithValue("@lorry", txtLorryID.Text);
                cmd.Parameters.AddWithValue("@driver", txtDriverName.Text);
                cmd.Parameters.AddWithValue("@assistant", txtAssistantName.Text);
                cmd.Parameters.AddWithValue("@container", txtContainerID.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Transport unit saved successfully.","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsSaved = true;
                this.Close();
            }
        }
    }
}
