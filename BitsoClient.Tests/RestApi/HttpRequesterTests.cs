using Moq;
using Moq.Protected;
using Xunit;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

using BitsoClient.RestApi;
using BitsoClient.RestApi.Consumers;

namespace BitsoClient.Tests.RestApi
{
    public class HttpRequesterTests
    {
        private readonly Mock<HttpMessageHandler> handlerMock = new Mock<HttpMessageHandler>();
        [Fact]
        public async void FulFillSingleRequest()
        {
            
            var response = new BitsoClient.Models.Trades.Response()
            {
                Success = true,
                Payload = new Models.Trades.Trade[]
                {
                    new Models.Trades.Trade()
                    {
                        Book = "btc_mxn",
                        CreatedAt = DateTime.Now,
                        Amount = "0.1234",
                        Price = "1234.56",
                        MakerSide = "buy",
                        Tid = 16976
                    }
                }
            };
            handlerMock.Reset();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(response))
                });

            HttpRequester requester = new HttpRequester(new HttpClient(handlerMock.Object));
            var consumer = new RequestConsumer();
            requester.AddConsumer(consumer);
            await requester.FulfillRequestsAsync();

            Assert.Equal("btc_mxn", consumer.ResponseObject.Payload[0].Book);
            Assert.Equal("0.1234", consumer.ResponseObject.Payload[0].Amount);
            Assert.Equal("1234.56", consumer.ResponseObject.Payload[0].Price);
            Assert.Equal("buy", consumer.ResponseObject.Payload[0].MakerSide);
            Assert.Equal(16976, consumer.ResponseObject.Payload[0].Tid);
        }

        private class RequestConsumer : IRequestConsumer
        {
            private Type responseType =  typeof(BitsoClient.Models.Trades.Response);
            public BitsoClient.Models.Trades.Response ResponseObject { get; set; }

            public IRequestOptions GetRequestOptions()
            {
                return new RequestOptions("http://host/url", "/trades");
            }
            public void Consume(string response)
            {
                ResponseObject = (BitsoClient.Models.Trades.Response)JsonConvert.DeserializeObject(response, responseType);
            }
        }
    }
}