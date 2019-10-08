using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;

using BitsoClient.Models;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient
    {
        private readonly IHttpRequester _requester;
        private readonly string baseUrl;
        private readonly string key;
        private readonly byte[] secret;

        public PrivateApiClient(IHttpRequester requester, ClientConfiguration config)
        {
            _requester = requester;
            baseUrl = $"{config.BaseUrl}/{config.ApiVersion}";
            key = config.ApiKey;
            secret = Encoding.UTF8.GetBytes(config.ApiSecret);
        }

        public async Task<ApiResponse<T>> SendRequest<T>(RequestOptions options)
        {
            using(HMACSHA256 hmac = new HMACSHA256(secret))
            {
                var request = options.ComposeRequestMessage(hmac, baseUrl, key);
                var response = await _requester.SendAsycn(request);
                string content = await response.Content.ReadAsStringAsync();

                string payloadStr = await response.Content.ReadAsStringAsync();
                T payload = JsonConvert.DeserializeObject<T>(payloadStr);
                
                ApiResponse<T> apiResponse = new ApiResponse<T>()
                {
                    Success = response.IsSuccessStatusCode,
                    Status = (int)response.StatusCode,
                    Payload = payload,
                };
                return apiResponse;
            }
        }
    }
}