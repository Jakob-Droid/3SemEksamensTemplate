using System;
using System.Threading.Tasks;
using ModelLibrary;

namespace APIConsumer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Worker<Car> worker = new Worker<Car>();

            Console.WriteLine("Data Loading:");
            Car item = new Car() { Color = "Orange", Id = 16, Name = "Ford", RegNo = "12345678" };
            Car item2 = new Car() { Color = "Blue", Id = 17, Name = "Mustang", RegNo = "12345678" };
            Car item3 = new Car() { Color = "Green", Id = 18, Name = "Ford", RegNo = "12345678" };

            await worker.PostAsync(item);
            await worker.PostAsync(item2);
            await worker.PostAsync(item3);

            Console.WriteLine("Car Objects Initialized");


            Console.WriteLine(worker.GetByIdAsync(17).Result);
            Console.WriteLine();
            Console.WriteLine(string.Join("\n", worker.GetAllAsync().Result));
            Console.WriteLine();

            await worker.DeleteItemAsync(17);
            await worker.PutAsync(new Car() {Color = "Gray", Id = 16, Name = "Ferrari", RegNo = "12345678"}, 16);

            Console.WriteLine();
            Console.WriteLine(string.Join("\n", worker.GetAllAsync().Result));

            Console.ReadLine();

            Console.WriteLine("Operations Done");
        }
    }
}
