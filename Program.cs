using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using bitso_client.RestApi;

namespace bitso_client
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            string baseUrl = "https://api.bitso.com/v3/";

            PublicClient apiClient = new PublicClient(client, baseUrl);
            var payload = await apiClient.GetTrades("btc_mxn");

            Console.WriteLine(JsonConvert.SerializeObject(payload));
        }
    }
}
