using System;

namespace TCPEchoReciever
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Ready");
            Client client = new Client();
            client.Start();
        }
    }
}
