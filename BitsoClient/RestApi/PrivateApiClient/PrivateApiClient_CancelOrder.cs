using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<Models.ApiResponse<string[]>> CancelOrderAsync(string orderId)
        {
            string endpoint = $"/{apiVersion}/orders/{orderId}/";
            RequestOptions options = new RequestOptions("DELETE", endpoint);
            return await SendRequest<string[]>(options);
        }

        public async Task<Models.ApiResponse<string[]>> CancelOrdersAsync(string[] oids)
        {
            string endpoint = $"/{apiVersion}/orders/{string.Join("-", oids)}/";
            RequestOptions options = new RequestOptions("DELETE", endpoint);
            return await SendRequest<string[]>(options);
        }

        public async Task<Models.ApiResponse<string[]>> CancelAllOrdersAsync()
        {
            string endpoint = $"/{apiVersion}/orders/all/";
            RequestOptions options = new RequestOptions("DELETE", endpoint);
            return await SendRequest<string[]>(options);
        }
    }
}