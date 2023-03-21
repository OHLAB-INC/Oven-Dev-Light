namespace Oven_Application.ucPanel
{
    partial class ucReceipt
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFindFolder = new Guna.UI2.WinForms.Guna2Button();
            this.lbReceiptsList = new System.Windows.Forms.ListBox();
            this.rtbReceipt = new Guna.UI2.WinForms.Guna2TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnFindFolder
            // 
            this.btnFindFolder.BorderRadius = 10;
            this.btnFindFolder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFindFolder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFindFolder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFindFolder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFindFolder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFindFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFindFolder.ForeColor = System.Drawing.Color.Gray;
            this.btnFindFolder.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnFindFolder.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnFindFolder.Location = new System.Drawing.Point(25, 67);
            this.btnFindFolder.Name = "btnFindFolder";
            this.btnFindFolder.Size = new System.Drawing.Size(138, 34);
            this.btnFindFolder.TabIndex = 35;
            this.btnFindFolder.Text = "영수증 찾기";
            this.btnFindFolder.Click += new System.EventHandler(this.btnFindFolder_Click);
            // 
            // lbReceiptsList
            // 
            this.lbReceiptsList.BackColor = System.Drawing.Color.White;
            this.lbReceiptsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbReceiptsList.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbReceiptsList.FormattingEnabled = true;
            this.lbReceiptsList.ItemHeight = 15;
            this.lbReceiptsList.Location = new System.Drawing.Point(25, 128);
            this.lbReceiptsList.Name = "lbReceiptsList";
            this.lbReceiptsList.Size = new System.Drawing.Size(239, 330);
            this.lbReceiptsList.TabIndex = 36;
            this.lbReceiptsList.SelectedIndexChanged += new System.EventHandler(this.lbReceiptsList_SelectedIndexChanged);
            // 
            // rtbReceipt
            // 
            this.rtbReceipt.BorderRadius = 5;
            this.rtbReceipt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbReceipt.DefaultText = "";
            this.rtbReceipt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.rtbReceipt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.rtbReceipt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.rtbReceipt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.rtbReceipt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rtbReceipt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtbReceipt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rtbReceipt.Location = new System.Drawing.Point(285, 67);
            this.rtbReceipt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbReceipt.Multiline = true;
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.PasswordChar = '\0';
            this.rtbReceipt.PlaceholderText = "";
            this.rtbReceipt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rtbReceipt.SelectedText = "";
            this.rtbReceipt.Size = new System.Drawing.Size(427, 397);
            this.rtbReceipt.TabIndex = 37;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ucReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.rtbReceipt);
            this.Controls.Add(this.lbReceiptsList);
            this.Controls.Add(this.btnFindFolder);
            this.Name = "ucReceipt";
            this.Size = new System.Drawing.Size(748, 495);
            this.Load += new System.EventHandler(this.ucReceipt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnFindFolder;
        private System.Windows.Forms.ListBox lbReceiptsList;
        private Guna.UI2.WinForms.Guna2TextBox rtbReceipt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
