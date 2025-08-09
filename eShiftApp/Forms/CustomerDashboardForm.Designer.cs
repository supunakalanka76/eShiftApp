namespace eShiftApp.Forms
{
    partial class CustomerDashboardForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dgvCustomerJobs = new System.Windows.Forms.DataGridView();
            this.btnRequestJob = new System.Windows.Forms.Button();
            this.btnViewLoads = new System.Windows.Forms.Button();
            this.btnCancelJob = new System.Windows.Forms.Button();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDeclinedJobs = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPendingJobs = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAcceptedJobs = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalJobs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBackToLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerJobs)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("SF Pro Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(28, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(217, 33);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "customer Name";
            // 
            // dgvCustomerJobs
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomerJobs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomerJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomerJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCustomerJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerJobs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvCustomerJobs.EnableHeadersVisualStyles = false;
            this.dgvCustomerJobs.Location = new System.Drawing.Point(6, 6);
            this.dgvCustomerJobs.Name = "dgvCustomerJobs";
            this.dgvCustomerJobs.RowHeadersWidth = 51;
            this.dgvCustomerJobs.RowTemplate.Height = 24;
            this.dgvCustomerJobs.Size = new System.Drawing.Size(1095, 413);
            this.dgvCustomerJobs.TabIndex = 2;
            // 
            // btnRequestJob
            // 
            this.btnRequestJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestJob.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnRequestJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequestJob.FlatAppearance.BorderSize = 0;
            this.btnRequestJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestJob.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestJob.ForeColor = System.Drawing.Color.White;
            this.btnRequestJob.Location = new System.Drawing.Point(825, 459);
            this.btnRequestJob.Name = "btnRequestJob";
            this.btnRequestJob.Size = new System.Drawing.Size(255, 50);
            this.btnRequestJob.TabIndex = 3;
            this.btnRequestJob.Text = "📝 Request New Job";
            this.btnRequestJob.UseVisualStyleBackColor = false;
            this.btnRequestJob.Click += new System.EventHandler(this.btnRequestJob_Click);
            // 
            // btnViewLoads
            // 
            this.btnViewLoads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewLoads.BackColor = System.Drawing.Color.SteelBlue;
            this.btnViewLoads.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewLoads.FlatAppearance.BorderSize = 0;
            this.btnViewLoads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLoads.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewLoads.ForeColor = System.Drawing.Color.White;
            this.btnViewLoads.Location = new System.Drawing.Point(30, 459);
            this.btnViewLoads.Name = "btnViewLoads";
            this.btnViewLoads.Size = new System.Drawing.Size(255, 50);
            this.btnViewLoads.TabIndex = 4;
            this.btnViewLoads.Text = "👁️ View Load Details";
            this.btnViewLoads.UseVisualStyleBackColor = false;
            this.btnViewLoads.Click += new System.EventHandler(this.btnViewLoads_Click);
            // 
            // btnCancelJob
            // 
            this.btnCancelJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelJob.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancelJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelJob.FlatAppearance.BorderSize = 0;
            this.btnCancelJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelJob.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelJob.ForeColor = System.Drawing.Color.White;
            this.btnCancelJob.Location = new System.Drawing.Point(534, 459);
            this.btnCancelJob.Name = "btnCancelJob";
            this.btnCancelJob.Size = new System.Drawing.Size(255, 50);
            this.btnCancelJob.TabIndex = 5;
            this.btnCancelJob.Text = "❌ Cancel Job";
            this.btnCancelJob.UseVisualStyleBackColor = false;
            this.btnCancelJob.Click += new System.EventHandler(this.btnCancelJob_Click);
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProfile.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEditProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditProfile.FlatAppearance.BorderSize = 0;
            this.btnEditProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProfile.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProfile.ForeColor = System.Drawing.Color.White;
            this.btnEditProfile.Location = new System.Drawing.Point(673, 27);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(250, 45);
            this.btnEditProfile.TabIndex = 6;
            this.btnEditProfile.Text = "✏️ Edit Profile";
            this.btnEditProfile.UseVisualStyleBackColor = false;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(34, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1116, 581);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvCustomerJobs);
            this.tabPage1.Controls.Add(this.btnRequestJob);
            this.tabPage1.Controls.Add(this.btnViewLoads);
            this.tabPage1.Controls.Add(this.btnCancelJob);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1108, 543);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Jobs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1108, 543);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Overview Panel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.lblDeclinedJobs);
            this.panel4.Location = new System.Drawing.Point(676, 354);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 100);
            this.panel4.TabIndex = 4;
            // 
            // lblDeclinedJobs
            // 
            this.lblDeclinedJobs.AutoSize = true;
            this.lblDeclinedJobs.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeclinedJobs.Location = new System.Drawing.Point(37, 43);
            this.lblDeclinedJobs.Name = "lblDeclinedJobs";
            this.lblDeclinedJobs.Size = new System.Drawing.Size(162, 24);
            this.lblDeclinedJobs.TabIndex = 3;
            this.lblDeclinedJobs.Text = "Declined Jobs: 0";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.AliceBlue;
            this.panel3.Controls.Add(this.lblPendingJobs);
            this.panel3.Location = new System.Drawing.Point(159, 354);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 100);
            this.panel3.TabIndex = 3;
            // 
            // lblPendingJobs
            // 
            this.lblPendingJobs.AutoSize = true;
            this.lblPendingJobs.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingJobs.Location = new System.Drawing.Point(36, 43);
            this.lblPendingJobs.Name = "lblPendingJobs";
            this.lblPendingJobs.Size = new System.Drawing.Size(157, 24);
            this.lblPendingJobs.TabIndex = 2;
            this.lblPendingJobs.Text = "Pending Jobs: 0";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.lblAcceptedJobs);
            this.panel2.Location = new System.Drawing.Point(676, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 100);
            this.panel2.TabIndex = 3;
            // 
            // lblAcceptedJobs
            // 
            this.lblAcceptedJobs.AutoSize = true;
            this.lblAcceptedJobs.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcceptedJobs.Location = new System.Drawing.Point(37, 41);
            this.lblAcceptedJobs.Name = "lblAcceptedJobs";
            this.lblAcceptedJobs.Size = new System.Drawing.Size(170, 24);
            this.lblAcceptedJobs.TabIndex = 1;
            this.lblAcceptedJobs.Text = "Accepted Jobs: 0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.lblTotalJobs);
            this.panel1.Location = new System.Drawing.Point(159, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 100);
            this.panel1.TabIndex = 2;
            // 
            // lblTotalJobs
            // 
            this.lblTotalJobs.AutoSize = true;
            this.lblTotalJobs.Font = new System.Drawing.Font("SF Pro Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalJobs.Location = new System.Drawing.Point(36, 41);
            this.lblTotalJobs.Name = "lblTotalJobs";
            this.lblTotalJobs.Size = new System.Drawing.Size(125, 24);
            this.lblTotalJobs.TabIndex = 0;
            this.lblTotalJobs.Text = "Total Jobs: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jobs Overview";
            // 
            // btnBackToLogin
            // 
            this.btnBackToLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackToLogin.BackColor = System.Drawing.Color.DarkGreen;
            this.btnBackToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToLogin.FlatAppearance.BorderSize = 0;
            this.btnBackToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToLogin.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToLogin.ForeColor = System.Drawing.Color.White;
            this.btnBackToLogin.Location = new System.Drawing.Point(984, 27);
            this.btnBackToLogin.Name = "btnBackToLogin";
            this.btnBackToLogin.Size = new System.Drawing.Size(153, 45);
            this.btnBackToLogin.TabIndex = 8;
            this.btnBackToLogin.Text = "🔙 Back to Login";
            this.btnBackToLogin.UseVisualStyleBackColor = false;
            this.btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click);
            // 
            // CustomerDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 674);
            this.Controls.Add(this.btnBackToLogin);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.lblWelcome);
            this.Font = new System.Drawing.Font("SF Pro Display", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomerDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDashboardForm";
            this.Load += new System.EventHandler(this.CustomerDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerJobs)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvCustomerJobs;
        private System.Windows.Forms.Button btnRequestJob;
        private System.Windows.Forms.Button btnViewLoads;
        private System.Windows.Forms.Button btnCancelJob;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDeclinedJobs;
        private System.Windows.Forms.Label lblPendingJobs;
        private System.Windows.Forms.Label lblAcceptedJobs;
        private System.Windows.Forms.Label lblTotalJobs;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBackToLogin;
    }
}