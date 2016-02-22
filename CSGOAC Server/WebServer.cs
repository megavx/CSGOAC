using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace CSGOAC_Server
{
    class WebServer
    {
        Socket ServerSocket;
        bool WebRun;

        public void WebServerStop()
        {
            ServerSocket.Close();
            WebRun = false;
           
        }
        public void WebServerStart()
        {
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, 80);
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ServerSocket.Bind(iep);
                ServerSocket.Listen(20);
                SocketAsyncEventArgs sockevent = new SocketAsyncEventArgs();
                sockevent.Completed += new EventHandler<SocketAsyncEventArgs>(Accept_Complete);
                ServerSocket.AcceptAsync(sockevent);
                WebRun = true;
            }
            catch
            {
                WebRun = false;
            }
        }
        private void Accept_Complete(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                Socket client = e.AcceptSocket;
                Socket server = (Socket)sender;
                if (client != null)
                {
                    SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                    byte[] szBuffer = new byte[4096];
                    args.SetBuffer(szBuffer, 0, 4096);
                    args.UserToken = client;
                    args.Completed += new EventHandler<SocketAsyncEventArgs>(Recieve_Completed);
                    client.ReceiveAsync(args);
                }
                e.AcceptSocket = null;
                server.AcceptAsync(e);
            }
            catch(ObjectDisposedException)
            {

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void Recieve_Completed(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                byte[] pBuffer = e.Buffer;
                String sHttpText = Encoding.UTF8.GetString(pBuffer);
                sHttpText = sHttpText.Trim();
                sHttpText = sHttpText.Replace("\0", "");
                Console.WriteLine(sHttpText);
                int nPos = sHttpText.IndexOf(" ") + 1;
                int nEPos = sHttpText.IndexOf(" ", nPos);
                if (nPos < 0 || nEPos < 0) return;
                String fileName = sHttpText.Substring(nPos, nEPos - nPos);
                nPos = sHttpText.IndexOf("Accept", nPos);
                nEPos = sHttpText.IndexOf("\n", nPos);
                String AcceptType = sHttpText.Substring(nPos, nEPos - nPos);

                StringBuilder strBuffer = new StringBuilder();

                strBuffer.Append("HTTP/1.1 200 OK\r\n");
                strBuffer.Append("Cache-Control: private\r\n");
                strBuffer.Append("Content-Type: text/html; charset=utf-8\r\n");
                strBuffer.Append("Server: SYWebServer - 1.00\r\n");

                byte[] data = FileRead(fileName, ref strBuffer);
                if (data != null && data.Length > 0)
                {
                    String Header = strBuffer.ToString();
                    pBuffer = Encoding.Default.GetBytes(Header);

                    SocketAsyncEventArgs args = new SocketAsyncEventArgs();
                    args.SetBuffer(data, 0, data.Length);
                    args.Completed += new EventHandler<SocketAsyncEventArgs>(Send_Completed);
                    Socket client = (Socket)sender;
                    client.Send(pBuffer);
                    client.SendAsync(args);
                }
            }
            catch (ObjectDisposedException)
            {

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        public string log_time = string.Empty;
        public string Wlog_currentdate = string.Empty;
        private void currenttime()
        {
            log_time = "[ " + DateTime.Now.Hour + " 시 " + DateTime.Now.Minute + " 분 " + DateTime.Now.Second + "초 ]";
            Wlog_currentdate = "WEBLOG_" + DateTime.Now.Date.ToShortDateString();
        }
        private void Logger(string logging)
        {
            currenttime();
            if (Directory.Exists("LOG"))
            {
                if (!File.Exists("LOG\\"+Wlog_currentdate + ".txt"))
                {
                    File.WriteAllText("LOG\\"+Wlog_currentdate + ".txt", "");
                    StreamWriter sw = new StreamWriter("LOG\\"+Wlog_currentdate + ".txt");
                    sw.WriteLine("[LOG_START]");
                    sw.WriteLine(log_time + " : " + logging);
                    sw.Close();
                }
                else
                {
                    StreamReader sr = new StreamReader("LOG\\"+Wlog_currentdate + ".txt");
                    string read = sr.ReadToEnd();
                    sr.Close();
                    StreamWriter sw = new StreamWriter("LOG\\"+Wlog_currentdate + ".txt");
                    sw.WriteLine(log_time + " : " + logging);
                    sw.Close();
                }
            }
            else
            {
                Directory.CreateDirectory("LOG");
                File.WriteAllText("LOG\\"+Wlog_currentdate + ".txt", "");
                StreamWriter sw = new StreamWriter("LOG\\"+Wlog_currentdate + ".txt");
                sw.WriteLine("[LOG_START]");
                sw.WriteLine(log_time + " : " + logging);
                sw.Close();
            }
        }
        private void Send_Completed(object sender, SocketAsyncEventArgs e)
        {
            Socket client = (Socket)sender;
          string ip=  client.RemoteEndPoint.ToString().Split(':')[0];
            Logger(ip + "Web DataSend Sucess");
            client.Disconnect(true);
            client.Close();
        }
        private byte[] FileRead(string filename,ref StringBuilder sb)
        {
            filename.Replace("/", "\\");
            if (filename.CompareTo("/") == 0)
            {
                filename += "index.html";
            }

            try
            {
                FileStream FS = new FileStream("Web\\"+filename, FileMode.Open, FileAccess.Read);
                byte[] pBuffer = new byte[FS.Length];
                FS.Read(pBuffer, 0, pBuffer.Length);
                FS.Close();
                sb.AppendFormat("Content-Length: {0}\r\n", pBuffer.Length);
                sb.Append("\r\n");
                return pBuffer;
            }
            catch (FileNotFoundException e)
            {
                return null;
            }
        }
        public bool WebServerRunning()
        {
            return WebRun;
        }
    }
}
