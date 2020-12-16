using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
using Newtonsoft.Json;

namespace APIConsumer
{
    public class Worker<T>
    {
        public string URI = "http://localhost:51969/api/cars";

        //Min Consumer bruger applikationslaget, den bruger HTTP til at sende f.eks Get request og får dataen tilbage
        //hvor der er json objekter i body'en
        //HTTP bygger oven på TCP protokollen og derfor tilbydes der RDT og flow control
        public async Task<IList<T>> GetAllAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(URI);
                IList<T> clist = JsonConvert.DeserializeObject<IList<T>>(content);
                return clist;
            }
        }
        public async Task<T> GetByIdAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync($"{URI}/{id}");
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
        public async Task<T> GetByTypeAsync(string type)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync($"{URI}/{type}");
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
        public async Task PostAsync(T item)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string content = JsonConvert.SerializeObject(item);
                    StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    await client.PostAsync(URI, stringContent);
                    Console.WriteLine("This is done!");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        public async Task PutAsync(T item, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = JsonConvert.SerializeObject(item);
                StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                await client.PutAsync(URI + $"/{id}", stringContent);
            }
        }
        public async Task DeleteItemAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync(URI + $"/{id}");
            }
        }
    }
}
