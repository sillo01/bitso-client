using Newtonsoft.Json;

namespace BitsoClient.Models.Orders
{
    public class OrderCreated
    {
        [JsonPropertyAttribute("oid")]
        public string Oid { get; set; }
    }
}