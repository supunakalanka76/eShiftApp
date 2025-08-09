namespace eShiftApp.Forms
{
    partial class ProductRevenueViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crvProductRevenue = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvProductRevenue
            // 
            this.crvProductRevenue.ActiveViewIndex = -1;
            this.crvProductRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvProductRevenue.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvProductRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvProductRevenue.Location = new System.Drawing.Point(0, 0);
            this.crvProductRevenue.Name = "crvProductRevenue";
            this.crvProductRevenue.Size = new System.Drawing.Size(1268, 744);
            this.crvProductRevenue.TabIndex = 0;
            // 
            // ProductRevenueViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 744);
            this.Controls.Add(this.crvProductRevenue);
            this.MaximizeBox = false;
            this.Name = "ProductRevenueViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductRevenueViewer";
            this.Load += new System.EventHandler(this.ProductRevenueViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvProductRevenue;
    }
}