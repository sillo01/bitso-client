using System;
using System.Text;
using System.Security.Cryptography;

using BitsoClient.RestApi;

namespace BitsoClient.Examples.Demos
{
    public class RequestOptionsDemo
    {
        private readonly byte[] secret;
        public RequestOptionsDemo()
        {
            secret = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("ApiSecret"));
        }

        public void GetSignature()
        {
            long nonce = 1569984455012;
            string httpMethod = "GET";
            string path = "/v3/balance/";

            RequestOptions options = new RequestOptions(httpMethod, path);

            using (HMACSHA256 hmac = new HMACSHA256(secret))
            {
                var signature = options.GetSignature(nonce, hmac);
            }
        }
    }
}