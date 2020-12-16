using System;

namespace UDPBroadcastingClient
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
