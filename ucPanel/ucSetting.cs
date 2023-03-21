using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oven_Application.ucPanel
{
    public partial class ucSetting : UserControl
    {


        private bool saveCheckBool = false;

        // 나중에 버튼을 분리하든지 그냥 이대로 가든지 

        private bool _hookingProcessContinue = false;
        private bool _uploadingProcessContinue = false;

        public ucSetting()
        {
            InitializeComponent();
        }

        private void ucSetting_Load(object sender, EventArgs e)
        {
            initialSettingStore(); // Store 정보 가져오기
            initialSettingMachine(); // Machine 정보 가져오기
            findMachineDrivePath(); // Drive Path 정보 가져오기
            initialSettingPort(); // Port 초기값
            initialSettingBuadRate(); // BaudaRate 초기값

        }

        // 선택한 Store 목록이 변경되었을 때,
        private void cboxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            oSetting.SelectedStoreName = cboxSettingStore.SelectedItem.ToString();
            initialSettingMachine();
            findMachineDrivePath();
        }

        private void btnSettingSave_Click(object sender, EventArgs e)
        {
            // Store 비어있는지 확인
            // Machine 비어있는지 확인
            // POS Port Check
            // POS BaudRate Check
            // Print Port Check
            // Print BaudRate Check
            saveCheckBool = checkSettingSave();
            if (saveCheckBool)
            {
                MessageBox.Show("저장되었습니다.");
            }
        }

        private async void btnSettingExecute_Click(object sender, EventArgs e)
        {
            if (!_hookingProcessContinue)
            {
                // 초기화
                btnSettingExecuteInitialize();
                lbLog.Items.Clear();

                // Setting 유효성 검증
                // Virtual Serial Port Check
                saveCheckBool = checkSettingSave();
                if (saveCheckBool)
                {
                    btnSettingExecute.Enabled = false;
                    await SearchVP();
                    if (oSetting.IfExistVirtualProgram)
                    {
                        await SearchEnv();
                        if (oSetting.IfExistEnvPath)
                        {
                            await SearchSerialPort();
                            if (oSetting.IfConnectionSerialPortSuccess)
                            {
                                // Google Drive Path 확인
                                if (!string.IsNullOrEmpty(oSetting.MachineDrivePath))
                                {
                                    lbLog.Items.Add(oSetting.MachineDrivePath);
                                    lblCheckSuccess_Dispatcher(lblDrive);
                                    oSetting.IfReadyToHooking = true;
                                }
                                else
                                {
                                    lblCheckFailed_Dispatcher(lblDrive);
                                }
                            }
                        }
                    }
                }

                if (oSetting.IfReadyToHooking)
                {
                    lbLog.Items.Add("======= Ready To Hook ======= ");

                    // Hooking 실행
                    Hooking();
                    // await Uploading
                    Uploading();
                }
                else
                {
                    lbLog.Items.Add("======= Failed To Hook ======= ");
                }
            }
            else
            {
                MessageBox.Show("이미 실행 중 입니다.");
            }


            btnSettingExecute.Enabled = true;
        }

        private void btnSettingPause_Click(object sender, EventArgs e)
        {
            // 모든 Serial Port Close
            _hookingProcessContinue = false;
            _uploadingProcessContinue = false;

            lbLog.Items.Add("======= Puase Process ======= ");

            // 모든 Signal 초기화

        }

        private void btnSettingExecuteInitialize()
        {
            oSetting.IfExistVirtualProgram = false;
            oSetting.IfExistEnvPath = false;
            oSetting.IfConnectionSerialPortSuccess = false;
            oSetting.IfReadyToHooking = false;
            _hookingProcessContinue = false;
            _uploadingProcessContinue = false;
        }



        #region Check the validation of Setting Value 
        private bool checkSettingSave()
        {
            oSetting.SelectedStoreName = cboxSettingStore.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(oSetting.SelectedStoreName))
            {
                oSetting.SelectedMachineName = cboxSettingMachine.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(oSetting.SelectedMachineName))
                {
                    oSetting.SerialPort = tboxPosPort.Text.ToString();
                    if (!string.IsNullOrEmpty(oSetting.SerialPort) && checkSerialPortString(oSetting.SerialPort))
                    {
                        oSetting.SerialBaudRate = cboxPortBaudrate.SelectedItem.ToString();
                        if (!string.IsNullOrEmpty(oSetting.SerialBaudRate))
                        {
                            oSetting.PrinterPort = tboxPrinterPort.Text.ToString();
                            if (!string.IsNullOrEmpty(oSetting.PrinterPort) && checkSerialPortString(oSetting.PrinterPort))
                            {
                                oSetting.PrinterBaudRate = cboxPrinterBaudrate.SelectedItem.ToString();
                                if (!string.IsNullOrEmpty(oSetting.PrinterBaudRate))
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("BaudRate가 선택되지 않았습니다.");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Port를 입력하지 않았습니다.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("BaudRate가 선택되지 않았습니다.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Port를 입력하지 않았습니다.");
                    }
                }
                else
                {
                    MessageBox.Show("기기가 선택되지 않았습니다.");
                }
            }
            else
            {
                MessageBox.Show("지점이 선택되지 않았습니다.");
            }
            return false;
        }

        private bool checkSerialPortString(string serialPort)
        {
            if (serialPort != null)
            {
                if ((serialPort.Length < 4))
                {
                    MessageBox.Show("적절한 Port를 입력 바랍니다. (예 : COM1)");
                    return false;
                }
                else
                {
                    string subStr = serialPort.Substring(0, 3);
                    if (!subStr.Equals("COM"))
                    {
                        MessageBox.Show("대문자로 Port를 입력 바랍니다. (예 : COM1)");
                        return false;
                    }
                    else
                    {
                        string subInt = serialPort.Substring(3, 1);
                        if (int.TryParse(subInt, out int val))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Port 값을 입력 바랍니다.");
                return false;
            }
        }
        #endregion


        #region Store, Machine, Port, Baudrate 설정
        private void initialSettingPort()
        {
            tboxPosPort.Text = oSetting.SerialPort.ToString();
            tboxPrinterPort.Text = oSetting.PrinterPort.ToString();
        }

        private void initialSettingBuadRate()
        {
            // Baudrate List Upload
            oSetting.getBaudrate();
            foreach (string s in oSetting._baudRateList)
            {
                cboxPortBaudrate.Items.Add(s);
                cboxPrinterBaudrate.Items.Add(s);
            }

            if ((!string.IsNullOrEmpty(oSetting.SerialBaudRate)))
            {
                cboxPortBaudrate.SelectedItem = oSetting.SerialBaudRate;
            }
            else
            {
                cboxPortBaudrate.SelectedIndex = 6;
                oSetting.SerialBaudRate = cboxPortBaudrate.SelectedItem.ToString();
            }

            if ((!string.IsNullOrEmpty(oSetting.PrinterBaudRate)))
            {
                cboxPrinterBaudrate.SelectedItem = oSetting.PrinterBaudRate;
            }
            else
            {
                cboxPrinterBaudrate.SelectedIndex = 6;
                oSetting.PrinterBaudRate = cboxPrinterBaudrate.SelectedItem.ToString();
            }
        }

        private void initialSettingStore()
        {
            // Store 정보 가져오기
            oSetting.getStoreInfo();
            oSetting.parsingStoreInfo();

            // Combo Box에 넣기
            foreach (string str in oSetting._storeNameList)
            {
                cboxSettingStore.Items.Add(str);
            }
            if (cboxSettingStore.Items.Count > 0)
            {
                if ((!string.IsNullOrEmpty(oSetting.SelectedStoreName)) && (oSetting._storeNameList.Contains(oSetting.SelectedStoreName)))
                {
                    cboxSettingStore.SelectedItem = oSetting.SelectedStoreName;
                }
                else
                {
                    cboxSettingStore.SelectedIndex = 0;
                    oSetting.SelectedStoreName = cboxSettingStore.SelectedItem.ToString();
                }
            }
        }

        private void initialSettingMachine()
        {
            // Machine 정보 가져오기 (현재 선택된 스토어의 ID를 가져와야한다)
            oSetting.getMachineInfo(oSetting._storeNameIdDict[oSetting.SelectedStoreName]);
            oSetting.parsingMachineInfo();

            if (!string.IsNullOrEmpty(oSetting.SelectedStoreName))
            {

                cboxSettingMachine.Items.Clear();
                cboxSettingMachine.Text = "";
                foreach (string str in oSetting._machineNameList)
                {
                    cboxSettingMachine.Items.Add(str);
                }
                if (cboxSettingMachine.Items.Count > 0)
                {

                    if ((!string.IsNullOrEmpty(oSetting.SelectedMachineName)) && (oSetting._machineNameList.Contains(oSetting.SelectedMachineName)))
                    {
                        cboxSettingMachine.SelectedItem = oSetting.SelectedMachineName;
                    }
                    else
                    {
                        cboxSettingMachine.SelectedIndex = 0;
                        oSetting.SelectedMachineName = cboxSettingMachine.SelectedItem.ToString();
                    }
                }
            }
        }

        private void findMachineDrivePath()
        {
            if (!string.IsNullOrEmpty(oSetting.SelectedMachineName))
            {
                int _id = oSetting._machineNameIdDict[oSetting.SelectedMachineName];
                oSetting.MachineDrivePath = oSetting._machineDrivePathDict[_id];
            }
            else
            {
                oSetting.MachineDrivePath = string.Empty;
            }
        }



        #endregion


    }
}
