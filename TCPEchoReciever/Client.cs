using System;
using System.IO;
using System.Net.Sockets;
using ModelLibrary;
using Newtonsoft.Json;

namespace TCPJsonReciever
{
    public class Client
    {
        public void Start()
        {
            TcpClient client = new TcpClient("localhost",10001);
            using (client)
            {
                Stream ns = client.GetStream();

                StreamWriter sw = new StreamWriter(ns);
                StreamReader sr = new StreamReader(ns);
                sw.AutoFlush = true;

                Car tCar = new Car()
                {
                    Color = "Blue",
                    RegNo = "12345678",
                    Name = "Ford"
                };

                sw.WriteLine(JsonConvert.SerializeObject(tCar));
                string fromServerJsonString = sr.ReadLine();

                Car fromServerJsonObject = JsonConvert.DeserializeObject<Car>(fromServerJsonString);

                Console.WriteLine(fromServerJsonObject);


            }
        }
    }
}
