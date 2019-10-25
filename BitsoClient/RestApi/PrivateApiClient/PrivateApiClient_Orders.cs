using System.Threading.Tasks;

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
            RequestOptions options = new RequestOptions("GET", $"{endpoint}{queryString}");
            var respone = await SendRequest<Models.Orders.Order[]>(options);
            return new Models.Orders.Reponse()
            {
                Success = respone.Success,
                Payload = respone.Payload,
                Error = respone.Error
            };
        }

        public async Task<ApiResponse<Order[]>> LookupOrderAsync(string orderId)
        {
            string endpoint = $"/{apiVersion}/orders/{orderId}/";
            RequestOptions options = new RequestOptions("GET", endpoint);
            return await SendRequest<Order[]>(options);
        }

        public async Task<ApiResponse<Order[]>> LookupOrdersAsync(string[] oids)
        {
            string endpoint = $"/{apiVersion}/orders/{string.Join("-", oids)}/";
            RequestOptions options = new RequestOptions("GET", endpoint);
            return await SendRequest<Order[]>(options);
        }

        public async Task<ApiResponse<OrderCreated>> PlaceOrderAsync(Models.Orders.NewOrder order)
        {
            string endpoint = $"/{apiVersion}/orders/";
            RequestOptions options = new RequestOptions("POST", endpoint, order);
            return await SendRequest<OrderCreated>(options);
        }
    }
}