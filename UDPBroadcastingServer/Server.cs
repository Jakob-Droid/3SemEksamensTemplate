using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPBroadcastingServer
{
    public class Server
    {
        public void Start()
        {
            UdpClient server = new UdpClient()
            {
                EnableBroadcast = true
            };
            IPAddress ip = IPAddress.Broadcast;
            IPEndPoint remoteIpEndPoint = new IPEndPoint(ip, 11001);
            while (true)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes("BroadCasting This");
                server.Send(sendBytes, sendBytes.Length, remoteIpEndPoint);
            }
        }
    }
}
