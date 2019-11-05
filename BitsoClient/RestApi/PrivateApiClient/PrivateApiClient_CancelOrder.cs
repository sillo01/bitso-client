using System.Threading.Tasks;
using System.Net.Http;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<Models.ApiResponse<string[]>> CancelOrderAsync(string orderId)
        {
            string endpoint = $"/{apiVersion}/orders/{orderId}/";
            return await SendRequest<string[]>(HttpMethod.Delete, endpoint);
        }

        public async Task<Models.ApiResponse<string[]>> CancelOrdersAsync(string[] oids)
        {
            string endpoint = $"/{apiVersion}/orders/{string.Join("-", oids)}/";
            return await SendRequest<string[]>(HttpMethod.Delete, endpoint);
        }

        public async Task<Models.ApiResponse<string[]>> CancelAllOrdersAsync()
        {
            string endpoint = $"/{apiVersion}/orders/all/";
            return await SendRequest<string[]>(HttpMethod.Delete, endpoint);
        }
    }
}