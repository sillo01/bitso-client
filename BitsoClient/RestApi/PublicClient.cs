using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using bitso_client.RestApi.Parameters;

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
            string queryString = Params.ToQueryString(new Book(book));
            string url = $"{baseUrl}/ticker/{queryString}";
            
            var apiResponse = await Get<bitso_client.Models.Ticker.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<bitso_client.Models.OrderBook.Payload> GetOrderBook(string book, bool? aggregate)
        {
            string queryString = Params.ToQueryString(new Book(book), new Aggregate(aggregate));
            string url = $"{baseUrl}/order_book/{queryString}";
            
            var apiResponse = await Get<bitso_client.Models.OrderBook.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<bitso_client.Models.Trades.Trade[]> GetTrades(
            string book,
            int? marker,
            string? sort,
            int? limit)
        {
            string queryString = Params.ToQueryString(
                new Book(book),
                new Marker(marker),
                new Sort(sort),
                new Limit(limit));
            string url = $"{baseUrl}/trades/{queryString}";

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