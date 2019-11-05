using System.Net.Http;
using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public interface IHttpRequester
    {
        Task<string> SendAsycn(IRequestOptions requestOptions);
    }
    public class HttpRequester : IHttpRequester
    {
        private readonly HttpClient _client;

        public HttpRequester(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> SendAsycn(IRequestOptions requestOptions)
        {
            HttpRequestMessage requestMessage = requestOptions.ComposeRequestMessage();
            HttpResponseMessage response = await _client.SendAsync(requestMessage);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}