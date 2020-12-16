using System;

namespace UDPEchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server:");
            Server server = new Server();
            server.Start();
        }
    }
}
