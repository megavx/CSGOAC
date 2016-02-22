using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace CSGOAC_Client.Network
{
    class PacketSender
    {
        Socket s;
        public PacketSender(Socket s)
        {
            this.s = s;
        }
        public void Send(NetworkHEADER header, string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] by_header = BitConverter.GetBytes((ushort)header);
            byte[] buffer = new byte[data.Length + 2];
            Array.Copy(data, 0, buffer, 2, data.Length);
            Array.Copy(by_header, buffer, by_header.Length);
            try
            {
                s.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(send_Callback), s);
            }
            catch 
            {
                s.Close();
            }
        }
        void send_Callback(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
        }
    }
}
