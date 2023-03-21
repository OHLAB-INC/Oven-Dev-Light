using Oven_Application.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oven_Application
{
    class oGlobal
    {
        // Bit Version
        private static string _applicationBitVersion = "64";

        public static string ApplicationBitVersion { get => _applicationBitVersion; }

        // Chat Thread 종료
        public static CancellationTokenSource cts = new CancellationTokenSource();

        public static TcpClient tcpClient = null;
        public static NetworkStream ntwStream = null;
        // 인터넷 연결 확인을 위한 함수
        public static bool IsInternetConnected()
        {
            const string NCSI_TEST_URL = "http://www.msftncsi.com/ncsi.txt";
            const string NCSI_TEST_RESULT = "Microsoft NCSI";
            const string NCSI_DNS = "dns.msftncsi.com";
            const string NCSI_DNS_IP_ADDRESS = "131.107.255.255";

            try
            {
                // Check NCSI test link
                var webClient = new WebClient();
                string result = webClient.DownloadString(NCSI_TEST_URL);
                if (result != NCSI_TEST_RESULT)
                {
                    return false;
                }

                // Check NCSI DNS IP
                var dnsHost = Dns.GetHostEntry(NCSI_DNS);
                if (dnsHost.AddressList.Count() < 0 || dnsHost.AddressList[0].ToString() != NCSI_DNS_IP_ADDRESS)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
            return true;
        }

        // Properites에서 값들을 가져올때 
        public static void LoadSettingValues()
        {
            // Main Form Loading 할때
            oSetting.SelectedStoreName = Properties.Settings.Default.SelectedStoreName;
            oSetting.SelectedMachineName = Properties.Settings.Default.SelectedMachineName;
            oSetting.SerialPort = Properties.Settings.Default.SerialPort;
            oSetting.SerialBaudRate = Properties.Settings.Default.SerialBaudRate;
            oSetting.PrinterPort = Properties.Settings.Default.PrinterPort;
            oSetting.PrinterBaudRate = Properties.Settings.Default.PrinterBaudRate;
            oSetting.IfPrinterExsist = Properties.Settings.Default.PrinterExist;
        }

        // Properites에 값들을 저장올때 
        public static void SaveSettingValues()
        {
            // Application 종료할때
            Properties.Settings.Default.SelectedStoreName = oSetting.SelectedStoreName;
            Properties.Settings.Default.SelectedMachineName = oSetting.SelectedMachineName;
            Properties.Settings.Default.SerialPort = oSetting.SerialPort;
            Properties.Settings.Default.SerialBaudRate = oSetting.SerialBaudRate;
            Properties.Settings.Default.PrinterPort = oSetting.PrinterPort;
            Properties.Settings.Default.PrinterBaudRate = oSetting.PrinterBaudRate;
            Properties.Settings.Default.PrinterExist = oSetting.IfPrinterExsist;

            Properties.Settings.Default.Save();
        }
    }



    public class LoginInfo
    {
        static bool _CheckLoginIfTrueFalse = false;

        public static bool CheckLoginIfTrueFalse { get => _CheckLoginIfTrueFalse; set => _CheckLoginIfTrueFalse = value; }
    }
}
