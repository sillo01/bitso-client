using System.Threading.Tasks;

using BitsoClient.RestApi.Parameters;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<Models.Orders.Reponse> GetOpenOrders(string book)
        {
            string endpoint = "open_orders";
            string queryString = Params.ToQueryString(new Book(book));
            RequestOptions options = new RequestOptions("GET", $"/{endpoint}{queryString}");
            var respone = await SendRequest<Models.Orders.Order[]>(options);
            return new Models.Orders.Reponse()
            {
                Success = respone.Success,
                Payload = respone.Payload,
                Error = respone.Error
            };
        }
    }
}