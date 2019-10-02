using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace BitsoClient.RestApi
{
    public class RequestOptions
    {
        public string Method { get; }
        
        public string Path { get; }
        public string Payload { get; set; }

        private string[] AllowedMethods = { "GET", "POST" };

        public RequestOptions(string method, string path)
        {
            if (!AllowedMethods.Contains(method.ToUpper()))
            {
                throw new ArgumentException("Only 'get' and 'post' methods are allowed");
            }
            Method = method.ToUpper();
            Path = path;
            Payload = "";
        }
        public RequestOptions(string method, string path, object payload)
        {
            if (!AllowedMethods.Contains(method.ToUpper()))
            {
                throw new ArgumentException("Only 'get' and 'post' methods are allowed");
            }
            Method = method.ToUpper();
            Path = path;
            Payload = JsonConvert.SerializeObject(payload);
        }

        public HttpRequestMessage ComposeRequestMessage(HMACSHA256 hmac, string baseUrl, string key)
        {
            long nonce = GetTimeStamp();
            string signature = GetSignature(nonce, hmac);
            string authHeader = $"Bitso {key}:{nonce}:{signature}";

            HttpRequestMessage request = new HttpRequestMessage(
                GetHttpMethod(),
                baseUrl + Path);

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

        public string GetSignature(long nonce, HMACSHA256 hmac)
        {
            string message =  nonce+Method+Path+Payload;
            byte[] encodedMessage = Encoding.UTF8.GetBytes(message);
            byte[] signature = hmac.ComputeHash(encodedMessage);

            StringBuilder sb = new StringBuilder(signature.Length * 2);

            foreach (byte b in signature)
                sb.AppendFormat("{0:x2}", b);

            return sb.ToString();
        }

        private long GetTimeStamp()
        {
            var now = DateTime.Now;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double milis = (now.ToUniversalTime() - epoch).TotalMilliseconds;
            return Convert.ToInt64(milis);
        }
        private HttpMethod GetHttpMethod()
        {
            if (Method.Equals("GET"))
                return HttpMethod.Get;
            else
                return HttpMethod.Post;
        }
    }
}