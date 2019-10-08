using System;

namespace BitsoClient.Models.Orders
{
    public class Order
    {
        public string book { get; set; }
        public string original_amount { get; set; }
        public string unfiled_amount { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string price { get; set; }
        public string oid { get; set; }
        public string client_id { get; set; }
        public string side { get; set; }
        public string status { get; set; }
        public string type { get; set; }
    }
}