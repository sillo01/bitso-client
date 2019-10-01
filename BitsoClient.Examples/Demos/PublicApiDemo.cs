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
            var requester = new HttpRequester(client);
            this.client = new PublicApiClient(requester, baseUrl);
        }

        public async Task PrintOrderBook()
        {
            var payload = await client.GetOrderBook("btc_mxn");

            Console.WriteLine(payload);
        }
    }
}