using System.Net.Http;

namespace BitsoClient.RestApi.Consumers
{
    public abstract class AbastractRequestOptions : IRequestOptions
    {
        public HttpMethod Method { get; protected set; }
        public virtual string Url { get; protected set; }
        public virtual string Payload { get; protected set; }
        public abstract HttpRequestMessage ComposeRequestMessage();
    }
}