using System;

namespace TCPJsonReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Started");



            Client client = new Client();

            client.Start();
        }
    }
}
