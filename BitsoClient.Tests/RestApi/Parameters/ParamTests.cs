using Xunit;

using BitsoClient.RestApi.Parameters;

namespace BitsoClient.Tests.RestApi.Parameters
{
    public class ParamsTests
    {
        [Fact]
        public void SerializeOneParam()
        {
            string queryString = Params.ToQueryString(
                new Book("book_name")
            );

            Assert.Equal("?book=book_name", queryString);
        }

        [Fact]
        public void SerializeMultipleParams()
        {
            string queryString = Params.ToQueryString(
                new Book("book_name"),
                new Limit(10),
                new Sort("asc")
            );

            Assert.Equal("?book=book_name&limit=10&sort=asc", queryString);
        }

        [Fact]
        public void SerializeMultipleParamsWithNulls()
        {
            string queryString = Params.ToQueryString(
                new Book("book_name"),
                new Limit(null),
                new Sort("asc")
            );

            Assert.Equal("?book=book_name&sort=asc", queryString);
        }
    }
}