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
using eShiftApp.Models;

namespace eShiftApp.Forms
{
    public partial class LoadForm : Form
    {
        private int? _loadId = null;
        public bool IsSaved = false;
        public LoadForm()
        {
            InitializeComponent();
            LoadJobIDs();
            LoadTransportUnits();
        }

        public LoadForm(int loadId)
        {
            InitializeComponent();
            _loadId = loadId;
            LoadJobIDs();
            LoadTransportUnits();
            LoadLoadData();
        }

        private void LoadJobIDs()
        {
            cmbJobID.Items.Clear();

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT JobID, StartLocation, EndLocation, JobDate FROM Jobs";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["JobID"]);
                    string from = reader["StartLocation"].ToString();
                    string to = reader["EndLocation"].ToString();
                    string date = Convert.ToDateTime(reader["JobDate"]).ToShortDateString();

                    string display = $"ID {id} - From: {from} → To: {to} / Date: {date}";
                    cmbJobID.Items.Add(new ComboItem(id, display));
                }
            }
        }


        private void LoadTransportUnits()
        {
            cmbTransportID.Items.Clear(); // Always clear before reloading

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT TransportID, LorryID, DriverName FROM TransportUnits";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["TransportID"]);
                    string lorry = reader["LorryID"].ToString();
                    string driver = reader["DriverName"].ToString();

                    string display = $"ID {id} - {lorry} / Driver: {driver}";
                    cmbTransportID.Items.Add(new ComboItem(id, display));
                }
            }
        }

        private void LoadLoadData()
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Loads WHERE LoadID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _loadId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int jobId = Convert.ToInt32(reader["JobID"]);
                    int transportId = Convert.ToInt32(reader["TransportID"]);

                    txtDescription.Text = reader["Description"].ToString();
                    txtWeight.Text = reader["Weight"].ToString();

                    // Set selected JobID in ComboBox
                    foreach (ComboItem item in cmbJobID.Items)
                    {
                        if (item.ID == jobId)
                        {
                            cmbJobID.SelectedItem = item;
                            break;
                        }
                    }

                    // Set selected TransportID in ComboBox
                    foreach (ComboItem item in cmbTransportID.Items)
                    {
                        if (item.ID == transportId)
                        {
                            cmbTransportID.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate required fields
            if (cmbJobID.SelectedItem == null || cmbTransportID.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtWeight.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // 2. Validate numeric weight
            if (!double.TryParse(txtWeight.Text, out double weight))
            {
                MessageBox.Show("Weight must be a valid number.");
                return;
            }

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                string query;
                SqlCommand cmd;

                // 3. Determine INSERT or UPDATE mode
                if (_loadId == null)
                {
                    query = "INSERT INTO Loads (JobID, Description, Weight, TransportID) VALUES (@job, @desc, @weight, @trans)";
                    cmd = new SqlCommand(query, conn);
                }
                else
                {
                    query = "UPDATE Loads SET JobID=@job, Description=@desc, Weight=@weight, TransportID=@trans WHERE LoadID=@id";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", _loadId);
                }

                // 4. Add Parameters
                int jobId = ((ComboItem)cmbJobID.SelectedItem).ID;
                int transportId = ((ComboItem)cmbTransportID.SelectedItem).ID;

                cmd.Parameters.AddWithValue("@job", jobId);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@weight", weight);
                cmd.Parameters.AddWithValue("@trans", transportId);

                // 5. Execute
                cmd.ExecuteNonQuery();
                MessageBox.Show("Load saved successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsSaved = true;
                this.Close();
            }
        }

    }
}
