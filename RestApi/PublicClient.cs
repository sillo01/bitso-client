using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace bitso_client.RestApi
{
    public class PublicClient
    {
        private readonly HttpClient client;
        private readonly string baseUrl;

        public PublicClient(HttpClient client, string baseUrl)
        {
            this.client = client;
            this.baseUrl = baseUrl;
        }

        public async Task<bitso_client.Models.Ticker.Payload> GetTicker(string book)
        {
            string queryParams = $"book={book}";
            string url = $"{baseUrl}/ticker/?{queryParams}";
            
            var apiResponse = await Get<bitso_client.Models.Ticker.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<bitso_client.Models.OrderBook.Payload> GetOrderBook(string book, bool? aggregate)
        {
            string queryParams = $"book={book}" 
                + (aggregate.HasValue ? $"aggregate={aggregate.Value.ToString()}" : "");
            string url = $"{baseUrl}/order_book/?{queryParams}";
            
            var apiResponse = await Get<bitso_client.Models.OrderBook.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<bitso_client.Models.Trades.Trades[]> GetTrades(string book)
        {
            string queryParams = $"book={book}";
            string url = $"{baseUrl}/trades/?{queryParams}";

            var apiResponse = await Get<bitso_client.Models.Trades.Response>(url);

            return apiResponse.Payload;
        }

        private async Task<T> Get<T>(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonContent = await response.Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}