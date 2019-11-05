using System;

namespace BitsoClient.RestApi
{
    public class PublicApiAdapter
    {
        private readonly ClientConfiguration configuration;
        public PublicApiAdapter(ClientConfiguration configuration)
        {
            this.configuration = configuration;
        }

        RequestOptions GetTickerOptions(string book)
        {
            throw new NotImplementedException();
        }

        RequestOptions GetOrderBookOptions(string book, bool? aggregate = null)
        {
            throw new NotImplementedException();
        }

        RequestOptions GetTradesOptions(string book, int? marker = null, string sort = null, int? limit = null)
        {
            throw new NotImplementedException();
        }
    }
}