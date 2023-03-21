using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oven_Application.login
{
    public partial class frmLogin : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        private string _ID;
        private string _PASSWORD;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblBit.Text = oGlobal.ApplicationBitVersion.ToString() + "Bit";
            _ID = Properties.Settings.Default.ID;
            _PASSWORD = Properties.Settings.Default.PASSWORD;

            tboxID.Text = _ID;
            tboxPassword.Text = _PASSWORD;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            fCheckLogin();
        }

        private void btnPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fCheckLogin();
            }
        }

        // 로그인창 최소화 버튼
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // 로그인창 종료 버튼
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 로그인 창 무빙
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

        private void fCheckLogin()
        {
            _ID = tboxID.Text;
            _PASSWORD = tboxPassword.Text;

            // Application과 OS Bit Version 체크
            if (csLogin.applicationAndOsBitVersionCheck())
            {
                try
                {
                    bool loginSuccess = csLogin.CheckLogin(_ID, _PASSWORD);
                    if (loginSuccess)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Login인 중. 문제가 발생했습니다.");
                }
            }
            else
            {
                MessageBox.Show("Application 버전이 Window 버전과 맞지 않습니다.");
            }
        }

    }
}
