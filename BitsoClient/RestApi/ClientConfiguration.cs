namespace BitsoClient.RestApi
{
    public class ClientConfiguration
    {
        public string BaseUrl { get; }
        public string ApiKey { get; }
        public string ApiSecret { get; }

        public ClientConfiguration(
            string url,
            string key,
            string secret
        )
        {
            BaseUrl = url;
            ApiKey = key;
            ApiSecret = secret;
        }
    }
}