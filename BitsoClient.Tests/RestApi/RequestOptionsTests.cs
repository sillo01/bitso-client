using Xunit;
using System.Net.Http;

using BitsoClient.RestApi;

namespace BitsoClient.Tests.RestApi
{
    public class RequestOptionsTests
    {
        private readonly ClientConfiguration config;
        public RequestOptionsTests()
        {
            string baseUrl = "/base/url";
            string apiVersion = "v3";
            string apiKey = "api-key";
            string fakeSecret = "secret-password";

            config = new ClientConfiguration(baseUrl, apiVersion, apiKey, fakeSecret);
        }

        [Fact]
        public void ComposeGetRequest()
        {
            RequestOptionsEncrypted options = new RequestOptionsEncrypted(config, HttpMethod.Get, "/my/path");
            var reqMessage = options.ComposeRequestMessage();
            
            Assert.Equal(HttpMethod.Get, reqMessage.Method);
            Assert.Equal("/base/url/my/path", reqMessage.RequestUri.ToString());
            var authHeader = reqMessage.Headers.Authorization;
        }
    }
}