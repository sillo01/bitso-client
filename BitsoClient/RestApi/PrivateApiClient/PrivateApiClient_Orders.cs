using System.Threading.Tasks;

using BitsoClient.RestApi.Parameters;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<Models.Orders.Reponse> GetOpenOrders(
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

        public async Task<Models.ApiResponse<string[]>> CancelOrder(string orderId)
        {
            string endpoint = $"/{apiVersion}/orders/{orderId}/";
            RequestOptions options = new RequestOptions("DELETE", endpoint);
            return await SendRequest<string[]>(options);
        }

        public async Task<Models.ApiResponse<string[]>> CancelOrders(string[] oids)
        {
            string endpoint = $"/{apiVersion}/orders/{string.Join("-", oids)}/";
            RequestOptions options = new RequestOptions("DELETE", endpoint);
            return await SendRequest<string[]>(options);
        }

        public async Task<Models.ApiResponse<string[]>> CancelAllOrders()
        {
            string endpoint = $"/{apiVersion}/orders/all/";
            RequestOptions options = new RequestOptions("DELETE", endpoint);
            return await SendRequest<string[]>(options);
        }

        public async Task<Models.ApiResponse<Models.Orders.OrderCreated>> PlaceOrder(Models.Orders.NewOrder order)
        {
            string endpoint = $"/{apiVersion}/orders/";
            RequestOptions options = new RequestOptions("POST", endpoint, order);
            return await SendRequest<Models.Orders.OrderCreated>(options);
        }
    }
}