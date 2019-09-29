using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using BitsoClient.RestApi.Parameters;

namespace BitsoClient.RestApi
{
    public class PublicApiClient
    {
        private readonly IHttpRequester _requester;
        private readonly string baseUrl;

        public PublicApiClient(IHttpRequester requester, string baseUrl)
        {
            _requester = requester;
            this.baseUrl = baseUrl;
        }

        public async Task<BitsoClient.Models.Ticker.Payload> GetTicker(string book)
        {
            string queryString = Params.ToQueryString(new Book(book));
            string url = $"{baseUrl}/ticker/{queryString}";
            
            var apiResponse = await Get<BitsoClient.Models.Ticker.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<BitsoClient.Models.OrderBook.Payload> GetOrderBook(
            string book,
            bool? aggregate = null)
        {
            string queryString = Params.ToQueryString(new Book(book), new Aggregate(aggregate));
            string url = $"{baseUrl}/order_book/{queryString}";
            
            var apiResponse = await Get<BitsoClient.Models.OrderBook.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<BitsoClient.Models.Trades.Trade[]> GetTrades(
            string book,
            int? marker = null,
            string sort = null,
            int? limit = null)
        {
            string queryString = Params.ToQueryString(
                new Book(book),
                new Marker(marker),
                new Sort(sort),
                new Limit(limit));
            string url = $"{baseUrl}/trades/{queryString}";

            var apiResponse = await Get<BitsoClient.Models.Trades.Response>(url);

            return apiResponse.Payload;
        }

        private async Task<T> Get<T>(string url)
        {
            string jsonContent = await _requester.GetAsync(url);
            return  JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}