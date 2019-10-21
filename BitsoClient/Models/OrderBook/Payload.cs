using System;
using Newtonsoft.Json;

namespace BitsoClient.Models.OrderBook
{
    public class Payload
    {
        [JsonPropertyAttribute("asks")]
        public Order[] Asks { get; set; }
        [JsonPropertyAttribute("bids")]
        public Order[] Bids { get; set; }

        [JsonPropertyAttribute("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonPropertyAttribute("sequence")]
        public string Sequence { get; set; }

        public override string ToString()
        {
            return $"Asks: {string.Join<Order>(";", Asks)}\nBids: {string.Join<Order>(";", Asks)}";
        }
    }
}