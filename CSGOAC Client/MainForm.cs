using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using KACAPI;
using CSGOAC_Client.Network;
using CSGOAC_Client.ProcessOW;
using System.Threading;
using CSGOAC_Client.Class;
using System.Runtime.InteropServices;
namespace CSGOAC_Client
{
    public partial class MainForm : Form
    {
        public static string SteamID;
        ClientNetwork CN;
        Thread GameProcessAttach;
        bool gameattch = false;
        bool IsFirstRunchk = false;
        bool isgamestart = false;
        ProcessOverwatch po = new ProcessOverwatch();
        public static string ServerHost;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("http://eac.konachan.kr");
        }
        private bool InitSteam()
        {

            ISteamClient012 steamclient = Steamworks.CreateInterface<ISteamClient012>();
            if (steamclient == null)
            {
                Console.WriteLine("steamclient is null !");
                return false;
            }

            int pipe = steamclient.CreateSteamPipe();
            if (pipe == 0)
            {
                Console.WriteLine("Failed to create a pipe");
                return false;
            }

            int user = steamclient.ConnectToGlobalUser(pipe);
            if (user == 0 || user == -1)
            {
                Console.WriteLine("Failed to connect to global user");
                return false;
            }

            steamuser = steamclient.GetISteamUser<ISteamUser016>(user, pipe);
            if (steamuser == null)
            {
                Console.WriteLine("steamuser is null !");
                return false;
            }
            return true;
        }
        public ISteamUser016 steamuser = null;
        
        private void UIDCheck()
        {
            var isSteamRunning = Steamworks.Load(true);
            if (steamuser == null)
            {
                InitSteam();
            }
            string str = string.Empty;
            try
            {
                 str = steamuser.GetSteamID().ConvertToUint64().ToString();
            }
            catch
            {
                str = "None";
            }
            UID.Text = isSteamRunning ? "Steam UID : " + str : "Steam UID : " + str;
            SteamID = str;
            Continue.Enabled = isSteamRunning ? Continue.Enabled = true : Continue.Enabled = false;
        }

        private void Continue_Click(object sender, EventArgs e)
        {
 
            CheckGameRun();
            if(!CheckProcess("Steam"))
            {
                MessageBox.Show("Can't find Steam Client");
                Process.GetCurrentProcess().Kill();
                return;
            }
            if(!ClientNetwork.Connected)
            {
                Continue.Enabled = false;
                try
                {
                    CN = new ClientNetwork(ServerIP.Text, 26974);

                }
                catch(Exception EX)
                {
                    MessageBox.Show(EX.Message);
                    return;
                }
                CN.Connect();
                CN.Disconnected += new ClientNetwork.DisconnectedEventHandler(cn_Disconnected);
                CN.Received += new ClientNetwork.ReceivedEventHandler(cn_Received);
                timer1.Start();
               
            //    220.120.94.93:27015
            }
        }
        void cn_Received(ClientNetwork cn, byte[] buffer)
        {
            byte[] by_header = new byte[2];
            Array.Copy(buffer, 0, by_header, 0, 2);
            short header = BitConverter.ToInt16(by_header, 0);
            string[] cmd = Encoding.UTF8.GetString(buffer, 2, buffer.Length - 2).Split('|');
            switch (header)
            {
                case (int)NetworkHEADER.DOCONNECTION:
                    ServerHost = cmd[0];
                    PacketSender ps = new PacketSender(ClientNetwork.ClientSocket);
                    ps.Send(NetworkHEADER.CONNECTION, cn.getsendstring());

                    break;
                case (int)NetworkHEADER.DISCONNECT:
                    cn.Close();
                    MessageBox.Show("You Are Kicked From Session");
                    break;
                case (int)NetworkHEADER.DENIED:
                    cn.Close();
                    MessageBox.Show("Server Denied Your Connection \n Check Server Or Max Players");
                    break;
                    
                case (int)NetworkHEADER.PLISTGET:
                    po.SendToServerP();
                    break;
                case (int)NetworkHEADER.POLISTGET:
                    po.SendToServerPO();
                    break;
            }
        }
        void cn_Disconnected(ClientNetwork cn)
        {
            cn.Close();
        }
        private bool CheckGameRun()
        {
            if (CheckProcess("csgo"))
            {
                MessageBox.Show("CSGO Is Already Running Please Run KAC Beforce Your game Run");
                Process.GetCurrentProcess().Kill();
                return true;
            }
            return false;
        }
        public static bool CheckProcess(string prname)
        {
            try
            {
                Process[] procss;
                procss = Process.GetProcesses();
                foreach (Process aProc in procss)
                {
                    if (aProc.ProcessName.ToString().Contains(prname))
                    {
                        return true;
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            return false;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckGameRun();
            if (!CheckProcess("Steam"))
            {
                MessageBox.Show("Can't find Steam Client");
                Process.GetCurrentProcess().Kill();
                return;
            }
            UIDCheck();
            po.init();
            po.Overwatch();
        }
        private void steamButton1_Click(object sender, EventArgs e)
        {
            Process.Start("http://eac.konachan.kr");
        }

        private void CheckGameProcess()
        {
            if(!gameattch)
            {
                GameProcessAttach = new Thread(GameAttach);
                GameProcessAttach.Start();
                gameattch = true;
            }
        }
        #region winapi
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        #endregion
        void GameAttach()
        {
            Thread.Sleep(5000);
            int chktime = 0;
            while (ClientNetwork.Connected)
            {
                if (IsFirstRunchk)
                {
                    if (!CheckProcess("csgo"))
                    {
                        CN.Close();
                        Process.GetCurrentProcess().Kill();
                    }
                }
                else
                {
                    if (CheckProcess("Steam"))
                    {
                        Console.WriteLine("[Client] Steam Client Found..");
                        if (CheckProcess("csgo"))
                        {
                            int ahWnd = FindWindow(null, "Counter-Strike: Global Offensive");
                            if (ahWnd != 0)
                            {
                                IsFirstRunchk = true;
                                Console.WriteLine("[Client] csgo Found..");
                            }
                            else
                            {
                                Console.WriteLine("[Client] csgo Can not Found..");
                            }
                        }
                    }
                    if (chktime == 100)
                    {
                        MessageBox.Show("Game Not Running \n NullPointorException");
                        CN.Close();
                        Process.GetCurrentProcess().Kill();
                        GameProcessAttach.Abort();
                    }
                    chktime++;
                }
                Thread.Sleep(100);
            }
        }
        private void Domethod1()
        {
            this.Size = new Size(345, 140);
            this.MaximumSize = new Size(345, 140);
            this.MinimumSize = new Size(345, 140);
            steamTheme1.Size = new Size(345, 140);
            steamTheme1.MaximumSize = new Size(345, 140);
            steamTheme1.MinimumSize = new Size(345, 140);
            panel1.Visible = true;

        }
        private void Domethod2()
        {
            this.Size = new Size(345, 180);
            this.MaximumSize = new Size(345, 180);
            this.MinimumSize = new Size(345, 180);
            steamTheme1.Size = new Size(345, 180);
            steamTheme1.MaximumSize = new Size(345, 180);
            steamTheme1.MinimumSize = new Size(345, 180);
            panel1.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!ClientNetwork.Connected)
            {
                Continue.Enabled = true;
                Domethod2();
                isgamestart = false;
                timer1.Stop();
            }
            else
            {
                Continue.Enabled = false;
                if (!isgamestart)
                {
                    isgamestart = true;
                    po.SendOWLogEvrytime();
                    SteamAPI.SteamGameRun(ServerHost);
                }
                CheckGameProcess();
                Domethod1();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();

        }
    }
}
