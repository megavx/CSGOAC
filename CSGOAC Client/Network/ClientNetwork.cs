using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Management;
using System.Net;
namespace CSGOAC_Client.Network
{
    class ClientNetwork
    {
        public byte[] buffer = new byte[8192];
        public static Socket ClientSocket;
        Thread th;
        IPEndPoint IEP;

        static bool connected = false;

        public delegate void ReceivedEventHandler(ClientNetwork cn, byte[] received);
        public event ReceivedEventHandler Received;
        public delegate void DisconnectedEventHandler(ClientNetwork cn);
        public event DisconnectedEventHandler Disconnected;



        public ClientNetwork(String ip, int port)
        {
            IEP = new IPEndPoint(IPAddress.Parse(ip), port);
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connect()
        {
            ThreadStart tt = new ThreadStart(ConnectTH);
            th = new Thread(tt);
            th.Start();
        }
        public void Close()
        {
            ClientSocket.Close();
            connected = false;
        }
        void ConnectTH()
        {
            try
            {

                ClientSocket.BeginConnect(IEP, new AsyncCallback(ConnectCallback), ClientSocket);
            }catch(SocketException sokex)
            {
                System.Windows.Forms.MessageBox.Show(sokex.ErrorCode.ToString());
            }
          

        }
        void ConnectCallback(IAsyncResult iar)
        {
           try
           {
                if (ClientSocket.Connected)
                {
                    PacketSender ps = new PacketSender(ClientSocket);
                    ps.Send(NetworkHEADER.HANDSHAKE, "csgokacserver|");

                    ClientSocket.EndConnect(iar);
                    connected = true;
                    ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), buffer);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Server Connection Error");
                }
            }
            catch (SocketException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.SocketErrorCode.ToString() + " CODE : " + ex.ErrorCode.ToString());

            }


        }
        void ReceiveCallback(IAsyncResult iar)
        {
            byte[] buffer = (byte[])iar.AsyncState;

            try
            {
                int rec = ClientSocket.EndReceive(iar);
                if (rec != 0)
                {
                    Received(this, buffer);
                }
                else
                {
                    Disconnected(this);
                    connected = false;
                    return;
                }
                ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), buffer);
            }
            catch
            {
                Console.WriteLine("[Client]ReciveCallbackerror");
                Disconnected(this);
                th.Abort();
               
                connected = false;
            }

        }
       
        public static bool Connected
        {
            get { return connected; }
        }
        #region method
        public string getsendstring()
        {
            //스팀아이디 os / cpu / 램
            return MainForm.SteamID + "|";
        }
        #endregion
    }
}
