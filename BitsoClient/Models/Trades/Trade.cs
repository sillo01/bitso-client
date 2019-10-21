using System;
using Newtonsoft.Json;

namespace BitsoClient.Models.Trades
{
    public class Trade
    {
        [JsonPropertyAttribute("book")]
        public string Book { get; set; }
        [JsonPropertyAttribute("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyAttribute("amount")]
        public string Amount { get; set; }
        [JsonPropertyAttribute("maker_side")]
        public string MakerSide { get; set; }
        [JsonPropertyAttribute("price")]
        public string Price { get; set; }
        [JsonPropertyAttribute("tid")]
        public int Tid { get; set; }
    }
}