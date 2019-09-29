using System.Net.Http;
using System.Threading.Tasks;

namespace BitsoClient.RestApi
{
    public interface IHttpRequester
    {
        Task<string> GetAsync(string url);
    }
    public class HttpRequester : IHttpRequester
    {
        private readonly HttpClient _client;

        public HttpRequester(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> GetAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            string jsonContent = await response.Content.ReadAsStringAsync();
            return jsonContent;
        }
    }
}