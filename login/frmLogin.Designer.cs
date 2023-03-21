namespace Oven_Application.login
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            this.panelLoginUpper = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMin = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnQuit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblBit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelLoginLower = new Guna.UI2.WinForms.Guna2Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.tboxID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelLoginUpper.SuspendLayout();
            this.panelLoginLower.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLoginUpper
            // 
            this.panelLoginUpper.Controls.Add(this.btnMin);
            this.panelLoginUpper.Controls.Add(this.btnQuit);
            this.panelLoginUpper.Controls.Add(this.lblBit);
            this.panelLoginUpper.Controls.Add(this.label5);
            this.panelLoginUpper.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoginUpper.Location = new System.Drawing.Point(0, 0);
            this.panelLoginUpper.Name = "panelLoginUpper";
            this.panelLoginUpper.Size = new System.Drawing.Size(462, 66);
            this.panelLoginUpper.TabIndex = 0;
            this.panelLoginUpper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelUpper_MouseDown);
            this.panelLoginUpper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUpper_MouseMove);
            this.panelLoginUpper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelUpper_MouseUp);
            // 
            // btnMin
            // 
            this.btnMin.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnMin.HoverState.Image = global::Oven_Application.Properties.Resources.minus;
            this.btnMin.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnMin.Image = global::Oven_Application.Properties.Resources.circle_yellow;
            this.btnMin.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMin.ImageRotate = 0F;
            this.btnMin.ImageSize = new System.Drawing.Size(22, 22);
            this.btnMin.Location = new System.Drawing.Point(350, 20);
            this.btnMin.Name = "btnMin";
            this.btnMin.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnMin.Size = new System.Drawing.Size(40, 34);
            this.btnMin.TabIndex = 39;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnQuit.HoverState.Image = global::Oven_Application.Properties.Resources.cross_mark;
            this.btnQuit.HoverState.ImageSize = new System.Drawing.Size(30, 30);
            this.btnQuit.Image = global::Oven_Application.Properties.Resources.circle_red;
            this.btnQuit.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnQuit.ImageRotate = 0F;
            this.btnQuit.ImageSize = new System.Drawing.Size(20, 20);
            this.btnQuit.Location = new System.Drawing.Point(396, 20);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnQuit.Size = new System.Drawing.Size(40, 34);
            this.btnQuit.TabIndex = 38;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblBit
            // 
            this.lblBit.AutoSize = true;
            this.lblBit.BackColor = System.Drawing.Color.Transparent;
            this.lblBit.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(137)))));
            this.lblBit.Location = new System.Drawing.Point(98, 27);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(16, 21);
            this.lblBit.TabIndex = 17;
            this.lblBit.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(137)))));
            this.label5.Location = new System.Drawing.Point(24, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "version";
            // 
            // panelLoginLower
            // 
            this.panelLoginLower.Controls.Add(this.label7);
            this.panelLoginLower.Controls.Add(this.label6);
            this.panelLoginLower.Controls.Add(this.label4);
            this.panelLoginLower.Controls.Add(this.btnLogin);
            this.panelLoginLower.Controls.Add(this.label3);
            this.panelLoginLower.Controls.Add(this.label1);
            this.panelLoginLower.Controls.Add(this.tboxPassword);
            this.panelLoginLower.Controls.Add(this.tboxID);
            this.panelLoginLower.Controls.Add(this.label2);
            this.panelLoginLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoginLower.Location = new System.Drawing.Point(0, 66);
            this.panelLoginLower.Name = "panelLoginLower";
            this.panelLoginLower.Size = new System.Drawing.Size(462, 499);
            this.panelLoginLower.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(223, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 21);
            this.label7.TabIndex = 37;
            this.label7.Text = "|";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(137)))));
            this.label6.Location = new System.Drawing.Point(261, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 21);
            this.label6.TabIndex = 36;
            this.label6.Text = "비밀번호 재설정";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(29)))), ((int)(((byte)(137)))));
            this.label4.Location = new System.Drawing.Point(120, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 21);
            this.label4.TabIndex = 35;
            this.label4.Text = "오븐계정 찾기";
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 10;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.Gray;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnLogin.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(142, 350);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 45);
            this.btnLogin.TabIndex = 33;
            this.btnLogin.Text = "로그인";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(98, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 21);
            this.label3.TabIndex = 32;
            this.label3.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label1.Location = new System.Drawing.Point(98, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "Login";
            // 
            // tboxPassword
            // 
            this.tboxPassword.BorderRadius = 15;
            this.tboxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tboxPassword.DefaultText = "";
            this.tboxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tboxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tboxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tboxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tboxPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tboxPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxPassword.Location = new System.Drawing.Point(117, 276);
            this.tboxPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.PasswordChar = '*';
            this.tboxPassword.PlaceholderText = "Password";
            this.tboxPassword.SelectedText = "";
            this.tboxPassword.Size = new System.Drawing.Size(229, 34);
            this.tboxPassword.TabIndex = 29;
            this.tboxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnPassword_KeyDown);
            // 
            // tboxID
            // 
            this.tboxID.BorderRadius = 15;
            this.tboxID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tboxID.DefaultText = "";
            this.tboxID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tboxID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tboxID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tboxID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tboxID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tboxID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxID.Location = new System.Drawing.Point(117, 192);
            this.tboxID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxID.Name = "tboxID";
            this.tboxID.PasswordChar = '\0';
            this.tboxID.PlaceholderText = "ID";
            this.tboxID.SelectedText = "";
            this.tboxID.Size = new System.Drawing.Size(229, 34);
            this.tboxID.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(462, 64);
            this.label2.TabIndex = 27;
            this.label2.Text = "O\'ven";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(462, 565);
            this.Controls.Add(this.panelLoginLower);
            this.Controls.Add(this.panelLoginUpper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panelLoginUpper.ResumeLayout(false);
            this.panelLoginUpper.PerformLayout();
            this.panelLoginLower.ResumeLayout(false);
            this.panelLoginLower.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel panelLoginLower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tboxPassword;
        private Guna.UI2.WinForms.Guna2TextBox tboxID;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel panelLoginUpper;
        private System.Windows.Forms.Label lblBit;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2ImageButton btnQuit;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ImageButton btnMin;
    }
}