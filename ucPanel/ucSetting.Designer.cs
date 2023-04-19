namespace Oven_Application.ucPanel
{
    partial class ucSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindFolder = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxSettingStore = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboxSettingMachine = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxPortBaudrate = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tboxPosPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.tboxPrinterPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboxPrinterBaudrate = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbPrinter = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btnSettingExecute = new Guna.UI2.WinForms.Guna2Button();
            this.btnSettingPause = new Guna.UI2.WinForms.Guna2Button();
            this.lblDrive = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblEnv = new System.Windows.Forms.Label();
            this.lblVPC = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label1.Location = new System.Drawing.Point(36, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "지점 선택";
            // 
            // btnFindFolder
            // 
            this.btnFindFolder.BorderRadius = 5;
            this.btnFindFolder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFindFolder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFindFolder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFindFolder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFindFolder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFindFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFindFolder.ForeColor = System.Drawing.Color.Gray;
            this.btnFindFolder.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnFindFolder.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnFindFolder.Location = new System.Drawing.Point(211, 30);
            this.btnFindFolder.Name = "btnFindFolder";
            this.btnFindFolder.Size = new System.Drawing.Size(75, 23);
            this.btnFindFolder.TabIndex = 36;
            this.btnFindFolder.Text = "저장";
            this.btnFindFolder.Click += new System.EventHandler(this.btnSettingSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label2.Location = new System.Drawing.Point(38, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 37;
            this.label2.Text = "지점";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(38, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.label3.TabIndex = 38;
            this.label3.Text = "기기";
            // 
            // cboxSettingStore
            // 
            this.cboxSettingStore.BackColor = System.Drawing.Color.Transparent;
            this.cboxSettingStore.BorderRadius = 5;
            this.cboxSettingStore.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxSettingStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSettingStore.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxSettingStore.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxSettingStore.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cboxSettingStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboxSettingStore.ItemHeight = 26;
            this.cboxSettingStore.ItemsAppearance.BackColor = System.Drawing.Color.White;
            this.cboxSettingStore.ItemsAppearance.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboxSettingStore.ItemsAppearance.ForeColor = System.Drawing.Color.Black;
            this.cboxSettingStore.Location = new System.Drawing.Point(114, 90);
            this.cboxSettingStore.Name = "cboxSettingStore";
            this.cboxSettingStore.Size = new System.Drawing.Size(201, 32);
            this.cboxSettingStore.TabIndex = 39;
            this.cboxSettingStore.SelectedIndexChanged += new System.EventHandler(this.cboxStore_SelectedIndexChanged);
            // 
            // cboxSettingMachine
            // 
            this.cboxSettingMachine.BackColor = System.Drawing.Color.Transparent;
            this.cboxSettingMachine.BorderRadius = 5;
            this.cboxSettingMachine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxSettingMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSettingMachine.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxSettingMachine.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxSettingMachine.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cboxSettingMachine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboxSettingMachine.ItemHeight = 26;
            this.cboxSettingMachine.Location = new System.Drawing.Point(114, 134);
            this.cboxSettingMachine.Name = "cboxSettingMachine";
            this.cboxSettingMachine.Size = new System.Drawing.Size(201, 32);
            this.cboxSettingMachine.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label4.Location = new System.Drawing.Point(38, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "Baud Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label5.Location = new System.Drawing.Point(38, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label6.Location = new System.Drawing.Point(36, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 23);
            this.label6.TabIndex = 41;
            this.label6.Text = "POS Port";
            // 
            // cboxPortBaudrate
            // 
            this.cboxPortBaudrate.BackColor = System.Drawing.Color.Transparent;
            this.cboxPortBaudrate.BorderRadius = 5;
            this.cboxPortBaudrate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxPortBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPortBaudrate.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxPortBaudrate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxPortBaudrate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cboxPortBaudrate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboxPortBaudrate.ItemHeight = 20;
            this.cboxPortBaudrate.Location = new System.Drawing.Point(153, 279);
            this.cboxPortBaudrate.Name = "cboxPortBaudrate";
            this.cboxPortBaudrate.Size = new System.Drawing.Size(135, 26);
            this.cboxPortBaudrate.TabIndex = 44;
            // 
            // tboxPosPort
            // 
            this.tboxPosPort.BorderRadius = 5;
            this.tboxPosPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tboxPosPort.DefaultText = "";
            this.tboxPosPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tboxPosPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tboxPosPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tboxPosPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tboxPosPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxPosPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tboxPosPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxPosPort.Location = new System.Drawing.Point(153, 239);
            this.tboxPosPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxPosPort.Name = "tboxPosPort";
            this.tboxPosPort.PasswordChar = '\0';
            this.tboxPosPort.PlaceholderText = "";
            this.tboxPosPort.SelectedText = "";
            this.tboxPosPort.Size = new System.Drawing.Size(135, 26);
            this.tboxPosPort.TabIndex = 45;
            // 
            // tboxPrinterPort
            // 
            this.tboxPrinterPort.BorderRadius = 5;
            this.tboxPrinterPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tboxPrinterPort.DefaultText = "";
            this.tboxPrinterPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tboxPrinterPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tboxPrinterPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tboxPrinterPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tboxPrinterPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxPrinterPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tboxPrinterPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tboxPrinterPort.Location = new System.Drawing.Point(153, 385);
            this.tboxPrinterPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxPrinterPort.Name = "tboxPrinterPort";
            this.tboxPrinterPort.PasswordChar = '\0';
            this.tboxPrinterPort.PlaceholderText = "";
            this.tboxPrinterPort.SelectedText = "";
            this.tboxPrinterPort.Size = new System.Drawing.Size(135, 26);
            this.tboxPrinterPort.TabIndex = 50;
            // 
            // cboxPrinterBaudrate
            // 
            this.cboxPrinterBaudrate.BackColor = System.Drawing.Color.Transparent;
            this.cboxPrinterBaudrate.BorderRadius = 5;
            this.cboxPrinterBaudrate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxPrinterBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPrinterBaudrate.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxPrinterBaudrate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxPrinterBaudrate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cboxPrinterBaudrate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboxPrinterBaudrate.ItemHeight = 20;
            this.cboxPrinterBaudrate.Location = new System.Drawing.Point(153, 425);
            this.cboxPrinterBaudrate.Name = "cboxPrinterBaudrate";
            this.cboxPrinterBaudrate.Size = new System.Drawing.Size(135, 26);
            this.cboxPrinterBaudrate.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label7.Location = new System.Drawing.Point(38, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 48;
            this.label7.Text = "Baud Rate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label8.Location = new System.Drawing.Point(38, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "Port";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.label9.Location = new System.Drawing.Point(36, 344);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 23);
            this.label9.TabIndex = 46;
            this.label9.Text = "Printer Port";
            // 
            // cbPrinter
            // 
            this.cbPrinter.AutoSize = true;
            this.cbPrinter.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPrinter.CheckedState.BorderRadius = 3;
            this.cbPrinter.CheckedState.BorderThickness = 1;
            this.cbPrinter.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPrinter.Font = new System.Drawing.Font("굴림", 9F);
            this.cbPrinter.Location = new System.Drawing.Point(177, 348);
            this.cbPrinter.Name = "cbPrinter";
            this.cbPrinter.Size = new System.Drawing.Size(109, 19);
            this.cbPrinter.TabIndex = 51;
            this.cbPrinter.Text = "프린터 있음";
            this.cbPrinter.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbPrinter.UncheckedState.BorderRadius = 3;
            this.cbPrinter.UncheckedState.BorderThickness = 1;
            this.cbPrinter.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // btnSettingExecute
            // 
            this.btnSettingExecute.BorderRadius = 5;
            this.btnSettingExecute.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettingExecute.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettingExecute.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettingExecute.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettingExecute.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSettingExecute.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettingExecute.ForeColor = System.Drawing.Color.Gray;
            this.btnSettingExecute.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSettingExecute.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSettingExecute.Location = new System.Drawing.Point(514, 30);
            this.btnSettingExecute.Name = "btnSettingExecute";
            this.btnSettingExecute.Size = new System.Drawing.Size(75, 23);
            this.btnSettingExecute.TabIndex = 52;
            this.btnSettingExecute.Text = "실행";
            this.btnSettingExecute.Click += new System.EventHandler(this.btnSettingExecute_Click);
            // 
            // btnSettingPause
            // 
            this.btnSettingPause.BorderRadius = 5;
            this.btnSettingPause.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSettingPause.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSettingPause.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSettingPause.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSettingPause.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSettingPause.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettingPause.ForeColor = System.Drawing.Color.Gray;
            this.btnSettingPause.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnSettingPause.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSettingPause.Location = new System.Drawing.Point(634, 30);
            this.btnSettingPause.Name = "btnSettingPause";
            this.btnSettingPause.Size = new System.Drawing.Size(75, 23);
            this.btnSettingPause.TabIndex = 53;
            this.btnSettingPause.Text = "정지";
            this.btnSettingPause.Click += new System.EventHandler(this.btnSettingPause_Click);
            // 
            // lblDrive
            // 
            this.lblDrive.AutoSize = true;
            this.lblDrive.Location = new System.Drawing.Point(395, 240);
            this.lblDrive.Name = "lblDrive";
            this.lblDrive.Size = new System.Drawing.Size(15, 15);
            this.lblDrive.TabIndex = 77;
            this.lblDrive.Text = "-";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(395, 191);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(15, 15);
            this.lblPort.TabIndex = 76;
            this.lblPort.Text = "-";
            // 
            // lblEnv
            // 
            this.lblEnv.AutoSize = true;
            this.lblEnv.Location = new System.Drawing.Point(395, 145);
            this.lblEnv.Name = "lblEnv";
            this.lblEnv.Size = new System.Drawing.Size(15, 15);
            this.lblEnv.TabIndex = 75;
            this.lblEnv.Text = "-";
            // 
            // lblVPC
            // 
            this.lblVPC.AutoSize = true;
            this.lblVPC.Location = new System.Drawing.Point(395, 93);
            this.lblVPC.Name = "lblVPC";
            this.lblVPC.Size = new System.Drawing.Size(15, 15);
            this.lblVPC.TabIndex = 74;
            this.lblVPC.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(434, 237);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 20);
            this.label11.TabIndex = 71;
            this.label11.Text = "Google Drive Path Check";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(434, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 20);
            this.label12.TabIndex = 70;
            this.label12.Text = "Serial Port Check";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(434, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 20);
            this.label13.TabIndex = 69;
            this.label13.Text = "Env. Path Check";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(434, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(174, 20);
            this.label18.TabIndex = 68;
            this.label18.Text = "Virtual Program Check";
            // 
            // lbLog
            // 
            this.lbLog.BackColor = System.Drawing.Color.White;
            this.lbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbLog.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbLog.FormattingEnabled = true;
            this.lbLog.HorizontalScrollbar = true;
            this.lbLog.ItemHeight = 15;
            this.lbLog.Location = new System.Drawing.Point(393, 301);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(316, 150);
            this.lbLog.TabIndex = 78;
            // 
            // ucSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.lbLog);
            this.Controls.Add(this.lblDrive);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblEnv);
            this.Controls.Add(this.lblVPC);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnSettingPause);
            this.Controls.Add(this.btnSettingExecute);
            this.Controls.Add(this.cbPrinter);
            this.Controls.Add(this.tboxPrinterPort);
            this.Controls.Add(this.cboxPrinterBaudrate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tboxPosPort);
            this.Controls.Add(this.cboxPortBaudrate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboxSettingMachine);
            this.Controls.Add(this.cboxSettingStore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFindFolder);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucSetting";
            this.Size = new System.Drawing.Size(748, 495);
            this.Load += new System.EventHandler(this.ucSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnFindFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cboxSettingStore;
        private Guna.UI2.WinForms.Guna2ComboBox cboxSettingMachine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboxPortBaudrate;
        private Guna.UI2.WinForms.Guna2TextBox tboxPosPort;
        private Guna.UI2.WinForms.Guna2TextBox tboxPrinterPort;
        private Guna.UI2.WinForms.Guna2ComboBox cboxPrinterBaudrate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2CheckBox cbPrinter;
        private Guna.UI2.WinForms.Guna2Button btnSettingExecute;
        private Guna.UI2.WinForms.Guna2Button btnSettingPause;
        private System.Windows.Forms.Label lblDrive;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblEnv;
        private System.Windows.Forms.Label lblVPC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox lbLog;
    }
}
