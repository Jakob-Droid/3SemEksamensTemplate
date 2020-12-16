using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPBroadcastingClient
{
    public class Client
    {
        public void Start()
        {
            UdpClient client = new UdpClient(11001);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                try
                {
                    Byte[] receivedBytes = client.Receive(ref endPoint);
                    string receivedData = Encoding.ASCII.GetString(receivedBytes);
                    Console.WriteLine(receivedData);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
