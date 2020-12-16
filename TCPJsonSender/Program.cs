using System;

namespace TCPEchoSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server Ready");
            Server server = new Server();

            server.Start();
        }
    }
}
