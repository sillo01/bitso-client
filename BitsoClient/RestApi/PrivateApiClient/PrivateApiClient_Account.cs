using System.Threading.Tasks;
using System.Net.Http;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<Models.AccountStatus.Response> GetAccountStatusAsync()
        {
            string endpoint = $"/{apiVersion}/account_status/";
            var response = await SendRequest<Models.AccountStatus.Payload>(HttpMethod.Get, endpoint);
            return new Models.AccountStatus.Response()
            {
                Success = response.Success,
                Payload = response.Payload,
                Error = response.Error
            };
        }

        public async Task<Models.AccountBalance.Response> GetAccountBalanceAsync()
        {
            string endpoint = $"/{apiVersion}/balance/";
            var response = await SendRequest<Models.AccountBalance.Payload>(HttpMethod.Get, endpoint);
            return new Models.AccountBalance.Response()
            {
                Success = response.Success,
                Payload = response.Payload,
                Error = response.Error
            };
        }
    }
}