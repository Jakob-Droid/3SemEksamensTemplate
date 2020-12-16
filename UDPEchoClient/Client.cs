using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPEchoClient
{
    public class Client
    {
        public const int port = 11001;
        public void Start()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            UdpClient client = new UdpClient("127.0.0.1", port);
            IPEndPoint remoteEndPoint = new IPEndPoint(ip, port);

            try
            {
                Console.WriteLine("Server Started");
                while (true)
                {
                    Console.WriteLine("Enter something to be echoed back!");
                    string line = Console.ReadLine();

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(line);

                    Console.WriteLine("Sending package");
                    client.Send(sendBytes, sendBytes.Length);

                    Console.WriteLine();
                    Console.WriteLine();
                    Byte[] receivedBytes = client.Receive(ref remoteEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receivedBytes);
                    Console.WriteLine("Received package: " + "'" + receivedData + "'");
                    Console.WriteLine();
                    Console.WriteLine("Operation complete!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }




    }
}
