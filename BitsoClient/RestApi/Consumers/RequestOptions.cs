using System.Net.Http;

namespace BitsoClient.RestApi.Consumers
{
    public class RequestOptions : AbastractRequestOptions
    {
        public RequestOptions(string baseUrl, string path)
        {
            Method = HttpMethod.Get;
            Url = baseUrl + path;
        }

        public override string Payload => "";

        public override HttpRequestMessage ComposeRequestMessage()
        {
            return new HttpRequestMessage(Method, Url);
        }
    }
}