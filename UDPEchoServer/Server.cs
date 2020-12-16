using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPEchoServer
{
    public class Server
    {
        public const int port = 11001;
        public void Start()
        {
            UdpClient server = new UdpClient(port);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEndPoint = new IPEndPoint(ip, port);

            try
            {
                Console.WriteLine("Server Started");
                while (true)
                {
                    Console.WriteLine("ready to receive");
                    Byte[] receivedBytes = server.Receive(ref remoteEndPoint);
                    Console.WriteLine("Received!");
                    string receivedData = Encoding.ASCII.GetString(receivedBytes);
                    Console.WriteLine("Received package: " + "'" + receivedData + "'");
                    Console.WriteLine("Sending back the Item --");
                    server.Send(receivedBytes, receivedBytes.Length, remoteEndPoint);
                    Console.WriteLine("--Package Send");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }





    }
}
