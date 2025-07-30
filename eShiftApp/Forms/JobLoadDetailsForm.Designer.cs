namespace eShiftApp.Forms
{
    partial class JobLoadDetailsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblJobSummary = new System.Windows.Forms.Label();
            this.dgvLoadDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJobSummary
            // 
            this.lblJobSummary.AutoSize = true;
            this.lblJobSummary.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobSummary.Location = new System.Drawing.Point(37, 112);
            this.lblJobSummary.Name = "lblJobSummary";
            this.lblJobSummary.Size = new System.Drawing.Size(136, 24);
            this.lblJobSummary.TabIndex = 0;
            this.lblJobSummary.Text = "Job Summary";
            // 
            // dgvLoadDetails
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLoadDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLoadDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoadDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoadDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLoadDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadDetails.EnableHeadersVisualStyles = false;
            this.dgvLoadDetails.Location = new System.Drawing.Point(41, 153);
            this.dgvLoadDetails.Name = "dgvLoadDetails";
            this.dgvLoadDetails.RowHeadersVisible = false;
            this.dgvLoadDetails.RowHeadersWidth = 51;
            this.dgvLoadDetails.RowTemplate.Height = 24;
            this.dgvLoadDetails.Size = new System.Drawing.Size(816, 313);
            this.dgvLoadDetails.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SF Pro Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Job Summary";
            // 
            // JobLoadDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLoadDetails);
            this.Controls.Add(this.lblJobSummary);
            this.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "JobLoadDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JobLoadDetailsForm";
            this.Load += new System.EventHandler(this.JobLoadDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJobSummary;
        private System.Windows.Forms.DataGridView dgvLoadDetails;
        private System.Windows.Forms.Label label1;
    }
}