using System;
using Newtonsoft.Json;

namespace BitsoClient.Models.Ticker
{
    public class Payload
    {
        [JsonPropertyAttribute("book")]
        public string Book { get; set; }
        [JsonPropertyAttribute("volume")]
        public string Volume { get; set; }
        [JsonPropertyAttribute("high")]
        public string High { get; set; }
        [JsonPropertyAttribute("last")]
        public string Last { get; set; }
        [JsonPropertyAttribute("low")]
        public string Low { get; set; }
        [JsonPropertyAttribute("vwap")]
        public string Vwap { get; set; }
        [JsonPropertyAttribute("ask")]
        public string Ask { get; set; }
        [JsonPropertyAttribute("bid")]
        public string Bid { get; set; }
        [JsonPropertyAttribute("created_at")]
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"Book: {Book}\nHigh: {High}\nLow: {Low}";
        }
    }
}