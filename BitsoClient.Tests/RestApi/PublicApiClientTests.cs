using Xunit;
using Moq;
using System.Threading.Tasks;

using BitsoClient.RestApi;

namespace BitsoClient.Tests.RestApi
{
    public class PublicApiClientTests
    {
        private readonly Mock<IHttpRequester> _requester;
        private readonly PublicApiClient _client;
        private readonly string _baseUrl = "/the/best/url/ever";

        public PublicApiClientTests()
        {
            _requester = new Mock<IHttpRequester>();

            _requester.Setup(r => r.SendAsync(It.IsAny<RequestOptions>())).ReturnsAsync(_tickerResponse);

            var config = new ClientConfiguration(_baseUrl, null, null, null);
            _client = new PublicApiClient(_requester.Object, config);
        }

        [Fact]
        public async Task ParsesTicker()
        {
            var response = await _client.GetTickerAsync("book_name");
            Assert.Equal(22.31349615d, response.Volume);
            Assert.Equal(5750.00d, response.High);
            Assert.Equal(5633.98d, response.Last);
            Assert.Equal(5450.00d, response.Low);
            Assert.Equal(5393.45d, response.VWAP);
            Assert.Equal(5632.24d, response.Ask);
            Assert.Equal(5520.01d, response.Bid);
        }

        private readonly string _tickerResponse = @"{
            ""success"": true,
            ""payload"": {
                ""book"": ""btc_mxn"",
                ""volume"": ""22.31349615"",
                ""high"": ""5750.00"",
                ""last"": ""5633.98"",
                ""low"": ""5450.00"",
                ""vwap"": ""5393.45"",
                ""ask"": ""5632.24"",
                ""bid"": ""5520.01"",
                ""created_at"": ""2016-04-08T17:52:31.000+00:00""
            }
        }";
    }
}