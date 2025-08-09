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
    public partial class ProductRevenueViewer : Form
    {
        private string _category;
        public ProductRevenueViewer(string category = "All")
        {
            InitializeComponent();
            _category = category;
        }

        private void ProductRevenueViewer_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument report = new ReportDocument();
                report.Load(@"F:\ESOFT\TOP - UP\Application Development (AD)\Practicals\Windows Form Apps\eShiftApp\Reports\ProductRevenue.rpt");

                // Pass parameters
                report.SetParameterValue("Category", _category);

                // Load report into viewer
                crvProductRevenue.ReportSource = report;
                crvProductRevenue.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load report: " + ex.Message);
            }
        }
    }
}
