using System;
using System.Text;
using System.Net.Http;

namespace BitsoClient.RestApi
{
    public class RequesOptionsEncrypted : IRequestOptions
    {
        private readonly ClientConfiguration configuration;
        public RequesOptionsEncrypted(ClientConfiguration configuration, HttpMethod method, string path)
        {
            this.configuration = configuration;
            Method = method;
            Path = path;
        }
        public RequesOptionsEncrypted(ClientConfiguration configuration, HttpMethod method, string path, string payload) : this(configuration, method, path)
        {
            Payload = payload;
        }

        public HttpMethod Method { get; }
        public string Path { get; }
        public string Payload { get; }
        public string Url
        {
            get { return configuration.BaseUrl + Path; }
        }

        public HttpRequestMessage ComposeRequestMessage()
        {
            long nonce = GetTimeStamp();
            string signature = GetSignature(nonce);
            string authHeader = $"Bitso {configuration.ApiKey}:{nonce}:{signature}";

            HttpRequestMessage request = new HttpRequestMessage(Method, configuration.BaseUrl + Path);

            request.Headers.Add("Authorization", authHeader);

            if (!string.IsNullOrEmpty(Payload))
            {
                request.Content = new StringContent(
                    Payload,
                    Encoding.UTF8,
                    "application/json");
            }

            return request;
        }

        string GetSignature(long nonce)
        {
            string message = nonce+Method.Method.ToUpper()+Path+Payload;
            byte[] encodedMessage = Encoding.UTF8.GetBytes(message);

            using (var hmac = configuration.GenerateHmac())
            {
                byte[] signature = hmac.ComputeHash(encodedMessage);
                StringBuilder sb = new StringBuilder(signature.Length * 2);

                foreach (byte b in signature)
                    sb.AppendFormat("{0:x2}", b);

                return sb.ToString();
            }
        }

        private long GetTimeStamp()
        {
            var now = DateTime.Now;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double milis = (now.ToUniversalTime() - epoch).TotalMilliseconds;
            return Convert.ToInt64(milis);
        }
    }
}