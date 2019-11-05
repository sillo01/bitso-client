using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;

using BitsoClient.Models;

namespace BitsoClient.RestApi
{
    public partial class PrivateApiClient : IPrivateApiClient
    {
        private readonly IHttpRequester _requester;
        private readonly string baseUrl;
        private readonly string apiVersion;
        private readonly string key;
        private readonly byte[] secret;
        private readonly ClientConfiguration configuration;

        public PrivateApiClient(IHttpRequester requester, ClientConfiguration config)
        {
            _requester = requester;
            baseUrl = config.BaseUrl;
            apiVersion = config.ApiVersion;
            key = config.ApiKey;
            secret = Encoding.UTF8.GetBytes(config.ApiSecret);
            this.configuration = config;
        }

        public async Task<ApiResponse<T>> SendRequest<T>(HttpMethod method, string path, string payload = null)
        {
            RequestOptionsEncrypted requestOptions = new RequestOptionsEncrypted(
                configuration,
                method,
                path,
                payload);
            string content = await _requester.SendAsycn(requestOptions);

            return JsonConvert.DeserializeObject<ApiResponse<T>>(content);
        }
    }
}