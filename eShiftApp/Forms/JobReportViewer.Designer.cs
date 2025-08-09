namespace eShiftApp.Forms
{
    partial class JobReportViewer
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
            this.crvJobs = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvJobs
            // 
            this.crvJobs.ActiveViewIndex = -1;
            this.crvJobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvJobs.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvJobs.Location = new System.Drawing.Point(0, 0);
            this.crvJobs.Name = "crvJobs";
            this.crvJobs.Size = new System.Drawing.Size(1268, 744);
            this.crvJobs.TabIndex = 0;
            // 
            // JobReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 744);
            this.Controls.Add(this.crvJobs);
            this.MaximizeBox = false;
            this.Name = "JobReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JobReportViewer";
            this.Load += new System.EventHandler(this.JobReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvJobs;
    }
}