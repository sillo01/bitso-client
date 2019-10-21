using System;
using Newtonsoft.Json;

namespace BitsoClient.Models.Orders
{
    public class Order
    {
        [JsonPropertyAttribute("book")]
        public string Book { get; set; }
        [JsonPropertyAttribute("original_amount")]
        public string OriginalAmount { get; set; }
        [JsonPropertyAttribute("unfilled_amount")]
        public string UnfilledAmount { get; set; }
        [JsonPropertyAttribute("original_value")]
        public string OriginalValue { get; set; }
        [JsonPropertyAttribute("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyAttribute("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonPropertyAttribute("price")]
        public string Price { get; set; }
        [JsonPropertyAttribute("oid")]
        public string Oid { get; set; }
        [JsonPropertyAttribute("client_id")]
        public string ClientId { get; set; }
        [JsonPropertyAttribute("side")]
        public string Side { get; set; }
        [JsonPropertyAttribute("status")]
        public string Status { get; set; }
        [JsonPropertyAttribute("type")]
        public string Type { get; set; }
    }
}