using System;

namespace TCPJsonSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Started");

            Server server = new Server();
            server.Start();
        }
    }
}
