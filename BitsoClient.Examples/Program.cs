using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using  BitsoClient.Examples.Demos;

namespace BitsoClient.Examples
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        
        static async Task Main(string[] args)
        {
            LoadConfig();

            var demo = new PrivateApiDemo(client);
            await demo.PrintAccountStatus();
        }

        private static void LoadConfig()
        {
            string basePath = Directory.GetCurrentDirectory();
            string settignsPath = basePath + "/BitsoClient.Examples/appsettings.json";
            var settings = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(settignsPath));

            foreach (var setting in settings)
            {
                Environment.SetEnvironmentVariable(setting.Key, setting.Value);
            }
        }
    }
}
