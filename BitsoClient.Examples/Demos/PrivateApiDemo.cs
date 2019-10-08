using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using BitsoClient.RestApi;

namespace BitsoClient.Examples.Demos
{
    public class PrivateApiDemo
    {
        private readonly PrivateApiClient apiClient;
        
        public PrivateApiDemo(HttpClient client)
        {
            string baseUrl = Environment.GetEnvironmentVariable("BaseUrl");
            string key = Environment.GetEnvironmentVariable("ApiKey");
            string secret = Environment.GetEnvironmentVariable("ApiSecret");
            string version = Environment.GetEnvironmentVariable("ApiVersion");
            
            ClientConfiguration config = new ClientConfiguration(baseUrl, key, secret, version);
            HttpRequester requester = new HttpRequester(client);

            apiClient = new PrivateApiClient(requester, config);
        }

        public async Task PrintAccountStatus()
        {
            var response = await apiClient.GetAccountStatus();

            Console.WriteLine(JsonConvert.SerializeObject(response.Payload));
        }
    }
}