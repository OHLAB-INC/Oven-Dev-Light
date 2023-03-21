using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Oven_Application.ucPanel
{
    public partial class ucSetting : UserControl
    {
        private static List<string> _drives = new List<string>(); // Drive List
        private static List<string> _directories = new List<string>(); // Directory List
        private static List<string> _envList = new List<string>(); // Environment Path

        #region Task Function

        /// <summary>
        /// Virtual Serial Port Program을 찾기 위한 Task 함수
        /// </summary>
        /// <returns></returns>
        public async Task SearchVP()
        {
            await Task.Run(() =>
            {
                // Properties에 저장되어있는 경로 먼저
                if (!string.IsNullOrEmpty(oSetting.ProgramNamePath))
                {
                    FileSearch(oSetting.ProgramNamePath);
                }

                // Properties에 저장되어있는 경로에 없을 경우
                if (_directories.Count == 0)
                {
                    string currentDirectory = Application.StartupPath;
                    DirSearch(currentDirectory);
                    if (_directories.Count == 0)
                    {
                        // If not exists Check All Directory
                        DriveSearch();
                        foreach (string drive in _drives)
                        {
                            DirSearch(drive);
                        }
                    }
                }
                if (_directories.Count > 0)
                {
                    // setup.exe가 있을 경우,
                    oSetting.ProgramNamePath = _directories[0].ToString();
                    oSetting.IfExistVirtualProgram = true;

                    lbLog_Dispatcher(oSetting.ProgramNamePath);
                    lblCheckSuccess_Dispatcher(lblVPC);
                }
                else
                {
                    // setup.exe가 없을 경우,
                    oSetting.IfExistVirtualProgram = false;
                    lblCheckFailed_Dispatcher(lblVPC);
                }
            });
        }

        private async Task SearchEnv()
        {
            await Task.Run(() =>
            {
                // oSetting.ProgramNamePath가 환경변수에 설정되어있는지 확인
                // 없으면 등록
                // 재확인 후 있으면 true, 없으면 false
                if (CheckEnvList())
                {
                    // 있으면 그냥 Pass
                    oSetting.IfExistEnvPath = true;
                }
                else
                {
                    //환경 변수 등록
                    Environment.SetEnvironmentVariable(oSetting.EnvName, oSetting.ProgramNamePath);
                    oSetting.IfExistEnvPath = CheckEnvList();
                }

                if (oSetting.IfExistEnvPath)
                {
                    lblCheckSuccess_Dispatcher(lblEnv);
                }
                else
                {
                    lblCheckFailed_Dispatcher(lblEnv);
                }
            });
        }


        private async Task SearchSerialPort()
        {
            await Task.Run(() =>
            {
                string res = CheckSerialPortList();

                if (!string.IsNullOrEmpty(res))
                {
                    if (res == "retry")
                    {
                        // retry면 새롭게 Port를 생성해야한다.
                        string dummyString = ExecuteSetupcExe("install PortName=COM# PortName=COM#");
                        string resTry = CheckSerialPortList();
                        if (!string.IsNullOrEmpty(resTry))
                        {
                            if (resTry == "retry")
                            {
                                oSetting.IfConnectionSerialPortSuccess = false;
                            }
                            else
                            {
                                if (cbPrinter.Checked)
                                {
                                    if (fTestPrinterPortConnection())
                                    {
                                        oSetting.PairSerialPort = resTry;
                                        oSetting.IfConnectionSerialPortSuccess = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Printer Port가 이미 사용 중이거나 존재하지 않습니다.");
                                    }
                                }
                                else
                                {
                                    oSetting.PairSerialPort = resTry;
                                    oSetting.IfConnectionSerialPortSuccess = true;
                                }
                            }
                        }
                        else
                        {
                            oSetting.IfConnectionSerialPortSuccess = false;
                        }
                    }
                    else
                    {
                        if (cbPrinter.Checked)
                        {
                            if (fTestPrinterPortConnection())
                            {
                                oSetting.PairSerialPort = res;
                                oSetting.IfConnectionSerialPortSuccess = true;
                            }
                            else
                            {
                                MessageBox.Show("Printer Port가 이미 사용 중이거나 존재하지 않습니다.");
                            }
                        }
                        else
                        {
                            oSetting.PairSerialPort = res;
                            oSetting.IfConnectionSerialPortSuccess = true;
                        }
                    }
                }
                else
                {
                    oSetting.IfConnectionSerialPortSuccess = false;
                }

                if (oSetting.IfConnectionSerialPortSuccess)
                {
                    lbLog_Dispatcher($"Serial Port : {oSetting.SerialPort}");
                    lbLog_Dispatcher($"Paired Serial Port : {oSetting.PairSerialPort}");
                    lbLog_Dispatcher($"Printer Serial Port : {oSetting.PrinterPort}");
                    lblCheckSuccess_Dispatcher(lblPort);
                }
                else
                {
                    lblCheckFailed_Dispatcher(lblPort);
                }
            });
        }

        private async Task Hooking()
        {

            await Task.Run(() => {
                lbLog_Dispatcher("Hooking Process ongoing");
                // Serial Port Information Setting
                SerialPort serialPort = new SerialPort(oSetting.PairSerialPort); // 여기에 실제로 PairSerialPort가 들어와야한다. Redirection이기 때문
                serialPort.BaudRate = Int32.Parse(oSetting.SerialBaudRate);
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.DataBits = 8;
                serialPort.Handshake = Handshake.None;
                serialPort.RtsEnable = true;

                SerialPort printerPort = new SerialPort(oSetting.PrinterPort); // 여기에 실제로 PairSerialPort가 들어와야한다. Redirection이기 때문
                printerPort.BaudRate = Int32.Parse(oSetting.PrinterBaudRate);
                printerPort.Parity = Parity.None;
                printerPort.StopBits = StopBits.One;
                printerPort.DataBits = 8;
                printerPort.Handshake = Handshake.None;
                printerPort.RtsEnable = true;
                if (!cbPrinter.Checked)
                { // Printer 없을 경우,
                    printerPort.WriteTimeout = 500;
                }

                try { serialPort.Open(); }
                catch { MessageBox.Show("Serial Port가 사용 중에 있습니다."); }

                try { printerPort.Open(); }
                catch { MessageBox.Show("Printer Port가 사용 중에 있습니다."); }

                if (serialPort.IsOpen && printerPort.IsOpen)
                {
                    _hookingProcessContinue = true;
                }

                while (_hookingProcessContinue)
                {
                    string message = string.Empty;
                    try
                    {
                        while (serialPort.BytesToRead > 0)
                        {
                            message += serialPort.ReadExisting();
                        }
                    }
                    catch (IOException) { }
                    catch (Exception e) { MessageBox.Show(e.Message); }
                    finally
                    {
                        if (!string.IsNullOrEmpty(message))
                        {
                            //lbLog_Dispatcher(message);
                            string savePathTemp = GetSaveFolderPath("temp");
                            string savePathReceipts = GetSaveFolderPath("receipts");

                            string dateTT = DateTime.Now.ToString("yyyyMMddhhmmss");
                            string FileName = $"{oSetting.SelectedStoreName}_{oSetting.SelectedMachineName}_{dateTT}.txt";

                            string[] pathsTemp = { savePathTemp, FileName };
                            string totalSavePathTemp = Path.Combine(pathsTemp);

                            string[] pathsReceipts = { savePathReceipts, FileName };
                            string totalSavePathReceipts = Path.Combine(pathsReceipts);

                            System.IO.File.WriteAllText(totalSavePathTemp, message, Encoding.UTF8);
                            System.IO.File.WriteAllText(totalSavePathReceipts, message, Encoding.UTF8);

                            try
                            {
                                printerPort.Write(message);
                            }
                            catch (IOException) { }
                            catch (TimeoutException) { }

                            lbLog_Dispatcher($"({dateTT})영수증 주문이 들어왔습니다. ");
                        }
                    }
                    // -> 녹색 불로 대체
                    Thread.Sleep(500);
                }

                if (!_hookingProcessContinue)
                {
                    // Serial Port 종료
                    serialPort.Close();
                    printerPort.Close();
                }
            });
        }


        #endregion

        #region Hooking & Uploading
        private string GetSaveFolderPath(string folderName)
        {
            string currentDateTime = DateTime.Now.ToString("yyyyMMdd");
            string[] paths = { Application.StartupPath, folderName, oSetting.SelectedStoreName, oSetting.SelectedMachineName, currentDateTime };
            string tempSavePath = Path.Combine(paths);
            if (!Directory.Exists(tempSavePath))
            {
                Directory.CreateDirectory(tempSavePath);
            }
            return tempSavePath;
        }
        #endregion

        #region SerialPort Function
        private bool fTestPrinterPortConnection()
        {
            bool testPrinterConnection = false;
            SerialPort testPrinterPort = new SerialPort(oSetting.PrinterPort);
            try
            {
                testPrinterPort.Open();
                testPrinterConnection = true;
            }
            catch (Exception ex) { testPrinterConnection = false; }
            finally
            {
                if (testPrinterPort.IsOpen)
                {
                    testPrinterPort.Close();
                }
            }
            return testPrinterConnection;
        }

        public static string ExecuteSetupcExe(string query)
        {
            var clipProcess = new Process()
            {
                StartInfo = new ProcessStartInfo(oSetting.ProgramName, query)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            clipProcess.Start();
            string cliOut = clipProcess.StandardOutput.ReadToEnd();
            clipProcess.WaitForExit();
            clipProcess.Close();

            return cliOut;
        }


        private string CheckSerialPortList()
        {
            List<string> virtualPortList = new List<string>();
            IDictionary<string, string> serialPortDict = new Dictionary<string, string>();
            IDictionary<string, string> realSerialPortDict = new Dictionary<string, string>();

            List<string> programTotalPortList = new List<string>();

            List<string> disablePortList = new List<string>();
            List<string> enablePortList = new List<string>();

            List<string> disableVirtualPortList = new List<string>();
            List<string> enableVirtualPortList = new List<string>();


            string stringOut = ExecuteSetupcExe("list");
            if (!string.IsNullOrEmpty(stringOut))
            {
                // setupc.exe list Parsing
                string[] stringOutList = stringOut.Split('\n');
                for (int i = 0; i < stringOutList.Length; i++)
                {
                    string tmpString = stringOutList[i].Trim(); // 공백 제거
                    string endPointPort = string.Empty;
                    if (tmpString.Length > 0)
                    {
                        string[] tmpStringList = tmpString.Split(' ');

                        string tmpVirtualPort = tmpStringList[0].ToString();// CNCA0, CNCB0 
                        endPointPort = tmpStringList[0].ToString();// CNCA0, CNCB0 
                        virtualPortList.Add(tmpVirtualPort);

                        if (tmpStringList.Length > 1)
                        {
                            string[] tmpPortNameStringList = tmpStringList[1].Split(',');
                            foreach (string t in tmpPortNameStringList)
                            {
                                // Key는 PortName 일 수도, RealPortName 일 수도 있다.
                                string tmpInnerKey = t.Split('=')[0];
                                string tmpInnerValue = t.Split('=')[1];
                                if (tmpInnerKey == "PortName")
                                {
                                    if (tmpInnerValue != "-")
                                    {
                                        serialPortDict.Add(tmpVirtualPort, tmpInnerValue); // Port Name { CNCA0 : COM#, }
                                        endPointPort = tmpInnerValue;
                                    }
                                }
                                else if (tmpInnerKey == "RealPortName")
                                {
                                    if (tmpInnerValue != "-")
                                    {
                                        realSerialPortDict.Add(tmpVirtualPort, tmpInnerValue); // Real Port Name { CNCA0 : COM#, }
                                        endPointPort = tmpInnerValue;
                                    }
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(endPointPort))
                    {
                        programTotalPortList.Add(endPointPort);  // 실제로 보여지는 Port 이름에 대한 List}
                    }
                }
                // All Port Check
                string[] windowSerialPortList = SerialPort.GetPortNames(); // 실제로 Port 이름이 다나온다, CNCA0, PortName의 COM3, RealPortName의 COM4
                foreach (string str in windowSerialPortList)
                {
                    if (!programTotalPortList.Contains(str))
                    {
                        // Window List에는 있지만, Program에 없는 COM는 사용된다고 간주
                        disablePortList.Add(str);
                    }
                    else
                    {
                        if (oSetting.PrinterPort == str)
                        {
                            // Print 설정 Port는 사용된다고 간주
                            disablePortList.Add(str);
                        }
                        else
                        {
                            if (str.Substring(0, 3) == "CNC")
                            {
                                if (!string.IsNullOrEmpty(str))
                                {
                                    if (!enableVirtualPortList.Contains(str))
                                    {
                                        enableVirtualPortList.Add(str);
                                    }
                                }
                            }
                            else
                            {
                                // Connection을 해보고, Open이 안되는 Port는 사용된다고 간주
                                SerialPort tmpPort = new SerialPort(str);
                                try
                                {
                                    tmpPort.Open();
                                    enablePortList.Add(str);

                                    // 가용한 virtual port list를 위한 작업
                                    string strKey = serialPortDict.Where(kvp => kvp.Value == str).Select(kvp => kvp.Key).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(strKey))
                                    {
                                        if (!enableVirtualPortList.Contains(strKey))
                                        {
                                            enableVirtualPortList.Add(strKey);
                                        }
                                    }

                                    string strKeyReal = realSerialPortDict.Where(kvp => kvp.Value == str).Select(kvp => kvp.Key).FirstOrDefault();
                                    if (!string.IsNullOrEmpty(strKeyReal))
                                    {
                                        if (!enableVirtualPortList.Contains(strKeyReal))
                                        {
                                            enableVirtualPortList.Add(strKeyReal);
                                        }
                                    }
                                }
                                catch (System.InvalidOperationException)
                                {
                                    disablePortList.Add(str);
                                }
                                catch (Exception ex)
                                {
                                    disablePortList.Add(str);
                                }
                                finally
                                {
                                    if (tmpPort.IsOpen)
                                    {
                                        tmpPort.Close();
                                    }
                                }
                            }
                        }
                    }
                }


                if (disablePortList.Contains(oSetting.SerialPort))
                {
                    MessageBox.Show("Serial Port가 이미 사용 중입니다. 변경 부탁드립니다.");
                    return string.Empty;
                }
                else
                {
                    if (enablePortList.Contains(oSetting.SerialPort))
                    {
                        // oSetting.SerialPort가 RealPortName에 있는지 확인
                        string key = realSerialPortDict.Where(kvp => kvp.Value == oSetting.SerialPort).Select(kvp => kvp.Key).FirstOrDefault();
                        if (!string.IsNullOrEmpty(key))
                        {
                            // Serial Port로 virtual port를 검색하고, 해당 pair virtual port를 찾아낸 다음, 
                            // key CNCA0 or CNCB0
                            string pairKey = string.Empty;
                            string tmpNum = string.Empty;
                            string tmpAB = key.Substring(3, 1);
                            tmpNum = key.Substring(4);

                            if (tmpAB == "A")
                            {
                                pairKey = "CNC" + "B" + tmpNum;
                            }
                            else
                            {
                                pairKey = "CNC" + "A" + tmpNum;
                            }

                            if (enableVirtualPortList.Contains(pairKey)) // Pair key가 사용 가능한 상태일 경우
                            {
                                string pairSerialPort = realSerialPortDict.Where(kvp => kvp.Key == pairKey).Select(kvp => kvp.Value).FirstOrDefault();
                                if (!string.IsNullOrEmpty(pairSerialPort))
                                {
                                    //oSetting.PairSerialPort = pairSerialPort;
                                    return pairSerialPort;
                                }
                                else
                                {
                                    // realSerialPortDict에 없을 경우, 
                                    string tmpPairRealSerialPort = string.Empty;
                                    // disable에는 없는 번호
                                    // oSetting.SerialPort와는 다른 번호
                                    for (int i = 1; i < 100; i++)
                                    {
                                        tmpPairRealSerialPort = $"COM{i}";
                                        if (!disablePortList.Contains(tmpPairRealSerialPort) && tmpPairRealSerialPort != oSetting.SerialPort && !enablePortList.Contains(tmpPairRealSerialPort))
                                        {
                                            // 이미 할당되어있는 PortName 또는 RealPortName으로 Change할수 없다.
                                            break;
                                        }
                                    }
                                    string stringOut2 = ExecuteSetupcExe($"change {pairKey} PortName=COM#");
                                    string stringOut3 = ExecuteSetupcExe($"change {pairKey} RealPortName={tmpPairRealSerialPort}");

                                    //oSetting.PairSerialPort = tmpPairRealSerialPort;
                                    return tmpPairRealSerialPort;
                                }
                            }
                            else
                            {
                                // Pair key가 사용 가능하지 않을 경우
                                MessageBox.Show("Serial Port가 이미 사용 중입니다. 변경 부탁드립니다.");
                                return string.Empty;
                            }
                        }
                        else
                        {
                            // oSetting.SerialPort가 RealPortName에 없을 경우,
                            // 가용한 enableVirtual선택 없을 경우, 새로 생성
                            List<string> tmpCheckNumberOfVirtualPort = new List<string>();
                            foreach (string str in enableVirtualPortList)
                            {
                                tmpCheckNumberOfVirtualPort.Add(str.Substring(4));
                            }
                            var result = tmpCheckNumberOfVirtualPort.GroupBy(item => item)
                                                  .Select(item => new
                                                  {
                                                      Name = item.Key,
                                                      Count = item.Count()
                                                  })
                                                  .OrderByDescending(item => item.Count)
                                                  .ThenBy(item => item.Name)
                                                  .Where(item => item.Count > 1)
                                                  .ToList();
                            if (result.Count > 0)
                            {

                                string tmpEnableVirtualPort = "CNCA" + result[0].Name.ToString();
                                string tmpEnableVirtualPortPair = "CNCB" + result[0].Name.ToString();

                                string tmpPairRealSerialPort = string.Empty;
                                // disable에는 없는 번호
                                // oSetting.SerialPort와는 다른 번호
                                for (int i = 1; i < 100; i++)
                                {
                                    tmpPairRealSerialPort = $"COM{i}";
                                    if (!disablePortList.Contains(tmpPairRealSerialPort) && tmpPairRealSerialPort != oSetting.SerialPort && !enablePortList.Contains(tmpPairRealSerialPort))
                                    {
                                        // 이미 할당되어있는 PortName 또는 RealPortName으로 Change할수 없다.
                                        break;
                                    }
                                }

                                string stringOut3 = ExecuteSetupcExe($"change {tmpEnableVirtualPort} PortName=COM#");
                                string stringOut4 = ExecuteSetupcExe($"change {tmpEnableVirtualPort} RealPortName={oSetting.SerialPort}"); // Serial Port Setting

                                string stringOut5 = ExecuteSetupcExe($"change {tmpEnableVirtualPortPair} PortName=COM#");
                                string stringOut6 = ExecuteSetupcExe($"change {tmpEnableVirtualPortPair} RealPortName={tmpPairRealSerialPort}"); // Pair Serial Port Setting

                                return tmpPairRealSerialPort;
                            }
                            else
                            {
                                //새로 생성해서 첨부터 다시...
                                return "retry";
                            }
                        }
                    }
                    else
                    {
                        // 새로 생성한 다음 change name 한다음 pair
                        return "retry";
                    }

                }
            }
            else
            {
                // 새로 생성한 다음 change name 한다음 pair
                return "retry";
            }

        } // Function Last
        #endregion

        #region Environment  Function
        private bool CheckEnvList()
        {
            bool outputBool = false;
            string getEnv = Environment.GetEnvironmentVariable(oSetting.EnvName);
            if (getEnv != null)
            {
                string[] getEnvList = getEnv.Split(';');
                foreach (string g in getEnvList)
                {
                    if (g.ToString() == oSetting.ProgramNamePath)
                    {
                        outputBool = true;
                        return outputBool;
                    }
                }
            }
            return outputBool;
        }
        #endregion


        #region File, Folder Search
        private static void FileSearch(string sDir)
        {
            foreach (string f in Directory.GetFiles(sDir, oSetting.ProgramName))
            {
                _directories.Add(sDir);
            }
        }

        private static void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    try
                    {
                        FileSearch(d);
                        DirSearch(d);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch (System.Exception exception)
            {
                //Console.WriteLine(exception.Message);
            }
        }

        private static void DriveSearch()
        {
            foreach (var d in System.IO.DriveInfo.GetDrives())
            {
                _drives.Add(d.Name);
            }
        }
        #endregion


        #region Dispatcher
        private void lbLog_Dispatcher(string str)
        {
            lbLog.Invoke(new MethodInvoker(delegate ()
            {
                lbLog.Items.Add(str);
            }));
        }

        private void lblCheckSuccess_Dispatcher(Label lbl)
        {
            lbl.Invoke(new MethodInvoker(delegate ()
            {
                lbl.Text = "v";
                lbl.ForeColor = System.Drawing.Color.Green;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            }));
        }

        private void lblCheckFailed_Dispatcher(Label lbl)
        {
            lbl.Invoke(new MethodInvoker(delegate ()
            {
                lbl.Text = "x";
                lbl.ForeColor = System.Drawing.Color.Red;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
            }));
        }
        #endregion


    }
}
