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
    public partial class CustomerReportViewer : Form
    {
        public CustomerReportViewer()
        {
            InitializeComponent();
        }

        private void CustomerReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument report = new ReportDocument();

                // Load your Crystal Report file
                report.Load(@"F:\ESOFT\TOP - UP\Application Development (AD)\Practicals\Windows Form Apps\eShiftApp\Reports\CustomerReport.rpt");

                crvCustomer.ReportSource = report;
                crvCustomer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load report: " + ex.Message);
            }
        }
    }
}
