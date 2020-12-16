using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ModelLibrary;

namespace UDPJsonSender
{
    public class Server
    {
        public void Start()
        {
            Console.WriteLine("Server Started!");
            Car car = new Car(){Color = "Blue", Name = "Ford", RegNo = "12345678"};

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            UdpClient udpClient = new UdpClient("127.0.0.1", 11001);

            IPEndPoint remoteEndPoint = new IPEndPoint(ip, 11001);

            Byte[] sendBytes = Encoding.ASCII.GetBytes(car.ToString());
            udpClient.Send(sendBytes, sendBytes.Length);
            Console.WriteLine("Server Send Message");
        }
    }
}
