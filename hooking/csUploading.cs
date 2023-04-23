using Oven_Application.common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oven_Application.ucPanel
{
    public partial class ucSetting
    {

        private string[] SearchUploadFolderList()
        {

            string[] paths = { Application.StartupPath, "temp", oSetting.SelectedStoreName, oSetting.SelectedMachineName };
            string tempSavePath = Path.Combine(paths);
            string[] folderList = new string[0];
            DirectoryInfo di = new DirectoryInfo(tempSavePath);

            if (di.Exists == false)   //If New Folder not exits  
            {
                di.Create();             //create Folder  
            }
            else
            {
                folderList = Directory.GetDirectories(tempSavePath);
            }            

            return folderList;
        }

        private string[] SearchUploadFileList(string path)
        {
            string[] fileList = Directory.GetFiles(path);
            return fileList;
        }

        static string EncodeFileName(string fileName)
        {
            // Encode the file name using UTF-8 encoding
            var utf8Bytes = Encoding.UTF8.GetBytes(fileName);
            var base64String = Convert.ToBase64String(utf8Bytes);
            return $"=?UTF-8?B?{base64String}?=";
        }


        private async Task UploadingFiletoDrive(string storeId, string machineId, string filePath)
        {
            string url = oSetting.URL + $"/api/v1/stores/{storeId}/machines/{machineId}/receipts";

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            // Add the autorization header to the request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", oLogin.AccessToken);

            // Add the accept header to the request
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Add the content type header to the request
            //request.Content.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

            string fileName = Path.GetFileName(filePath);
            var contentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "file",
                FileName = fileName,
            };
            //contentDisposition.Name = "file";
            //contentDisposition.FileName = fileName;

            var fileStream = new FileStream(filePath, FileMode.Open);
            var streamContent = new StreamContent(fileStream);
            streamContent.Headers.ContentDisposition = contentDisposition;

            var content = new MultipartFormDataContent();
            content.Add(streamContent);

            request.Content = content;

            // Send the request
            var response = await client.SendAsync(request);

            bool resCheck = response.IsSuccessStatusCode;
        }


        public static bool HttpUploadFile(string url, string file, string paramName, string contentType, string accessToken, NameValueCollection nvc, out string Msg)
        {
            bool _flag = false;
            Msg = null;

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.PreAuthenticate = true;
            wr.Headers.Add("Authorization", "Bearer " + accessToken);
            wr.Accept = "application/json";
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

            Stream rs = wr.GetRequestStream();

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, paramName, Path.GetFileName(file), contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                using (HttpWebResponse resp = wr.GetResponse() as HttpWebResponse)
                {
                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        _flag = true;
                    }
                    StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                    Msg = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
            return _flag;
        }


        private async Task Uploading()
        {
            // Uploading은 다음과 같이 이루어진다.
            // 1) 선택된Store/Machine에 대한 id를 가져온다.
            // 2) application경로/Temp/선택된Store/선택된machine 경로에서 날짜 폴더 리스트를 찾는다 
            // 3) 파일 업로드 진행
            // 

            await Task.Run(() => {

                string storeId = string.Empty;
                string machineId = string.Empty;
                try
                {
                    storeId = oSetting._storeNameIdDict[oSetting.SelectedStoreName].ToString();
                    machineId = oSetting._machineNameIdDict[oSetting.SelectedMachineName].ToString();
                }
                catch (Exception e) { }

                if (!string.IsNullOrEmpty(storeId) && !string.IsNullOrEmpty(machineId)) //10, 7
                {
                    lbLog_Dispatcher("Uploading Process ongoing");
                    _uploadingProcessContinue = true;
                }
                else
                {
                    lbLog_Dispatcher("Uploading Process failed");
                }

                while (_uploadingProcessContinue)
                {

                    string[] folderList = SearchUploadFolderList();
                    if (folderList.Length > 0)
                    {
                        foreach (string folder in folderList)
                        {
                            string[] fileList = SearchUploadFileList(folder);

                            foreach (string filePath in fileList)
                            {
                                //lbLog_Dispatcher("aa");
                                //UploadingFiletoDrive(storeId, machineId, filePath);
                                string url = oSetting.URL + $"/api/v1/stores/{storeId}/machines/{machineId}/receipts";
                                string msg;

                                NameValueCollection nvc = new NameValueCollection();
                                nvc.Add("contentId", "1");

                                bool resUploadingBool = HttpUploadFile(url, filePath, "file", "text/plain", oLogin.AccessToken, nvc, out msg);
                                Thread.Sleep(300);
                                if (resUploadingBool)
                                {
                                    //filePath folder 삭제
                                    if (File.Exists(filePath))
                                    {
                                        try
                                        {
                                            File.Delete(filePath);
                                        }
                                        catch (Exception ex)
                                        {
                                        }
                                    }
                                }
                                Thread.Sleep(300);
                            }

                        }
                    }
                    // 여기에 Uploading 작업
                    Thread.Sleep(60000);
                }

            });
        }

    }
}
