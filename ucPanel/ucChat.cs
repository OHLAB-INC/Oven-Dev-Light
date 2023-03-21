using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oven_Application.ucPanel
{
    public partial class ucChat : UserControl
    {


        delegate void SetTextDelegate(string s);
        ChatHandler chatHandler = new ChatHandler();

        public ucChat()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "입장")
            {
                try
                {
                    // Chat Server 연결
                    oGlobal.tcpClient = new TcpClient();
                    oGlobal.tcpClient.Connect(IPAddress.Parse(oChat.IP.ToString()), Int32.Parse(oChat.Port));
                    oGlobal.ntwStream = oGlobal.tcpClient.GetStream();

                    chatHandler.Setup(this, oGlobal.ntwStream, this.tbChat);

                    Thread chatThread = new Thread(() => chatHandler.ChatProcess(oGlobal.cts.Token));
                    chatThread.Start();

                    Message_Snd("<<" + tbNick.Text + ">> 님께서 접속하셨습니다.", true);
                    btnConnect.Text = "나가기";
                }
                catch (System.Exception Ex)
                {
                    MessageBox.Show("Server 오류 발생 또는 Start 되지 않았거나\n\n" + Ex.Message, "Client");
                }
            }
            else
            {
                try
                {
                    Message_Snd("<<" + tbNick.Text + ">> 님께서 로그아웃 하셨습니다.", false);
                    this.tbChat.AppendText("<<" + tbNick.Text + ">> 님께서 로그아웃 하셨습니다." + "\r\n");
                    btnConnect.Text = "입장";
                    chatHandler.ChatClose();
                    oGlobal.ntwStream.Close();
                    oGlobal.tcpClient.Close();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void Message_Snd(string lstMessage, Boolean Msg)
        {
            try
            {
                //보낼 데이터를 읽어 Default 형식의 바이트 스트림으로 변환 해서 전송
                string dataToSend = lstMessage + "\r\n";
                byte[] data = Encoding.UTF8.GetBytes(dataToSend);  // Default -> UTF8
                oGlobal.ntwStream.Write(data, 0, data.Length);
            }
            catch (Exception Ex)
            {
                if (Msg == true)
                {
                    MessageBox.Show("서버가 시작되지 않았거나\n\n" + Ex.Message, "Client");
                    btnConnect.Text = "입장";
                    chatHandler.ChatClose();
                    oGlobal.ntwStream.Close();
                    oGlobal.tcpClient.Close();
                }
            }
        }

        //다른 스레드인 ChatHandler의 쓰레드에서 호출하는 함수로
        //델리게이트를 통해 채팅 문자열을 텍스트박스에 씀
        public void SetText(string text)
        {
            if (this.tbChat.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.tbChat.AppendText(text);
            }
        }

        private void tbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //서버에 접속이 된 경우에만 메시지를 서버로  보냄
                if (btnConnect.Text == "나가기")
                {
                    Message_Snd(tbNick.Text + " : " + tbMessage.Text, true);
                }
                tbMessage.Text = "";
                e.Handled = true;  //이벤트처리중지, KeyUp or Click등
            }
        }
    }
}
