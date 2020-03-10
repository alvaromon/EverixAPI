using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using API.Models;
using Microsoft.Extensions.Configuration;

namespace EverixAPIClient
{
    public class EverixHTTPClient
    {
        private static HttpClient client;
        private string baseAddress;
        private string baseAPIAddress;

        public EverixHTTPClient(IConfigurationRoot config)
        {
            baseAddress = config.GetSection("httpClient").GetSection("baseAddress").Value;
            baseAPIAddress = baseAddress + config.GetSection("httpClient").GetSection("apiPath").Value;

            client = new HttpClient();

            // client.BaseAddress = ;
        }

        ~EverixHTTPClient()
        {
            if (client != null)
            {
                client.CancelPendingRequests();
                client.Dispose();
            }
        }

        public String GetPrototypeString()
        {
            String dbValue = client.GetAsync(baseAPIAddress + "PrototypeTable").Result.Content.ReadAsStringAsync().Result;

            return dbValue;
        }


    }
}
