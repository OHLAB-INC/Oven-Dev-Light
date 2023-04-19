using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Oven_Application
{
    public partial class MainForm : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        ucPanel.ucSetting ucSetting = new ucPanel.ucSetting();
        ucPanel.ucReceipt ucReceipt = new ucPanel.ucReceipt();
        ucPanel.ucChat ucChat = new ucPanel.ucChat();

        public MainForm()
        {
            InitializeComponent();
            this.SizeChanged += MainForm_Resize;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            oGlobal.LoadSettingValues();
            notifyIcon1.Visible = false;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucSetting);
            btnSetting.Checked = true;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            string aa = string.Empty;
            switch (btn.Name)
            {
                case "btnSetting":
                    panelMain.Controls.Clear();
                    panelMain.Controls.Add(ucSetting);
                    break;
                case "btnReceipt":
                    panelMain.Controls.Clear();
                    panelMain.Controls.Add(ucReceipt);
                    break;
                case "btnChat":
                    panelMain.Controls.Clear();
                    panelMain.Controls.Add(ucChat);
                    break;
            }
        }

        #region Moving Window
        // 메인창 최소화 버튼
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // 메인창 종료 버튼
        private void btnQuit_Click(object sender, EventArgs e)
        {
            oGlobal.SaveSettingValues();
            try
            {
                if (oGlobal.ntwStream != null)
                {
                    oGlobal.ntwStream.Close();
                }
                if (oGlobal.tcpClient != null)
                {
                    oGlobal.tcpClient.Close();
                }
                oGlobal.cts.Cancel();
            }catch (Exception ex)
            {

            }
            finally
            {
                Application.Exit(); // 추후 창만 닫는거로
            }
        }

        // 메인 창 무빙
        private void panelUpper_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panelUpper_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panelUpper_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        #endregion


        #region TrayIcon
        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucSetting);
            btnSetting.Checked = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.ContextMenuStrip.Visible = false;
            notifyIcon1.ContextMenuStrip.Close();

            oGlobal.SaveSettingValues();
            Application.Exit(); // 추후 창만 닫는거로
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon1.Visible = false;
                Show();
                panelMain.Controls.Clear();
                panelMain.Controls.Add(ucSetting);
                btnSetting.Checked = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                notifyIcon1.ContextMenuStrip.Show(new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1));
            }
        }
        #endregion
    }
}
