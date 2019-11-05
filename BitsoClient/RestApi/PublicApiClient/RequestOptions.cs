using System.Net.Http;

namespace BitsoClient.RestApi
{
    public class REquestOptions : IRequestOptions
    {
        public REquestOptions(string baseUrl, string path)
        {
            Method = HttpMethod.Get;
            Url = baseUrl + path;
        }
        public HttpMethod Method { get; }

        public string Url { get; }

        public string Payload => "";

        public HttpRequestMessage ComposeRequestMessage()
        {
            return new HttpRequestMessage(Method, Url);
        }
    }
}