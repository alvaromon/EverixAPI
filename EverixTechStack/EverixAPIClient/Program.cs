using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EverixAPIClient
{
    public class Program
    {
        public static EverixHTTPClient client;

        static async Task Main(string[] args) 
        { 
            await CreateHTTPClient();

            Console.WriteLine(client.GetPrototypeString());

            Console.ReadLine();
        }


        public static async Task CreateHTTPClient()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))))
                .AddJsonFile("EverixHTTPClient.json", optional: false);

            IConfigurationRoot config = builder.Build();

            client = new EverixHTTPClient(config);
        }
    }
}
