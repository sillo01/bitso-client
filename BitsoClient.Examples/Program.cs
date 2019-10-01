using System;
using System.Net.Http;
using System.Threading.Tasks;

using BitsoClient.RestApi;

namespace BitsoClient.Examples
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            string baseUrl = "https://api.bitso.com/v3/";

            HttpRequester requester = new HttpRequester(client);
            PublicApiClient apiClient = new PublicApiClient(requester, baseUrl);
            var payload = await apiClient.GetOrderBook("btc_mxn");

            Console.WriteLine(payload);
        }
    }
}
