using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oven_Application.ucPanel
{
    public partial class ucReceipt : UserControl
    {
        private string _folderPath = string.Empty;

        public ucReceipt()
        {
            InitializeComponent();
        }


        private void ucReceipt_Load(object sender, EventArgs e)
        {
            string[] paths = { Application.StartupPath, "receipts", oSetting.SelectedStoreName, oSetting.SelectedMachineName };
            string tempSavePath = Path.Combine(paths);

            if (Directory.Exists(tempSavePath))
            {
                openFileDialog1.InitialDirectory = tempSavePath;
            }
            else
            {
                openFileDialog1.InitialDirectory = Application.StartupPath;
            }
        }

        private void btnFindFolder_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Folders|*.txt";
            openFileDialog1.FileName = "영수증을 선택하세요";
            openFileDialog1.ValidateNames = false;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.CheckPathExists = true;

            // Show the dialog and get the result
            DialogResult result = openFileDialog1.ShowDialog();

            // If the user clicked OK
            if (result == DialogResult.OK)
            {
                // TODO: Do something with the selected file
                _folderPath = Path.GetDirectoryName(openFileDialog1.FileName);

                // Get a list of all files in the selected folder
                string[] files = Directory.GetFiles(_folderPath);

                // Display the list of files in a ListBox
                lbReceiptsList.Items.Clear();
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        lbReceiptsList.Items.Add(fileName);
                    }
                }
            }
        }

        private void lbReceiptsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFileName = lbReceiptsList.SelectedItem.ToString();
            try
            {
                if (!string.IsNullOrEmpty(_folderPath))
                {
                    string[] paths = { _folderPath, selectedFileName };
                    string tempSavePath = Path.Combine(paths);

                    StringBuilder builder = new StringBuilder();
                    string readfile = string.Empty;
                    try
                    {

                        foreach (var line in File.ReadLines(tempSavePath))
                        {
                            builder.AppendLine(line);
                        }
                        readfile = builder.ToString();
                    }
                    catch (Exception ex) { }

                    if (!string.IsNullOrEmpty(readfile))
                    {
                        string aa = readfile.Replace("\0", ""); // 뿌려줄때 string에서 생략 되버린다
                        rtbReceipt.Text = aa;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("파일이 존재하지 않습니다.");
            }
        }
    }
}
