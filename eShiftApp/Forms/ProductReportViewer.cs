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
    public partial class ProductReportViewer : Form
    {
        private string _category;
        private int _maxQty;
        public ProductReportViewer(string category, int maxQty)
        {
            InitializeComponent();
            _category = category;
            _maxQty = maxQty;
        }

        private void ProductReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument report = new ReportDocument();
                report.Load(@"F:\ESOFT\TOP - UP\Application Development (AD)\Practicals\Windows Form Apps\eShiftApp\Reports\ProductReport.rpt");

                // Pass parameters to Crystal Report
                report.SetParameterValue("category", _category);
                report.SetParameterValue("maxQty", _maxQty);

                crvProducts.ReportSource = report;
                crvProducts.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load Product Report: " + ex.Message);
            }
        }
    }
}
