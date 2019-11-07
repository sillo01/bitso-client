namespace BitsoClient.RestApi.Consumers
{
    public interface IRequestConsumer
    {
        void Consume(string response);
        IRequestOptions GetRequestOptions();
    }
}