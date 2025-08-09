namespace eShiftApp.Forms
{
    partial class ProductReportViewer
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
            this.crvProducts = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvProducts
            // 
            this.crvProducts.ActiveViewIndex = -1;
            this.crvProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvProducts.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvProducts.Location = new System.Drawing.Point(0, 0);
            this.crvProducts.Name = "crvProducts";
            this.crvProducts.Size = new System.Drawing.Size(1268, 744);
            this.crvProducts.TabIndex = 0;
            // 
            // ProductReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 744);
            this.Controls.Add(this.crvProducts);
            this.MaximizeBox = false;
            this.Name = "ProductReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductReportViewer";
            this.Load += new System.EventHandler(this.ProductReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvProducts;
    }
}