using Newtonsoft.Json;

namespace BitsoClient.Models.OrderBook
{
    public class Order
    {
        [JsonPropertyAttribute("book")]
        public string Book { get; set; }
        [JsonPropertyAttribute("book")]
        public string Price { get; set; }
        [JsonPropertyAttribute("book")]
        public string Amount { get; set; }


        public override string ToString()
        {
            return $"Price ${this.Price}, Amount {this.Amount}, Book {this.Book}";
        }
    }
}