using System.Net.Http;
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
            string url = $"/ticker/{queryString}";
            
            var apiResponse = await Get<BitsoClient.Models.Ticker.Response>(url);

            return apiResponse.Payload;
        }

        public async Task<BitsoClient.Models.OrderBook.Payload> GetOrderBookAsync(
            string book,
            bool? aggregate = null)
        {
            string queryString = Params.ToQueryString(new Book(book), new Aggregate(aggregate));
            string url = $"/order_book/{queryString}";
            
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
            string url = $"/trades/{queryString}";

            var apiResponse = await Get<BitsoClient.Models.Trades.Response>(url);

            return apiResponse.Payload;
        }

        private async Task<T> Get<T>(string path)
        {
            REquestOptions options = new REquestOptions(baseUrl, path);
            string content = await _requester.SendAsycn(options);
            return  JsonConvert.DeserializeObject<T>(content);
        }
    }
}