using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

using BitsoClient.Models;
using BitsoClient.RestApi.Consumers;

namespace BitsoClient.RestApi
{
    public interface IHttpRequester
    {
        Task<string> SendAsync(IRequestOptions requestOptions);
        int AddConsumer(IRequestConsumer consumer);
        Task<bool> FulfillRequestsAsync();
    }
    public class HttpRequester : IHttpRequester
    {
        private readonly HttpClient _client;
        private Dictionary<IRequestOptions, IList<IRequestConsumer>> requestBag;

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
            if (requestBag == null)
            {
                requestBag = new Dictionary<IRequestOptions, IList<IRequestConsumer>>();
            }
            var requestOptions = consumer.GetRequestOptions();
            if (!requestBag.ContainsKey(requestOptions))
            {
                requestBag.Add(requestOptions, new List<IRequestConsumer>());
            }
            requestBag[requestOptions].Add(consumer);
            return requestBag.Count;
        }

        public async Task<bool> FulfillRequestsAsync()
        {
            var requestTasks = requestBag.Select(b => FeedRequestConsumersAsync(b.Key, b.Value));
            var responses = await Task.WhenAll(requestTasks);
            return responses.All(r => r);
        }

        private async Task<bool> FeedRequestConsumersAsync(IRequestOptions options, IEnumerable<IRequestConsumer> consumers)
        {
            string response = await SendAsync(options);
            foreach (var consumer in consumers)
            {
                consumer.Consume(response);
            }
            return true;
        }
    }
}