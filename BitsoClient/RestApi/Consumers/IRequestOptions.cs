using System.Net.Http;

namespace BitsoClient.RestApi.Consumers
{
    public interface IRequestOptions
    {
        HttpMethod Method { get; }
        string Url { get; }
        string Payload { get; }
        HttpRequestMessage ComposeRequestMessage();
    }
}