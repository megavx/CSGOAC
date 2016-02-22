using System;
using System.Collections.Generic;

using System.Text;

using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Threading;
using CSGOAC_Client.Network;
namespace CSGOAC_Client.ProcessOW
{
    public class ProcessOverwatch
    {
        public static List<ProcessList> prlist = new List<ProcessList>();
        public static List<ProcessList> overwatchlist = new List<ProcessList>();
        public static List<ProcessList> SendList = new List<ProcessList>();

        public List<ProcessList> getprocesslist()
        {
            return overwatchlist;
        }
        public List<ProcessList> getprocesslist2()
        {
            return prlist;
        }
        public void init()
        {
            try
            {
                IEnumerable<ProcessData> test = GetProcesses();
                foreach (var item in test)
                {
                    if (item.ExecutablePath != null)
                    {
                        bool tttt = false;
                        for (int a = 0; a < sysprocess.Length; a++)
                        {
                            if (sysprocess[a].Contains(item.Name))
                            {
                                tttt = true;
                            }
                        }
                        if (!tttt)
                        {
                            ProcessList pl = new ProcessList();
                            pl.Processname = item.Name;
                            pl.PID = item.ProcessId.ToString();
                            pl.ProcessRunpath = item.ExecutablePath;
                            prlist.Add(pl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public struct ProcessData
        {
            public string Name;
            public string ExecutablePath;
            public int ProcessId;
        }

        public static IEnumerable<ProcessData> GetProcesses(int pid = -1, string name = "")
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append("SELECT * FROM Win32_Process");
            if (pid >= 0)
            {
                queryBuilder.Append($"WHERE ProcessId= {pid}");
            }
            if (name.Length > 0 && pid == -1)
            {
                queryBuilder.Append($"WHERE Caption ='{name}'");
            }
            using (var searcher = new ManagementObjectSearcher(queryBuilder.ToString()))
            {
                using (var result = searcher.Get())
                {
                    foreach (var item in result)
                    {
                        yield return new ProcessData()
                        {
                            Name = item["Caption"].ToString(),
                            ExecutablePath = item["ExecutablePath"]?.ToString(),
                            ProcessId = int.Parse(item["ProcessId"].ToString())
                        };
                    }
                }
            }
        }
        #region sysprocess
        public static string[] sysprocess = {
            "savedump.exe",
            "DllHost.exe",
            "RustClient.exe",
            "csgo.exe",
            "savroam.exe",
            "savscan.exe",
            "savservice.exe",
            "scan32.exe",
            "scandisk.exe",
            "scanningprocess.exe",
            "scanpst.exe",
            "scanregw.exe",
            "scardsvr.exe",
            "sccertpropschedhlp.exe",
            "schedul2.exe",
            "scm.exe",
            "service.exe",
            "services.exe",
            "sessmgr.exe",
            "csrss.exe",
            "Dwm.exe",
            "spoolsv.exe",
            "nvvsvc.exe",
            "winlogon.exe",
            "lsm.exe",
            "lsass.exe",
            "services.exe",
            "conhost.exe",
            "seticon.exe",
            "setup50.exe",
            "sgbhp.exe",
            "sgmain.exe",
            "shadow.exe",
            "shotkey.exe",
            "shutdown.exe",
            "shwiconem.exe",
            "sigverif.exe",
            "siteadv.exe",
            "skeys.exe",
            "skytel.exe",
            "slrundll.exe",
            "slsvc.exe",
            "smagent.exe",
            "smax4.exe",
            "smlogsvc.exe",
            "smss.exe",
            "sndmon.exe",
            "sndsrvc.exe",
            "sndvol32.exe",
            "snmp.exe",
            "snmptrap.exe",
            "soundtrax.exe",
            "spamsub.exe",
            "spamsubtract.exe",
            "spcustom.dll",
            "spdwnwxp.exe",
            "spmgr.exe",
            "spool32.exe",
            "spoolss.exe",
            "spoolsv.exe",
            "sprestrt.exe",
            "sp_rsser.exe",
            "sptip.dll",
            "spuninst.exe",
            "spupdsvc.exe",
            "spyeraser.exe",
            "spysub.exe",
            "spysweeper.exe",
            "sqlmaint.exe",
            "sqlmangr.exe",
            "srvany.exe",
            "srvload.exe",
            "ssdpsrv.exe",
            "sshd.exe",
            "ssonsvr.exe",
            "stacmon.exe",
            "starwindservice.exe",
            "statemgr.exe",
            "stillimagemonitor",
            "stimon.exe",
            "stinger.exe",
            "stmgr.exe",
            "support.exe",
            "swagent.exe",
            "swdoctor.exe",
            "sweepsrv.sys",
            "switcher.exe",
            "swupdtmr.exe",
            "sxgtkbar.exe",
            "symsport.exe",
            "symwsc.exe",
            "syntpenh.exe",
            "sysfader.exe",
            "sysmon.exe",
            "ImageSAFERStart_X64.exe",
            "ImageSAFERStart_X86.exe",
            "sysocmgr.exe",
            "system",
            "WUDFHost.exe",
            "unsecapp.exe",
            "taskhost.exe",
            "system idle process",
            "systray.exe"
        };
        #endregion
        public void Overwatch()
        {
            try
            {
                IEnumerable<ProcessData> test = GetProcesses();
                foreach (var item in test)
                {
                    if (item.ExecutablePath != null)
                    {
                        bool tttt = false;
                        for (int a = 0; a < sysprocess.Length; a++)
                        {
                            if (sysprocess[a].Contains(item.Name))
                            {
                                tttt = true;
                            }
                        }
                        if (!tttt)
                        {
                            ProcessList pl = new ProcessList();
                            pl.Processname = item.Name;
                            pl.PID = item.ProcessId.ToString();
                            pl.ProcessRunpath = item.ExecutablePath;

                            bool check1 = false;
                            for (int a = 0; a < prlist.Count; a++)
                            {
                                if (prlist[a].PID == item.ProcessId.ToString())
                                {
                                    check1 = true;
                                    break;
                                }
                            }
                            if (!check1)
                            {
                                bool check2 = false;
                                for (int b = 0; b < overwatchlist.Count; b++) // 오버와치 이미등록되어있는지체크
                                {
                                    if (overwatchlist[b].PID == item.ProcessId.ToString())
                                    {
                                        check2 = true;
                                    }
                                }
                                if (!check2)
                                {
                                    bool check3 = false;
                                    for (int c = 0; c< SendList.Count; c++ )
                                    {
                                        if(SendList[c].PID == item.ProcessId.ToString())
                                        {
                                            check3 = true;
                                        }
                                    }
                                    if (!check3)
                                    {
                                        overwatchlist.Add(pl);
                                        Console.WriteLine("OverWatchlist added" + pl.Processname);
                                    }
                                }
                            }
                        }
                    }
                }  
            }
            catch
            {

            }
        }
        public void Stop()
        {
            OWThread.Abort();
            OW.Abort();
        }
        Thread OWThread;
        Thread OW;
        public void SendOWLogEvrytime()
        {
            ThreadStart ts = new ThreadStart(OWLO);
            OWThread = new Thread(ts);
            OWThread.Start();
            ThreadStart tsa = new ThreadStart(Ow);
           OW = new Thread(tsa);
            OW.Start();
        }
        void Ow()
        {
            while (ClientNetwork.Connected)
            {
                Overwatch();
                Thread.Sleep(1000);
            }
        }
        void OWLO()
        {
            while(ClientNetwork.Connected)
            {
                SendToServerPO();
                Thread.Sleep(600 * 100);
            }
        }
        public void SendToServerP()
        {
            PacketSender ps = new PacketSender(ClientNetwork.ClientSocket);
            int a = 0;
            for (int i = 0; i < prlist.Count; i++)
            {
                // pid // prname // prpath // 파일이름
                a++;
                Console.WriteLine("attempt send " + a.ToString());
                ps.Send(NetworkHEADER.PLISTGETRESPONSE, prlist[i].PID + "|" + prlist[i].Processname + "|" + prlist[i].ProcessRunpath + "|");
                Thread.Sleep(10);
            }

        }
        public void SendToServerPO()
        {
            string name = DateTime.Now.ToShortTimeString().Replace(':', '-');
            int a = 0;
            PacketSender ps = new PacketSender(ClientNetwork.ClientSocket);
            for (int i = 0; i < overwatchlist.Count; i++)
            {
                a++;
             
                Console.WriteLine("Overwatch attempt send " + a.ToString());
                ps.Send(NetworkHEADER.POLISTGETRESPONSE, overwatchlist[i].PID + "|" + overwatchlist[i].Processname + "|" + overwatchlist[i].ProcessRunpath + "|" + name + "|");
                SendList.Add(overwatchlist[i]);
                overwatchlist.Remove(overwatchlist[i]);

                Thread.Sleep(10);
            }
        }
    }
}
