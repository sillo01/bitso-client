using System;
using System.Threading.Tasks;
using System.Net.Http;
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

            ClientConfiguration config = new ClientConfiguration(baseUrl, key, secret);
            HttpRequester requester = new HttpRequester(client);

            apiClient = new PrivateApiClient(requester, config);
        }

        public async Task PrintAccountStatus()
        {
            RequestOptions options = new RequestOptions("get", "account_status");
            var response = await apiClient.SendRequest(options);

            Console.WriteLine(response.Content);
        }
    }
}