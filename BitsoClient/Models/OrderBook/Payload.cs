using System;

namespace BitsoClient.Models.OrderBook
{
    public class Payload
    {
        public Order[] Asks { get; set; }
        public Order[] Bids { get; set; }

        public DateTime updated_at { get; set; }
        public string sequence { get; set; }

        public override string ToString()
        {
            return $"Asks: {string.Join<Order>(";", Asks)}\nBids: {string.Join<Order>(";", Asks)}";
        }
    }
}