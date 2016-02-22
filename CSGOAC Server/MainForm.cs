using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CSGOAC_Server.Network;


namespace CSGOAC_Server
{
    public partial class MainForm : Form
    {
        ServerNetwork SN;
        WebServer web;
        public MainForm()
        {
            InitializeComponent();
        }
        public string log_time = string.Empty;
        public string log_currentdate = string.Empty;
        private void currenttime()
        {
            log_time = "[ " + DateTime.Now.Hour + " 시 " + DateTime.Now.Minute + " 분 " + DateTime.Now.Second + "초 ]";
            log_currentdate = "KACLOG_" + DateTime.Now.Date.ToShortDateString();
        }
      public void Log(string logging)
        {
            currenttime();
            if (Directory.Exists("LOG"))
            {
                if (!File.Exists("LOG\\" + log_currentdate + ".txt"))
                {
                    File.WriteAllText("LOG\\" + log_currentdate + ".txt", "");
                    StreamWriter sw = new StreamWriter("LOG\\" + log_currentdate + ".txt");
                    sw.WriteLine("[LOG_START]");
                    sw.WriteLine(log_time + " : " + logging);
                    sw.Close();
                }
                else
                {
                    StreamReader sr = new StreamReader("LOG\\" + log_currentdate + ".txt");
                    string read = sr.ReadToEnd();
                    sr.Close();
                    StreamWriter sw = new StreamWriter("LOG\\" + log_currentdate + ".txt");
                    sw.WriteLine(log_time + " : " + logging);
                    sw.Close();
                }
            }
            else
            {
                Directory.CreateDirectory("LOG");
                File.WriteAllText("LOG\\" + log_currentdate + ".txt", "");
                StreamWriter sw = new StreamWriter("LOG\\" + log_currentdate + ".txt");
                sw.WriteLine("[LOG_START]");
                sw.WriteLine(log_time + " : " + logging);
                sw.Close();
            }

            LogBox.Items.Add(log_time + " : " + logging);

        }
        public static void Logdo(string st)
        {
            MainForm fr = new MainForm();
            fr.Log(st);
            fr.Dispose();
        }
        private void StartWebBtn_Click(object sender, EventArgs e)
        {
            web = new WebServer();
            web.WebServerStart();
            StartWebBtn.Enabled = false;
            StopWebBtn.Enabled = true;
            Log("WebServerStart");

        }

        private void StopWebBtn_Click(object sender, EventArgs e)
        {
            web.WebServerStop();
            StartWebBtn.Enabled = true;
            StopWebBtn.Enabled = false;
            Log("WebServerStop");
        }

        private void ServerStartBtn_Click(object sender, EventArgs e)
        {
            SettingGroup.Enabled = false;
            ServerStartBtn.Enabled = false;
            ServerStopBtn.Enabled = true;
            Log("KAC ServerStart");
            ListenStart();
        }
        private void ListenStart()

