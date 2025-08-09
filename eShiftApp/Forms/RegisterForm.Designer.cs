namespace eShiftApp.Forms
{
    partial class RegisterForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.grpbCustomer = new System.Windows.Forms.GroupBox();
            this.lblCustPasswordStrength = new System.Windows.Forms.Label();
            this.txtCustAddress = new System.Windows.Forms.TextBox();
            this.lblCustAddress = new System.Windows.Forms.Label();
            this.btnRegisterCustomer = new System.Windows.Forms.Button();
            this.txtCustPhone = new System.Windows.Forms.TextBox();
            this.txtCustConfirmPass = new System.Windows.Forms.TextBox();
            this.txtCustPassword = new System.Windows.Forms.TextBox();
            this.lblCustPhone = new System.Windows.Forms.Label();
            this.txtCustEmail = new System.Windows.Forms.TextBox();
            this.chkCustShowPassword = new System.Windows.Forms.CheckBox();
            this.lblConfirmCustPass = new System.Windows.Forms.Label();
            this.lblCustPassword = new System.Windows.Forms.Label();
            this.lblCustEmail = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.lblCustName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCountryCode = new System.Windows.Forms.ComboBox();
            this.grpbCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SF Pro Display", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "👤 Customer Registration";
            // 
            // grpbCustomer
            // 
            this.grpbCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpbCustomer.Controls.Add(this.label8);
            this.grpbCustomer.Controls.Add(this.cmbCountryCode);
            this.grpbCustomer.Controls.Add(this.lblCustPasswordStrength);
            this.grpbCustomer.Controls.Add(this.txtCustAddress);
            this.grpbCustomer.Controls.Add(this.lblCustAddress);
            this.grpbCustomer.Controls.Add(this.btnRegisterCustomer);
            this.grpbCustomer.Controls.Add(this.txtCustPhone);
            this.grpbCustomer.Controls.Add(this.txtCustConfirmPass);
            this.grpbCustomer.Controls.Add(this.txtCustPassword);
            this.grpbCustomer.Controls.Add(this.lblCustPhone);
            this.grpbCustomer.Controls.Add(this.txtCustEmail);
            this.grpbCustomer.Controls.Add(this.chkCustShowPassword);
            this.grpbCustomer.Controls.Add(this.lblConfirmCustPass);
            this.grpbCustomer.Controls.Add(this.lblCustPassword);
            this.grpbCustomer.Controls.Add(this.lblCustEmail);
            this.grpbCustomer.Controls.Add(this.txtCustName);
            this.grpbCustomer.Controls.Add(this.lblCustName);
            this.grpbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpbCustomer.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbCustomer.Location = new System.Drawing.Point(53, 86);
            this.grpbCustomer.Name = "grpbCustomer";
            this.grpbCustomer.Size = new System.Drawing.Size(425, 645);
            this.grpbCustomer.TabIndex = 24;
            this.grpbCustomer.TabStop = false;
            this.grpbCustomer.Text = "Customer";
            // 
            // lblCustPasswordStrength
            // 
            this.lblCustPasswordStrength.AutoSize = true;
            this.lblCustPasswordStrength.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustPasswordStrength.Location = new System.Drawing.Point(27, 517);
            this.lblCustPasswordStrength.Name = "lblCustPasswordStrength";
            this.lblCustPasswordStrength.Size = new System.Drawing.Size(0, 20);
            this.lblCustPasswordStrength.TabIndex = 29;
            // 
            // txtCustAddress
            // 
            this.txtCustAddress.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustAddress.Location = new System.Drawing.Point(31, 157);
            this.txtCustAddress.Multiline = true;
            this.txtCustAddress.Name = "txtCustAddress";
            this.txtCustAddress.Size = new System.Drawing.Size(366, 92);
            this.txtCustAddress.TabIndex = 25;
            // 
            // lblCustAddress
            // 
            this.lblCustAddress.AutoSize = true;
            this.lblCustAddress.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustAddress.Location = new System.Drawing.Point(27, 133);
            this.lblCustAddress.Name = "lblCustAddress";
            this.lblCustAddress.Size = new System.Drawing.Size(68, 20);
            this.lblCustAddress.TabIndex = 24;
            this.lblCustAddress.Text = "Address";
            // 
            // btnRegisterCustomer
            // 
            this.btnRegisterCustomer.BackColor = System.Drawing.Color.DarkGreen;
            this.btnRegisterCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterCustomer.FlatAppearance.BorderSize = 0;
            this.btnRegisterCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterCustomer.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterCustomer.ForeColor = System.Drawing.Color.White;
            this.btnRegisterCustomer.Location = new System.Drawing.Point(107, 568);
            this.btnRegisterCustomer.Name = "btnRegisterCustomer";
            this.btnRegisterCustomer.Size = new System.Drawing.Size(220, 45);
            this.btnRegisterCustomer.TabIndex = 23;
            this.btnRegisterCustomer.Text = "Register As Customer";
            this.btnRegisterCustomer.UseVisualStyleBackColor = false;
            this.btnRegisterCustomer.Click += new System.EventHandler(this.btnRegisterCustomer_Click);
            // 
            // txtCustPhone
            // 
            this.txtCustPhone.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustPhone.Location = new System.Drawing.Point(170, 287);
            this.txtCustPhone.Name = "txtCustPhone";
            this.txtCustPhone.Size = new System.Drawing.Size(227, 28);
            this.txtCustPhone.TabIndex = 22;
            // 
            // txtCustConfirmPass
            // 
            this.txtCustConfirmPass.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustConfirmPass.Location = new System.Drawing.Point(31, 482);
            this.txtCustConfirmPass.Name = "txtCustConfirmPass";
            this.txtCustConfirmPass.PasswordChar = '•';
            this.txtCustConfirmPass.Size = new System.Drawing.Size(366, 28);
            this.txtCustConfirmPass.TabIndex = 21;
            // 
            // txtCustPassword
            // 
            this.txtCustPassword.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustPassword.Location = new System.Drawing.Point(31, 421);
            this.txtCustPassword.Name = "txtCustPassword";
            this.txtCustPassword.PasswordChar = '•';
            this.txtCustPassword.Size = new System.Drawing.Size(366, 28);
            this.txtCustPassword.TabIndex = 20;
            this.txtCustPassword.TextChanged += new System.EventHandler(this.txtCustPassword_TextChanged);
            // 
            // lblCustPhone
            // 
            this.lblCustPhone.AutoSize = true;
            this.lblCustPhone.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustPhone.Location = new System.Drawing.Point(166, 264);
            this.lblCustPhone.Name = "lblCustPhone";
            this.lblCustPhone.Size = new System.Drawing.Size(55, 20);
            this.lblCustPhone.TabIndex = 17;
            this.lblCustPhone.Text = "Phone";
            // 
            // txtCustEmail
            // 
            this.txtCustEmail.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustEmail.Location = new System.Drawing.Point(31, 354);
            this.txtCustEmail.Name = "txtCustEmail";
            this.txtCustEmail.Size = new System.Drawing.Size(366, 28);
            this.txtCustEmail.TabIndex = 19;
            // 
            // chkCustShowPassword
            // 
            this.chkCustShowPassword.AutoSize = true;
            this.chkCustShowPassword.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustShowPassword.Location = new System.Drawing.Point(254, 516);
            this.chkCustShowPassword.Name = "chkCustShowPassword";
            this.chkCustShowPassword.Size = new System.Drawing.Size(143, 24);
            this.chkCustShowPassword.TabIndex = 18;
            this.chkCustShowPassword.Text = "Show password";
            this.chkCustShowPassword.UseVisualStyleBackColor = true;
            this.chkCustShowPassword.CheckedChanged += new System.EventHandler(this.chkCustShowPassword_CheckedChanged);
            // 
            // lblConfirmCustPass
            // 
            this.lblConfirmCustPass.AutoSize = true;
            this.lblConfirmCustPass.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmCustPass.Location = new System.Drawing.Point(27, 459);
            this.lblConfirmCustPass.Name = "lblConfirmCustPass";
            this.lblConfirmCustPass.Size = new System.Drawing.Size(138, 20);
            this.lblConfirmCustPass.TabIndex = 16;
            this.lblConfirmCustPass.Text = "Confirm Password";
            // 
            // lblCustPassword
            // 
            this.lblCustPassword.AutoSize = true;
            this.lblCustPassword.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustPassword.Location = new System.Drawing.Point(27, 398);
            this.lblCustPassword.Name = "lblCustPassword";
            this.lblCustPassword.Size = new System.Drawing.Size(78, 20);
            this.lblCustPassword.TabIndex = 15;
            this.lblCustPassword.Text = "Password";
            // 
            // lblCustEmail
            // 
            this.lblCustEmail.AutoSize = true;
            this.lblCustEmail.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustEmail.Location = new System.Drawing.Point(27, 331);
            this.lblCustEmail.Name = "lblCustEmail";
            this.lblCustEmail.Size = new System.Drawing.Size(47, 20);
            this.lblCustEmail.TabIndex = 14;
            this.lblCustEmail.Text = "Email";
            // 
            // txtCustName
            // 
            this.txtCustName.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustName.Location = new System.Drawing.Point(31, 90);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(366, 28);
            this.txtCustName.TabIndex = 13;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.Location = new System.Drawing.Point(27, 67);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(80, 20);
            this.lblCustName.TabIndex = 12;
            this.lblCustName.Text = "Full Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Country Code";
            // 
            // cmbCountryCode
            // 
            this.cmbCountryCode.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountryCode.FormattingEnabled = true;
            this.cmbCountryCode.Location = new System.Drawing.Point(30, 288);
            this.cmbCountryCode.Name = "cmbCountryCode";
            this.cmbCountryCode.Size = new System.Drawing.Size(112, 28);
            this.cmbCountryCode.TabIndex = 30;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 743);
            this.Controls.Add(this.grpbCustomer);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("SF Pro Display", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.grpbCustomer.ResumeLayout(false);
            this.grpbCustomer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpbCustomer;
        private System.Windows.Forms.Button btnRegisterCustomer;
        private System.Windows.Forms.TextBox txtCustPhone;
        private System.Windows.Forms.TextBox txtCustConfirmPass;
        private System.Windows.Forms.TextBox txtCustPassword;
        private System.Windows.Forms.TextBox txtCustEmail;
        private System.Windows.Forms.CheckBox chkCustShowPassword;
        private System.Windows.Forms.Label lblCustPhone;
        private System.Windows.Forms.Label lblConfirmCustPass;
        private System.Windows.Forms.Label lblCustPassword;
        private System.Windows.Forms.Label lblCustEmail;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.Label lblCustAddress;
        private System.Windows.Forms.TextBox txtCustAddress;
        private System.Windows.Forms.Label lblCustPasswordStrength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCountryCode;
    }
}