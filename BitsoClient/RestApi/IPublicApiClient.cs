using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public interface IPublicApiClient
    {
        Task<BitsoClient.Models.Ticker.Payload> GetTicker(string book);
        Task<BitsoClient.Models.OrderBook.Payload> GetOrderBook(string book, bool? aggregate = null);
        Task<BitsoClient.Models.Trades.Trade[]> GetTrades(string book, int? marker = null, string sort = null, int? limit = null);
    }
}