using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPEchoSender
{
    public class Server
    {
        public void Start()
        {
            TcpListener serverSide = new TcpListener(IPAddress.Any, 10001);

            serverSide.Start();
            while (true)
            {
                TcpClient socket = serverSide.AcceptTcpClient();
                Console.WriteLine("Server Activated");

                Task.Run(() => DoClient(socket));
            }
        }

        public void DoClient(TcpClient client)
        {
            using (client)
            {
                while (true)
                {
                    try
                    {
                        Stream ns = client.GetStream();
                        StreamReader sr = new StreamReader(ns);
                        StreamWriter sw = new StreamWriter(ns);

                        string line = sr.ReadLine();
                        sw.WriteLine(line);
                        sw.AutoFlush = true;

                        Console.WriteLine(line);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Connection to the Client ended unexpectedly");
                    }

                    if (client.Connected == false)
                    {
                        Console.WriteLine($"Client left the server");
                        client.Dispose();
                        break;
                    }
                }
            }
        }





    }
}
