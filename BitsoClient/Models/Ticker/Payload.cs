using System;
using Newtonsoft.Json;

namespace BitsoClient.Models.Ticker
{
    public class Payload
    {
        [JsonPropertyAttribute("book")]
        public string Book { get; set; }
        [JsonPropertyAttribute("volume")]
        internal string VolumeStr { get; set; }
        [JsonPropertyAttribute("high")]
        internal string HighStr { get; set; }
        [JsonPropertyAttribute("last")]
        internal string LastStr { get; set; }
        [JsonPropertyAttribute("low")]
        internal string LowStr { get; set; }
        [JsonPropertyAttribute("vwap")]
        internal string VwapStr { get; set; }
        [JsonPropertyAttribute("ask")]
        internal string AskStr { get; set; }
        [JsonPropertyAttribute("bid")]
        internal string BidStr { get; set; }
        [JsonPropertyAttribute("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public double Volume => Convert.ToDouble(VolumeStr);
        [JsonIgnore]
        public double High => Convert.ToDouble(HighStr);
        [JsonIgnore]
        public double Last => Convert.ToDouble(LastStr);
        [JsonIgnore]
        public double Low => Convert.ToDouble(LowStr);
        [JsonIgnore]
        public double VWAP => Convert.ToDouble(VwapStr);
        [JsonIgnore]
        public double Ask => Convert.ToDouble(AskStr);
        [JsonIgnore]
        public double Bid => Convert.ToDouble(BidStr);

        public override string ToString()
        {
            return $"Book: {Book}\nHigh: {HighStr}\nLow: {LowStr}";
        }
    }
}