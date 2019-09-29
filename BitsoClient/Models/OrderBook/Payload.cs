using System;
using System.Linq;

namespace bitso_client.Models.OrderBook
{
    public class Payload
    {
        public Order[] Asks { get; set; }
        public Order[] Bids { get; set; }

        public DateTime updated_at { get; set; }
        public string sequence { get; set; }
    }
}