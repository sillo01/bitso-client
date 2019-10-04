using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        public async Task<ApiResponse> GetAccountStatus()
        {
            string endpoint = "account_status";
            RequestOptions options = new RequestOptions("GET", $"{baseUrl}/{endpoint}");
            ApiResponse response = await SendRequest(options);
            return response;
        }
    }
}