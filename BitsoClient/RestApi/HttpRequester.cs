using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using BitsoClient.RestApi.Consumers;

namespace BitsoClient.RestApi
{
    public interface IHttpRequester
    {
        Task<string> SendAsync(IRequestOptions requestOptions);
    }
    public class HttpRequester : IHttpRequester
    {
        private readonly HttpClient _client;
        private Dictionary<IRequestOptions, IList<IRequestConsumer>> requestQueue;

        public HttpRequester(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> SendAsync(IRequestOptions requestOptions)
        {
            HttpRequestMessage requestMessage = requestOptions.ComposeRequestMessage();
            HttpResponseMessage response = await _client.SendAsync(requestMessage);
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public int AddConsumer(IRequestConsumer consumer)
        {
            if (requestQueue == null)
            {
                requestQueue = new Dictionary<IRequestOptions, IList<IRequestConsumer>>();
            }
            var requestOptions = consumer.GetRequestOptions();
            if (!requestQueue.ContainsKey(requestOptions))
            {
                requestQueue.Add(requestOptions, new List<IRequestConsumer>());
            }
            requestQueue[requestOptions].Add(consumer);
            return requestQueue.Count;
        }
    }
}