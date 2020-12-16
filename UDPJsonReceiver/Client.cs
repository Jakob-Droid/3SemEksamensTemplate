using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPJsonReceiver
{
    public class Client
    {
        public void Start()
        {
            UdpClient client = new UdpClient(11001);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEndPoint = new IPEndPoint(ip, 11001);

            try
            {
                Console.WriteLine("Client is blocked");
                Byte[] receivedBytes = client.Receive(ref remoteEndPoint);
                Console.WriteLine("Client is now activated");

                string receivedData = Encoding.ASCII.GetString(receivedBytes);
                Console.WriteLine(receivedData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }







    }
}
