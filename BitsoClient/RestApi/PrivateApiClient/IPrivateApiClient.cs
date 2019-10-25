using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public interface IPrivateApiClient
    {
        Task<Models.AccountStatus.Response> GetAccountStatusAsync();
        Task<Models.AccountBalance.Response> GetAccountBalanceAsync();
        Task<Models.Orders.Reponse> GetOpenOrdersAsync(string book, int? marker = null, string sort = null, int? limit = null);
        Task<Models.ApiResponse<string[]>> CancelOrderAsync(string orderId);
        Task<Models.ApiResponse<string[]>> CancelOrdersAsync(string[] oids);
        Task<Models.ApiResponse<string[]>> CancelAllOrdersAsync();
        Task<Models.ApiResponse<Models.Orders.OrderCreated>> PlaceOrderAsync(Models.Orders.NewOrder order);
    }
}