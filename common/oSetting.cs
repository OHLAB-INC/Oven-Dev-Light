using Oven_Application.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Oven_Application
{
    class oSetting
    {
        // URL 주소
        private static string _URL = "http://localhost:5000"; // 추후 변경해야할 부분
        public static string URL { get => _URL; }

        // Virtual Program Variable
        private static string _programName = "setupc.exe"; //com0com 실행 파일 이름 
        public static string ProgramName { get => _programName; }

        private static string _programNamePath = string.Empty; // _programName의 경로
        public static string ProgramNamePath { get => _programNamePath; set => _programNamePath = value; }

        private static bool _ifExistVirtualProgram = false; // _programName이 경로에 있는지 확인
        public static bool IfExistVirtualProgram { get => _ifExistVirtualProgram; set => _ifExistVirtualProgram = value; }

        // Environment Path Variable
        private static string _envName = "path"; //setupc.exe 환경 변수 등록을 위한 변수
        public static string EnvName { get => _envName; }

        private static bool _ifExistEnvPath = false;
        public static bool IfExistEnvPath { get => _ifExistEnvPath; set => _ifExistEnvPath = value; }

        public static List<string> _baudRateList = new List<string>();
        public static void getBaudrate()
        {
            _baudRateList.Clear();
            _baudRateList.Add("110"); _baudRateList.Add("300"); _baudRateList.Add("600"); _baudRateList.Add("1200");
            _baudRateList.Add("2400"); _baudRateList.Add("4800"); _baudRateList.Add("9600"); _baudRateList.Add("14400");
            _baudRateList.Add("19200"); _baudRateList.Add("38400"); _baudRateList.Add("56000"); _baudRateList.Add("57600");
            _baudRateList.Add("115200"); _baudRateList.Add("128000"); _baudRateList.Add("256000");
        }

        private static string _serialPort = string.Empty;
        public static string SerialPort { get => _serialPort; set => _serialPort = value; }

        private static string _serialBaudRate = string.Empty;
        public static string SerialBaudRate { get => _serialBaudRate; set => _serialBaudRate = value; }

        private static string _printerPort = string.Empty;
        public static string PrinterPort { get => _printerPort; set => _printerPort = value; }

        private static string _printerBaudRate = string.Empty;
        public static string PrinterBaudRate { get => _printerBaudRate; set => _printerBaudRate = value; }
        private static string _machineDrivePath = string.Empty;

        private static string _pairSerialPort = string.Empty;
        public static string PairSerialPort { get => _pairSerialPort; set => _pairSerialPort = value; }

        private static bool _ifConnectionSerialPortSuccess = false;
        public static bool IfConnectionSerialPortSuccess { get => _ifConnectionSerialPortSuccess; set => _ifConnectionSerialPortSuccess = value; }
        public static string MachineDrivePath { get => _machineDrivePath; set => _machineDrivePath = value; }

        private static bool _ifReadyToHooking = false;
        public static bool IfReadyToHooking { get => _ifReadyToHooking; set => _ifReadyToHooking = value; }

        private static bool _ifPrinterExsist = false;
        public static bool IfPrinterExsist { get => _ifPrinterExsist; set => _ifPrinterExsist = value; }

        public static List<string> _storeNameList = new List<string>();
        public static Dictionary<string, int> _storeNameIdDict = new Dictionary<string, int>();

        public static List<string> _machineNameList = new List<string>();
        public static Dictionary<string, int> _machineNameIdDict = new Dictionary<string, int>();

        public static List<string> _machineDrivePathList = new List<string>();
        public static Dictionary<int, string> _machineDrivePathDict = new Dictionary<int, string>();

        // 현재 선택된 스토어와 기기정보를 담는 변수들
        private static string _selectedStoreName = string.Empty;
        public static string SelectedStoreName { get => _selectedStoreName; set => _selectedStoreName = value; }


        private static string _selectedMachineName = string.Empty;
        public static string SelectedMachineName { get => _selectedMachineName; set => _selectedMachineName = value; }


        public class StoreObject
        {
            public int id { get; set; }
            public int user_id { get; set; }
            public string store_nm { get; set; }
            public string store_license_no { get; set; }
            public string store_nas_path { get; set; }
            public DateTime updt_dt { get; set; }
        }
        public static List<StoreObject> _storeObject;

        public class MachineObject
        {
            public int id { get; set; }
            public int store_id { get; set; }
            public string machine_nm { get; set; }
            public string machine_typ { get; set; }
            public string machine_nas_path { get; set; }
            public DateTime updt_dt { get; set; }
        }
        public static List<MachineObject> _machineObject;

        /// <summary>
        /// 사용자의 Store 정보를 가져온다.
        /// </summary>
        public static void getStoreInfo()
        {
            string url = _URL + "/api/v1/stores";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers["Authorization"] = "Bearer  " + oLogin.AccessToken;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader respStream = new StreamReader(response.GetResponseStream());

                string resp = respStream.ReadToEnd();
                _storeObject = JsonConvert.DeserializeObject<List<StoreObject>>(resp);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Store 확인 중 에러");
            }
        }

        /// <summary>
        /// Dictionary 형태의 Store 정보를 List로 변환
        /// </summary>
        public static void parsingStoreInfo()
        {
            if (_storeObject != null)
            {
                _storeNameList.Clear();
                _storeNameIdDict.Clear();

                foreach (var a in _storeObject)
                {
                    _storeNameList.Add((string)a.store_nm);
                    _storeNameIdDict.Add(a.store_nm, a.id);
                }
            }
        }

        /// <summary>
        /// Store ID 에 등록되어있는 기기 정보들을 가져온다
        /// </summary>
        /// <param name="id"></param>
        public static void getMachineInfo(int id)
        {
            string url = _URL + $"/api/v1/stores/{id}/machines";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers["Authorization"] = "Bearer  " + oLogin.AccessToken;

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader respStream = new StreamReader(response.GetResponseStream());

                string resp = respStream.ReadToEnd();
                _machineObject = JsonConvert.DeserializeObject<List<MachineObject>>(resp);
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Machine 확인 중 에러 : Machine이 존재하지 않습니다.");
                _machineObject = null;
                _machineNameList.Clear();
                _machineNameIdDict.Clear();
                _selectedMachineName = string.Empty;
            }
        }

        /// <summary>
        /// Machine 정보를 가져올 때, NAS Path 정보다 같이 가져온다
        /// </summary>
        public static void parsingMachineInfo()
        {
            if (_machineObject != null)
            {
                _machineNameList.Clear();
                _machineNameIdDict.Clear();

                _machineDrivePathList.Clear();
                _machineDrivePathDict.Clear();

                foreach (var a in _machineObject)
                {
                    _machineNameList.Add((string)a.machine_nm);
                    _machineNameIdDict.Add(a.machine_nm, a.id);

                    _machineDrivePathList.Add((string)a.machine_nas_path);
                    _machineDrivePathDict.Add(a.id, (string)a.machine_nas_path);
                }
            }
        }

    }
}
