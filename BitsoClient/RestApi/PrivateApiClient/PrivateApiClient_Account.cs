using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<BitsoClient.Models.AccountStatus.Response> GetAccountStatus()
        {
            string endpoint = "account_status";
            RequestOptions options = new RequestOptions("GET", $"{baseUrl}/{endpoint}");
            var response = await SendRequest<BitsoClient.Models.AccountStatus.Payload>(options);
            return new Models.AccountStatus.Response()
            {
                Success = response.Success,
                Status = response.Status,
                Payload = response.Payload
            };
        }

        public async Task<BitsoClient.Models.AccountBalance.Response> GetAccountBalance()
        {
            string endpoint = "balance";
            RequestOptions options = new RequestOptions("GET", $"{baseUrl}/{endpoint}");
            var response = await SendRequest<BitsoClient.Models.AccountBalance.Payload>(options);
            return new Models.AccountBalance.Response()
            {
                Success = response.Success,
                Status = response.Status,
                Payload = response.Payload
            };
        }
    }
}