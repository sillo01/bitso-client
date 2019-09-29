using System;
using Xunit;
using BitsoClient.RestApi.Parameters;

namespace BitsoClient.Tests.RestApi.Parameters
{
    public class BookTests
    {
        [Fact]
        public void ConstructsBookParameter()
        {
            Book book = new Book("book_name");
            Assert.Equal("book_name", book.Value);
            Assert.Equal("book", book.Name);
            Assert.True(book.HasValue);
            Assert.True(book.Required);
        }

        [Fact]
        public void ThrowsIfEmptyBookName()
        {
            Assert.Throws<ArgumentNullException>(() => {
                new Book("");
            });
        }
    }
}