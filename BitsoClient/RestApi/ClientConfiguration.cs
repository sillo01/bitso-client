namespace BitsoClient.RestApi
{
    public class ClientConfiguration
    {
        public string BaseUrl { get; }
        public string ApiKey { get; }
        public string ApiSecret { get; }
        public string ApiVersion { get; set; }

        public ClientConfiguration(
            string url,
            string version,
            string key,
            string secret
        )
        {
            BaseUrl = url;
            ApiVersion = version;
            ApiKey = key;
            ApiSecret = secret;
        }
    }
}