using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

using BitsoClient.RestApi.Parameters;
using BitsoClient.Models;
using BitsoClient.Models.Orders;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<Reponse> GetOpenOrdersAsync(
            string book,
            int? marker = null,
            string sort = null,
            int? limit = null)
        {
            string endpoint = $"/{apiVersion}/open_orders";
            string queryString = Params.ToQueryString(
                new Book(book),
                new Marker(marker),
                new Sort(sort),
                new Limit(limit));
            var response = await SendRequest<Models.Orders.Order[]>(HttpMethod.Get, $"{endpoint}{queryString}");
            return new Models.Orders.Reponse()
            {
                Success = response.Success,
                Payload = response.Payload,
                Error = response.Error
            };
        }

        public async Task<ApiResponse<Order>> LookupOrderAsync(string orderId)
        {
            string endpoint = $"/{apiVersion}/orders/{orderId}/";
            ApiResponse<Order[]> response = await SendRequest<Order[]>(HttpMethod.Get, endpoint);
            return new ApiResponse<Order>()
            {
                Success = response.Success,
                Error = response.Error,
                Payload = (response.Payload != null && response.Payload.Length > 0) ? response.Payload[0] : null
            };
        }

        public async Task<ApiResponse<Order[]>> LookupOrdersAsync(string[] oids)
        {
            string endpoint = $"/{apiVersion}/orders/{string.Join("-", oids)}/";
            return await SendRequest<Order[]>(HttpMethod.Get, endpoint);
        }

        public async Task<ApiResponse<OrderCreated>> PlaceOrderAsync(Models.Orders.NewOrder order)
        {
            string endpoint = $"/{apiVersion}/orders/";
            return await SendRequest<OrderCreated>(HttpMethod.Post, endpoint, JsonConvert.SerializeObject(order));
        }
    }
}