using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BitsoClient.RestApi
{
    public class PrivateApiClient
    {
        private readonly IHttpRequester _requester;
        private readonly string baseUrl;
        private readonly string key;
        private readonly byte[] secret;

        public PrivateApiClient(IHttpRequester requester, ClientConfiguration config)
        {
            _requester = requester;
            baseUrl = config.BaseUrl;
            key = config.ApiKey;
            secret = Encoding.UTF8.GetBytes(config.ApiSecret);
        }

        public async Task<ApiResponse> SendRequest(RequestOptions options)
        {
            using(HMACSHA256 hmac = new HMACSHA256(secret))
            {
                var request = options.ComposeRequestMessage(hmac, baseUrl, key);
                var response = await _requester.SendAsycn(request);
                ApiResponse apiResponse = new ApiResponse()
                {
                    Success = response.IsSuccessStatusCode,
                    StatusCode = (int)response.StatusCode,
                    Content = await response.Content.ReadAsStringAsync(),
                };
                return apiResponse;
            }
        }
    }
}