        {
            SN = new ServerNetwork(Convert.ToInt32(Port.Text));
            SN.Listen();
            SN.Received += new ServerNetwork.ReceivedEventHandler(ServerReceived);
            SN.Disconnected += new ServerNetwork.DisconnectedEventHandler(server_Disconnected);
        }
        void server_Disconnected(ServerNetwork SN, Info i)
        {
            Invoke(new _ConnectionListRemove(ConnectionListRemove), i);
        }
        public delegate void _ConnectionListRemove(Info i);
        public void ConnectionListRemove(Info i)
        {
            foreach (ListViewItem item in PlayerListView.Items)
            {
                if ((Info)item.Tag == i)
                {
                    Log(i.RemoteAddress.Split(':')[0] + "[Disconnect]");
                    item.Remove();
                    break;
                }
            }
        }
        private void NotiInit()
        {
            Tray.Visible = true;
            Tray.BalloonTipTitle = "KAC For CSGO";
            Tray.BalloonTipText = "Welcome To KAC Official Server Program For CSGO";
            Tray.BalloonTipIcon = ToolTipIcon.Info;
            Tray.ShowBalloonTip(1);
        }
        void ServerReceived(ServerNetwork SN, Info i, byte[] packet)
        {

            byte[] by_header = new byte[2];
            Array.Copy(packet, 0, by_header, 0, 2);
            short header = BitConverter.ToInt16(by_header, 0);
            string[] Rstr = Encoding.UTF8.GetString(packet, 2, packet.Length - 2).Split('|');
            string ipad = i.RemoteAddress.Split(':')[0];
            Console.WriteLine("서버: PacketReceiver");
            switch (header)
            {
                case (int)NetworkHEADER.HANDSHAKE:
                    if (Rstr[0] != "csgokacserver")
                    {
                        i.Send(NetworkHEADER.DENIED, "");
                        return;
                    }
                    else
                    {
                        i.Send(NetworkHEADER.DOCONNECTION, ServerIP.Text +"|");
                        i.Send(NetworkHEADER.PLISTGET, "");
                    }
                    break;
                case (int)NetworkHEADER.CONNECTION:
                    Console.WriteLine("서버: PacketReceiver - Case Connection");
                    if (Limitchk.Checked)
                    {
                        if (PlayerListView.Items.Count == 10)
                        {
                            i.Send(NetworkHEADER.DENIED, "");
                        }
                        else
                        {
                            Invoke(new _Add(Add), i, Rstr[0]);
                            Invoke(new _notification(notification), i.RemoteAddress.Split(':')[0], Rstr[0]);
                        }
                    }
                    else
                    {
                        Invoke(new _Add(Add), i, Rstr[0]);
                        Invoke(new _notification(notification), i.RemoteAddress.Split(':')[0], Rstr[0]);
                    }
                    break;
                case (int)NetworkHEADER.PLISTGETRESPONSE:
                    string receive = @"" + Rstr[2];
                    Invoke(new _PLISTSAVE(PLISTSAVE), Rstr[0], Rstr[1],receive,ipad);
                    break;
                case (int)NetworkHEADER.POLISTGETRESPONSE:
                    string receive2 = @"" + Rstr[2];
                    Invoke(new _POLISTSAVE(POLISTSAVE), Rstr[0], Rstr[1], receive2,Rstr[3], ipad);
                    break;

            }
        }    // pid // prname // prpath // 파일이름
        delegate void _PLISTSAVE(string pid, string processname, string processpath, string ip);
        void PLISTSAVE(string pid, string processname, string processpath, string ip)
        {
      
            if (!Directory.Exists("OverWatch"))
            {
                Directory.CreateDirectory("OverWatch");
            }
            if (!Directory.Exists("OverWatch\\" + ip))
            {
                Directory.CreateDirectory("OverWatch\\" + ip);
            }
            if(!Directory.Exists("OverWatch\\" + ip +"\\po"))
            {
                Directory.CreateDirectory("OverWatch\\" + ip + "\\po");
            }
            string FN = DateTime.Now.ToShortTimeString().Replace(':', '-');
            if (!File.Exists("OverWatch\\" + ip + "\\po\\" +FN+".txt"))
            {
                File.WriteAllText("OverWatch\\" + ip + "\\po\\" +FN+".txt", "");
                StreamWriter swa = new StreamWriter("OverWatch\\" + ip + "\\po\\" +FN+".txt");
                string str1 = "ProcessID".PadRight(15);
                string str2 = "ProcessName".PadRight(30);
                string str3 = "ProcessPath".PadRight(50);
                swa.WriteLine(str1 + " " + str2 + " " + str3);
                string a1 = "".PadRight(15, '=');
                string a2 = "".PadRight(30, '=');
                string a3 = "".PadRight(50, '=');
                swa.WriteLine(a1 + " " + a2 + " " + a3);
                swa.Close();
            }
            StreamReader sr = new StreamReader("OverWatch\\" + ip + "\\po\\" +FN+".txt");
            string read = sr.ReadToEnd();
            sr.Close();
                StreamWriter sw = new StreamWriter("OverWatch\\" + ip + "\\po\\" +FN+".txt");
            sw.WriteLine(read);
 
 
                pid = pid.PadRight(15);
                processname = processname.PadRight(30);
                processpath = processpath.PadRight(50);
                sw.WriteLine(pid + " " + processname + " " + processpath);
                sw.Close();
            


        }
        delegate void _POLISTSAVE(string pid, string processname, string processpath, string filename, string ip);
        void POLISTSAVE(string pid, string processname, string processpath, string filename, string ip)
        {

            if (!Directory.Exists("OverWatch"))
            {
                Directory.CreateDirectory("OverWatch");
            }
            if (!Directory.Exists("OverWatch\\" + ip))
            {
                Directory.CreateDirectory("OverWatch\\" + ip);
            }
            if(!Directory.Exists("OverWatch\\" + ip +"\\" +"ow"))
            {
                Directory.CreateDirectory("OverWatch\\" + ip + "\\" + "ow");
            }
            if (!File.Exists("OverWatch\\" + ip + "\\ow\\"+ filename + ".txt"))
            {
                File.WriteAllText("OverWatch\\" + ip + "\\ow\\" + filename + ".txt", "");
                StreamWriter swa = new StreamWriter("OverWatch\\" + ip + "\\ow\\" + filename + ".txt");
                string str1a = "ProcessID".PadRight(15);
                string str2a = "ProcessName".PadRight(30);
                string str3a = "ProcessPath".PadRight(50);
                swa.WriteLine(str1a + " " + str2a + " " + str3a);
                string a1a = "".PadRight(15, '=');
                string a2a = "".PadRight(30, '=');
                string a3a = "".PadRight(50, '=');
                swa.WriteLine(a1a + " " + a2a + " " + a3a);
                swa.Close();
            }
            StreamReader sr = new StreamReader("OverWatch\\" + ip + "\\ow\\" + filename + ".txt");
            string read = sr.ReadToEnd();
            
            sr.Close();
            StreamWriter sw = new StreamWriter("OverWatch\\" + ip + "\\ow\\" + filename + ".txt");
            sw.WriteLine(read);
            pid = pid.PadRight(15);
            processname = processname.PadRight(30);
            processpath = processpath.PadRight(50);
            sw.WriteLine(pid + " " + processname + " " + processpath);
            sw.Close();
            UpdateStatus(filename, ip);
        }
        void UpdateStatus(string status,string ip)
        {
            foreach (ListViewItem item in PlayerListView.Items)
            {
                if (item.Text == ip)
                {
                    item.SubItems[2].Text = status;
                }
            }
        }
        delegate void _notification(string ip, string steamid);
        void notification(string ip, string steamid)
        {
            Tray.Visible = true;
            Tray.BalloonTipTitle = "KAC";
            Tray.BalloonTipTitle = "New Connection";
            Tray.BalloonTipText = "SteamID : " + steamid + " IP : " + ip;
            Tray.BalloonTipIcon = ToolTipIcon.Info;
            Tray.ShowBalloonTip(1);
        }

        private void ServerStopBtn_Click(object sender, EventArgs e)
        {
            ServerStartBtn.Enabled = true;
            ServerStopBtn.Enabled = false;
            SettingGroup.Enabled = true;
            Log("KAC ServerStop");
            SN.ServerOff();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NotiInit();
        }
        delegate void _Add(Info i, string steamid);
        public void Add(Info i, string steamid)
        {
            string[] splitIP = i.RemoteAddress.Split(':');
           Log("Connected IP: " + splitIP[0] + " STEAMID: " + steamid);
            ListViewItem itema = new ListViewItem();
            itema.Text = splitIP[0];
            itema.SubItems.Add(steamid);
            itema.SubItems.Add(DateTime.Now.ToShortTimeString());
            itema.Tag = i;
            PlayerListView.Items.Add(itema);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tray.Visible = false;

            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void kickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PlayerListView.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem item in PlayerListView.SelectedItems)
            {
                Info client = (Info)item.Tag;
                client.Send(NetworkHEADER.DISCONNECT, "");
                ConnectionListRemove(client);
            }
        }
    }
}
