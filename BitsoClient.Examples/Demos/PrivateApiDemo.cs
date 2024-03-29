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
            var response = await apiClient.GetAccountStatusAsync();

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
            var response = await apiClient.GetOpenOrdersAsync("eth_mxn");

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
            var response = await apiClient.CancelOrderAsync(orderId);

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
            Models.Orders.NewOrder order = new Models.Orders.NewOrder("eth_mxn", "buy", "limit")
            {
                Major = "0.03631629",
                Price = "3496.01"
            };
            var response = await apiClient.PlaceOrderAsync(order);

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