using Oven_Application.common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Oven_Application
{
    class csLogin
    {
        static bool is64BitProcess = (IntPtr.Size == 8);
        static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }

        // Application 과 OS 버전 Check
        public static bool applicationAndOsBitVersionCheck()
        {
            string osBitVersion = string.Empty;
            if (csLogin.InternalCheckIsWow64())
            {
                osBitVersion = "64";
            }
            else
            {
                osBitVersion = "32";
            }

            if (osBitVersion == oGlobal.ApplicationBitVersion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Login Function
        private static void StartLogin(string ID, string PASSWORD)
        {
            string url = oLogin.LoginURL;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json";

            JObject data = new JObject();
            data.Add("username", ID);
            data.Add("password", PASSWORD);

            StreamWriter reqStream = new StreamWriter(request.GetRequestStream(), Encoding.UTF8);
            reqStream.Write(data);
            reqStream.Close();

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader respStream = new StreamReader(response.GetResponseStream());
                string resp = respStream.ReadToEnd();

                JObject ret = JObject.Parse(resp);

                oLogin.AccessToken = ret["access_token"].ToString();
                oLogin.RefreshToken = ret["refresh_token"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login인 확인 중, 이슈 발생");
            }
        }

        public static bool CheckLogin(string ID, string PASSWORD)
        {
            bool loginSuccessBoolean = false;
            if (string.IsNullOrEmpty(ID))
            {
                // ID 입력 X
                MessageBox.Show("ID를 입력하십시요.");
            }
            else
            {
                // ID 입력 O
                // Password 확인 
                if (string.IsNullOrEmpty(PASSWORD))
                {
                    // Password 입력 X
                    MessageBox.Show("Password를 입력하십시요.");
                }
                else
                {
                    // Internet Check
                    if (oGlobal.IsInternetConnected())
                    {

                        StartLogin(ID, PASSWORD);

                        if (!string.IsNullOrEmpty(oLogin.AccessToken))
                        {
                            loginSuccessBoolean = true;


                        }
                        // ID & Password Check
                        if (loginSuccessBoolean)
                        {
                            // Network Check

                            MessageBox.Show("Success");
                            LoginInfo.CheckLoginIfTrueFalse = true;
                            Properties.Settings.Default.ID = ID;
                            Properties.Settings.Default.PASSWORD = PASSWORD;

                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            MessageBox.Show("ID 또는 Password가 잘못되었습니다.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("인터넷 연결이 정상적으로 되지 않았습니다.");
                    }
                }
            }

            return loginSuccessBoolean;
        }

    }
}
