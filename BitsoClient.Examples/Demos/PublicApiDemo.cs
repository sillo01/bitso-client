using System;
using System.Threading.Tasks;
using System.Net.Http;
using BitsoClient.RestApi;

namespace BitsoClient.Examples.Demos
{
    public class PublicApiDemo
    {
        private readonly PublicApiClient client;

        public PublicApiDemo(HttpClient client)
        {
            string baseUrl = Environment.GetEnvironmentVariable("BaseUrl");
            var config = new ClientConfiguration(baseUrl, null, null, null);
            var requester = new HttpRequester(client);
            this.client = new PublicApiClient(requester, config);
        }

        public async Task PrintOrderBook()
        {
            var payload = await client.GetOrderBookAsync("btc_mxn");

            Console.WriteLine(payload);
        }
    }
}