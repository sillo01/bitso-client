using System;
using System.Threading.Tasks;
using System.Net.Http;
using BitsoClient.RestApi;

namespace BitsoClient.Examples.Demos
{
    public class PrivateApiDemo
    {
        private readonly PrivateApiClient apiClient;
        private readonly string baseUrl = "https://api.bitso.com/v3/";
        
        public PrivateApiDemo(HttpClient client)
        {
            string key = "wDmzlbKScX";
            string secret = "0a85ee883c30ef32f219b6f789e15ee5";

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