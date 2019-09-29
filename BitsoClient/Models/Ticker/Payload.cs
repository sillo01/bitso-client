using System;

namespace BitsoClient.Models.Ticker
{
    public class Payload
    {
        public string book { get; set; }
        public string volume { get; set; }
        public string high { get; set; }
        public string last { get; set; }
        public string low { get; set; }
        public string vwap { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public DateTime created_at { get; set; }

        public override string ToString()
        {
            return $"Book: {book}\nHigh: {high}\nLow: {low}";
        }
    }
}