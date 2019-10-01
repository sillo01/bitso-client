using System;
using System.Text;
using System.Security.Cryptography;
using System.Net.Http;

namespace BitsoClient.RestApi
{
    public class PrivateApiClient
    {
        private readonly IHttpRequester _requester;
        private readonly string baseUrl;
        private readonly string key;
        private readonly byte[] secret;

        public PrivateApiClient(IHttpRequester requester, ClientConfiguration config)
        {
            baseUrl = config.BaseUrl;
            key = config.ApiKey;
            secret = Encoding.UTF8.GetBytes(config.ApiSecret);
        }

        void ComposeRequest(RequestOptions options)
        {
            long nonce = DateTime.Now.ToFileTimeUtc();
            string signature = null;

            using(HMACSHA256 hmac = new HMACSHA256(secret))
            {
                byte[] binarySignature = hmac.ComputeHash(options.ToSignatureFormat(nonce));

                StringBuilder sb = new StringBuilder(binarySignature.Length * 2);
                foreach (byte b in binarySignature)
                    sb.AppendFormat("{0:x2}", b);

                signature = sb.ToString();
            }

            string authHeader = $"Bitso {key}:{nonce}:{signature}";
            HttpRequestMessage request = new HttpRequestMessage();
        }
    }
}