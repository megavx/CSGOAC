using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

public class Info
{
    public Socket sock;
    public Guid ID;
    public string RemoteAddress;
    public byte[] buffer = new byte[8192];
    public Info(Socket sock)
    {
        this.sock = sock; 
        ID = Guid.NewGuid();
        RemoteAddress = sock.RemoteEndPoint.ToString(); 
    }

    public void Send(NetworkHEADER header, string text)
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] by_header = BitConverter.GetBytes((ushort)header);
            byte[] buffer = new byte[data.Length + 2];
            Array.Copy(data, 0, buffer, 2, data.Length);
            Array.Copy(by_header, buffer, by_header.Length);
            sock.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback((ar) =>
            {
                sock.EndSend(ar);
            }), buffer);

        }
        catch (SocketException ex)
        {
          //  System.Windows.Forms.MessageBox.Show(ex.SocketErrorCode.ToString() + " CODE : " + ex.ErrorCode.ToString());

        }
    }
}
