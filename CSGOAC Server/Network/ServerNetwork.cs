using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace CSGOAC_Server.Network
{
    public class ServerNetwork
    {
        Socket ServerSocket; // 서버소켓
        public List<Info> clients; // 클라이언트 리스트
                                   // 이벤트
        public delegate void ReceivedEventHandler(ServerNetwork sn, Info i, byte[] received);
        public event ReceivedEventHandler Received;
        public delegate void DisconnectedEventHandler(ServerNetwork cn, Info i);
        public event DisconnectedEventHandler Disconnected;
        // 이벤트
        Thread ServerThread; //서버 쓰레드
        int ServerPort; // 서버포트
       static bool listening = false;
        public ServerNetwork(int port)
        {
            // 인스턴스생성시
            this.ServerPort = port; // 포트정보를넘겨줌
            clients = new List<Info>(); //리스트초기화
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//소켓초기화
      
            Console.WriteLine("인스턴스생성됨");
        }
        public static bool Running
        {
            get { return listening; }
        }
        public void ServerOff()
        {
            try
            {
                ServerSocket.Close();
                ServerThread.Abort();
              //  ServerSocket.Close();
                listening = false;

                foreach (var f in clients)
                {
                    f.sock.Close();
                }
                clients.Clear();
            
            }
            catch
            {
             
            }
        }
        public void Listen() // 다른클래스에서 사용할수있게 public 한정자선언
        {
            try
            {
                ThreadStart ts = new ThreadStart(ListenTh); // 다중쓰레드
                ServerThread = new Thread(ts);
                ServerThread.Start();
                Console.WriteLine("서버시작(쓰레드시작)");
            }
            catch(SocketException SockErr)
            {
               MainForm.Logdo(SockErr.Message);
              
                System.Windows.Forms.MessageBox.Show(SockErr.Message + "Listen Error");
            }
        }
        void ListenTh() // 쓰레드로 루프돌릴부분
        {

            try
            {
                ServerSocket.Bind(new IPEndPoint(IPAddress.Any, ServerPort)); // 소켓 바인드
                ServerSocket.Listen(100);

                ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), ServerSocket); // listen 시작
                Console.WriteLine("서버 Listen 시작");
                listening = true;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unknown Error \n" + ex.Message);
            }
        }
        public void ConnectClose(Info i)
        {
        
            i.sock.Close();
            clients.Remove(i);
            Console.WriteLine("서버 Connect Close");
           
        }
        void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                Console.WriteLine("서버 AcceptCallback");
                Socket handler = (Socket)ar.AsyncState;
                Socket sock = handler.EndAccept(ar); 
                Info i = new Info(sock);
                clients.Add(i); 
               MainForm.Logdo("IP : " + i.RemoteAddress + " ID : " + i.ID); 
                sock.BeginReceive(i.buffer, 0, i.buffer.Length, SocketFlags.None, new AsyncCallback(NewReceiveCallback), i);
                handler.BeginAccept(new AsyncCallback(AcceptCallback), handler);
            }
            catch (Exception ex)
            {
               MainForm.Logdo(ex.Message);
            }
            
        }
        void NewReceiveCallback(IAsyncResult iar)
        {
            Console.WriteLine("서버 : New ReceiveCalback");
            Info KACNet = (Info)iar.AsyncState;
          try
         {

                int size = KACNet.sock.EndReceive(iar);

                if (size != 0)
                {
                    Received(this, KACNet, (byte[])KACNet.buffer.Clone());
                }
                else
                {
                    Console.WriteLine("NEW Receive Failed size zero data");
                    ConnectClose(KACNet);
                    return;
                }
                KACNet.sock.BeginReceive(KACNet.buffer, 0, KACNet.buffer.Length, SocketFlags.None, new AsyncCallback(NewReceiveCallback), KACNet);
            }
            catch (SocketException socketexception)
            {
                if (socketexception.ErrorCode==10054)
                {
                MainForm.Logdo(KACNet.RemoteAddress.Split(':')[0] + "Connection Closed[Disconnect]");

                }
                Disconnected(this, KACNet);
            }
            catch(ObjectDisposedException ex)
            {

            }
        }

    }
}
