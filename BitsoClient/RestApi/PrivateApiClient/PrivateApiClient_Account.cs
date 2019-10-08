using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<BitsoClient.Models.AccountStatus.Response> GetAccountStatus()
        {
            string endpoint = "account_status";
            RequestOptions options = new RequestOptions("GET", $"{baseUrl}/{endpoint}");
            BitsoClient.Models.AccountStatus.Response response = (BitsoClient.Models.AccountStatus.Response)(await SendRequest<BitsoClient.Models.AccountStatus.Payload>(options));
            return response;
        }

        public async Task<BitsoClient.Models.AccountBalance.Response> GetAccountBalance()
        {
            string endpoint = "balance";
            RequestOptions options = new RequestOptions("GET", $"{baseUrl}/{endpoint}");
            BitsoClient.Models.AccountBalance.Response response = (BitsoClient.Models.AccountBalance.Response)(await SendRequest<BitsoClient.Models.AccountBalance.Payload>(options));
            return response;
        }
    }
}