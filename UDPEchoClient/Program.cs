using System;

namespace UDPEchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client:");
            Client client = new Client();
            client.Start();
        }
    }
}
