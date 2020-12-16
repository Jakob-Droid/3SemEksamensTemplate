using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace TCPEchoReciever
{
    public class Client
    {
        public void Start()
        {
            TcpClient socket = new TcpClient("192.168.0.19", 10001);

            using (socket)
            {
                Stream ns = socket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                while (true)
                {
                    try
                    {
                        string line = Console.ReadLine();
                        sw.WriteLine(line);
                        Console.WriteLine(sr.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Server is offline!");
                    }
                    
                }
            }
        }





    }
}
