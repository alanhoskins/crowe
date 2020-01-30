using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Crowe
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };
            var message = new { Message = "hello world" };
            var result = httpClient.PostAsync("messages", new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")).Result;
            Console.WriteLine(result);
        }
    }
}
