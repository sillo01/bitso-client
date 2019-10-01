using Xunit;
using System.Text;
using System.Security.Cryptography;

using BitsoClient.RestApi;

namespace BitsoClient.Tests.RestApi
{
    public class RequestOptionsTests
    {
        [Fact]
        public void GetsRequestSignature()
        {
            long fakeNonce = 1234L;
            string fakeSecret = "secret-password";
            byte[] encodedSecret = Encoding.UTF8.GetBytes(fakeSecret);

            RequestOptions options = new RequestOptions("get", "/url/path");
            using (HMACSHA256 hmac = new HMACSHA256(encodedSecret))
            {
                string expectedSignature = "283c1a46963f728ae9e3dd3beb1dfd3d0135fb6fda62492fd0005d9ac48bde3d";
                string hexSignature = options.GetSignatureHexString(fakeNonce, hmac);
                Assert.Equal(expectedSignature, hexSignature);
            }
        }
    }
}