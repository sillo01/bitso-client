using System;

namespace BitsoClient.Models.Trades
{
    public class Trade
    {
        public string book { get; set; }
        public DateTime created_at { get; set; }
        public string amount { get; set; }
        public string maker_side { get; set; }
        public string price { get; set; }
        public int tid { get; set; }
    }
}