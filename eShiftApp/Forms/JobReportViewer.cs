using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eShiftApp.Forms
{
    public partial class JobReportViewer : Form
    {
        private DateTime _from;
        private DateTime _to;
        private string _status;
        public JobReportViewer(DateTime from, DateTime to, string status)
        {
            InitializeComponent();
            _from = from;
            _to = to;
            _status = status;
        }

        private void JobReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument report = new ReportDocument();

                // Load your Crystal Report file
                report.Load(@"F:\ESOFT\TOP - UP\Application Development (AD)\Practicals\Windows Form Apps\eShiftApp\Reports\JobReport.rpt");

                // Pass parameters to Crystal Report
                report.SetParameterValue("from", _from);
                report.SetParameterValue("to", _to);
                report.SetParameterValue("status", _status);

                crvJobs.ReportSource = report;
                crvJobs.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load report: " + ex.Message);
            }
        }
    }
}
