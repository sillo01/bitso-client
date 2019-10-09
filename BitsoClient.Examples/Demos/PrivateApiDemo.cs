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
            
            ClientConfiguration config = new ClientConfiguration(baseUrl, version, key, secret);
            HttpRequester requester = new HttpRequester(client);

            apiClient = new PrivateApiClient(requester, config);
        }

        public async Task PrintAccountStatus()
        {
            var response = await apiClient.GetAccountStatus();

            if (response.Success)
            {
                Console.WriteLine(JsonConvert.SerializeObject(response.Payload));
            }
            else
            {
                Console.WriteLine(JsonConvert.SerializeObject(response.Error));
            }
        }

        public async Task PrintOpenOrders()
        {
            var response = await apiClient.GetOpenOrders("eth_mxn");

            if (response.Success)
            {
                Console.WriteLine(JsonConvert.SerializeObject(response.Payload));
            }
            else
            {
                Console.WriteLine(JsonConvert.SerializeObject(response.Error));
            }
        }

        public async Task PrintCancelOrder()
        {
            string orderId = "ZqXWSvtXUIPLRZz9";
            var response = await apiClient.CancelOrder(orderId);

            if (response.Success)
            {
                Console.WriteLine(JsonConvert.SerializeObject(response.Payload));
            }
            else
            {
                Console.WriteLine(JsonConvert.SerializeObject(response.Error));
            }
        }

        public async Task PrintPlaceOrder()
        {
            Models.Orders.NewOrder order = new Models.Orders.NewOrder()
            {
                book = "eth_mxn",
                side = "buy",
                type = "limit",
                major = "0.03631629",
                price = "3496.01"
            };
            var response = await apiClient.PlaceOrder(order);

            if (response.Success)
            {
                Console.WriteLine(JsonConvert.SerializeObject(response.Payload));
            }
            else
            {
                Console.WriteLine(JsonConvert.SerializeObject(response.Error));
            }
        }
    }
}