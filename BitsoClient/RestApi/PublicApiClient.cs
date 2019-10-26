using System.Threading.Tasks;
using Newtonsoft.Json;

using BitsoClient.RestApi.Parameters;

namespace BitsoClient.RestApi
{
    public class PublicApiClient : IPublicApiClient
    {
        private readonly IHttpRequester _requester;
        private readonly string baseUrl;

        public PublicApiClient(IHttpRequester requester, ClientConfiguration config)
        {
            _requester = requester;
            this.baseUrl = $"{config.BaseUrl}/{config.ApiVersion}";
        }

        public async Task<BitsoClient.Models.Ticker.Payload> GetTickerAsync(string book)
        {
            string queryString = Params.ToQueryString(new Book(book));
            string url = $"{baseUrl}/ticker/{queryString}";
            
            var apiResponse = await Get<BitsoClient.Models.Ticker.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<BitsoClient.Models.OrderBook.Payload> GetOrderBookAsync(
            string book,
            bool? aggregate = null)
        {
            string queryString = Params.ToQueryString(new Book(book), new Aggregate(aggregate));
            string url = $"{baseUrl}/order_book/{queryString}";
            
            var apiResponse = await Get<BitsoClient.Models.OrderBook.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<BitsoClient.Models.Trades.Trade[]> GetTradesAsync(
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