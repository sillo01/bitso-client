using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public interface IPrivateApiClient
    {
        Task<Models.AccountStatus.Response> GetAccountStatus();
        Task<Models.AccountBalance.Response> GetAccountBalance();
        Task<Models.Orders.Reponse> GetOpenOrders(string book, int? marker = null, string sort = null, int? limit = null);
        Task<Models.ApiResponse<string[]>> CancelOrder(string orderId);
        Task<Models.ApiResponse<string[]>> CancelOrders(string[] oids);
        Task<Models.ApiResponse<string[]>> CancelAllOrders();
        Task<Models.ApiResponse<Models.Orders.OrderCreated>> PlaceOrder(Models.Orders.NewOrder order);
    }
}