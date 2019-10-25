using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public interface IPublicApiClient
    {
        Task<BitsoClient.Models.Ticker.Payload> GetTickerAsync(string book);
        Task<BitsoClient.Models.OrderBook.Payload> GetOrderBookAsync(string book, bool? aggregate = null);
        Task<BitsoClient.Models.Trades.Trade[]> GetTradesAsync(string book, int? marker = null, string sort = null, int? limit = null);
    }
}