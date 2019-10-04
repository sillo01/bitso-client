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
            long fakeNonce = 12341234;
            string fakeSecret = "secret-password";
            byte[] encodedSecret = Encoding.UTF8.GetBytes(fakeSecret);

            RequestOptions options = new RequestOptions("get", "/url/path");
            using (HMACSHA256 hmac = new HMACSHA256(encodedSecret))
            {
                string expectedSignature = "ecfb6723dc3223cd04e29833e11033cf556788719cf1d729a9cde8feb0b5b34d";
                string hexSignature = options.GetSignature(fakeNonce, hmac);
                Assert.Equal(expectedSignature, hexSignature);
            }
        }
    }
}