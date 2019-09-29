using System;
using System.Linq;

namespace BitsoClient.Models.OrderBook
{
    public class Payload
    {
        public Order[] Asks { get; set; }
        public Order[] Bids { get; set; }

        public DateTime updated_at { get; set; }
        public string sequence { get; set; }
    }
}