using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ModelLibrary;
using Newtonsoft.Json;

namespace TCPJsonSender
{
    public class Server
    {
        public void Start()
        {
            TcpListener serverListener = new TcpListener(IPAddress.Any, 10001);
            serverListener.Start();
            Console.WriteLine("Server Activated");
            while (true)
            {
                TcpClient socket = serverListener.AcceptTcpClient();
                Task.Run(() => DoClient(socket));
            }
        }

        public void DoClient(TcpClient client)
        {
            using (client)
            {
                try
                {
                    Stream ns = client.GetStream();
                    StreamReader sr = new StreamReader(ns);
                    StreamWriter sw = new StreamWriter(ns);
                    sw.AutoFlush = true;
                    string line = sr.ReadLine();

                    Car tCar = JsonConvert.DeserializeObject<Car>(line);
                    Console.WriteLine(tCar);
                    string backCar = JsonConvert.SerializeObject(tCar);

                    sw.WriteLine(backCar);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Client Disconnected" + ex);
                }

                if (client.Connected == false)
                {
                    Console.WriteLine($"Client left the server");
                    client.Dispose();
                }
            }
        }
    }
}
