using System.Text;

namespace BitsoClient.RestApi
{
    public class RequestOptions
    {
        public string Method { get; }
        public string Path { get; }
        public string Payload { get; set; }

        public RequestOptions(string method, string path)
        {
            Method = method;
            Path = path;
        }

        public byte[] ToSignatureFormat(long nonce)
        {
            string signature =  $"{nonce}{Method}{Path}{Payload}";
            return Encoding.UTF8.GetBytes(signature);
        }
    }
}