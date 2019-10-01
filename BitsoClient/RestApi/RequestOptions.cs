using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace BitsoClient.RestApi
{
    public class RequestOptions
    {
        public string Method { get; }
        
        public string Path { get; }
        public string Payload { get; set; }

        private string[] AllowedMethods = { "get", "post" };

        public RequestOptions(string method, string path)
        {
            if (!AllowedMethods.Contains(method.ToLower()))
            {
                throw new ArgumentException("Only 'get' and 'post' methods are allowed");
            }
            Method = method.ToLower();
            Path = path;
        }
        public RequestOptions(string method, string path, object payload)
        {
            if (!AllowedMethods.Contains(method.ToLower()))
            {
                throw new ArgumentException("Only 'get' and 'post' methods are allowed");
            }
            Method = method.ToLower();
            Path = path;
            Payload = JsonConvert.SerializeObject(payload);
        }

        public HttpRequestMessage GetRequestMessage(HMACSHA256 hmac, string baseUrl, string key)
        {
            long nonce = DateTime.Now.ToFileTimeUtc();
            string signature = GetSignatureHexString(nonce, hmac);
            string authHeader = $"{key}:{nonce}:{signature}";

            HttpRequestMessage request = new HttpRequestMessage(
                GetHttpMethod(),
                baseUrl + Path);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bitso", authHeader);
            if (!string.IsNullOrEmpty(Payload))
            {
                request.Content = new StringContent(
                    Payload,
                    Encoding.UTF8,
                    "application/json");
            }

            return request;
        }

        public string GetSignatureHexString(long nonce, HMACSHA256 hmac)
        {
            string formatedSignature =  $"{nonce}{Method}{Path}{Payload}";
            byte[] binSignature = Encoding.UTF8.GetBytes(formatedSignature);
            byte[] encodedSignature = hmac.ComputeHash(binSignature);

            StringBuilder sb = new StringBuilder(binSignature.Length * 2);
                foreach (byte b in binSignature)
                    sb.AppendFormat("{0:x2}", b);

            return sb.ToString();
        }

        private HttpMethod GetHttpMethod()
        {
            if (Method.Equals("get"))
                return HttpMethod.Get;
            else
                return HttpMethod.Post;
        }
    }
}