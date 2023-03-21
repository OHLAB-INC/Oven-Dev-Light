using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oven_Application.ucPanel
{
    public partial class ucChat
    {
        public class ChatHandler
        {
            private Guna2TextBox tbChat;
            private NetworkStream netStream;
            private StreamReader strReader;

            private ucChat ucChat; // Controller

            public void Setup(ucChat ucChat, NetworkStream netStream, Guna2TextBox tbChat)
            {
                this.tbChat = tbChat;
                this.netStream = netStream;
                this.ucChat = ucChat;
                this.netStream = netStream;
                this.strReader = new StreamReader(netStream);
            }

            public void ChatClose()
            {
                try
                {
                    netStream.Close();
                    strReader.Close();
                }
                catch (Exception ex) { }
            }

            public void ChatProcess(CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        //문자열을 받음
                        string lstMessage = strReader.ReadLine();
                        if (lstMessage != null && lstMessage != "")
                        {
                            //SetText 메서드에서 델리게이트를 이용하여 서버에서 넘어오는 메시지를 쓴다.
                            ucChat.SetText(lstMessage + "\r\n");
                        }
                    }
                    catch (System.Exception)
                    {
                        break;
                    }
                }
            }
        }
    }
}
