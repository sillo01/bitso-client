using Newtonsoft.Json;

namespace BitsoClient.Models.Orders
{
    public class NewOrder
    {
        public NewOrder(string book, string side, string type)
        {
            this.Book = book;
            this.Side = side;
            this.Type = type;
        }
        [JsonPropertyAttribute("book")]
        public string Book { get; }
        [JsonPropertyAttribute("side")]
        public string Side { get; }
        [JsonPropertyAttribute("type")]
        public string Type { get; }
        [JsonPropertyAttribute("major")]
        public string Major { get; set; }
        [JsonPropertyAttribute("minor")]
        public string Minor { get; set; }
        [JsonPropertyAttribute("price")]
        public string Price { get; set; }
        [JsonPropertyAttribute("stop")]
        public string Stop { get; set; }
        [JsonPropertyAttribute("time_in_force")]
        public string TimeInForce { get; set; }
        [JsonPropertyAttribute("client_id")]
        public string ClientId { get; set; }
    }
}