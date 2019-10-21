using Newtonsoft.Json;

namespace BitsoClient.Models.AccountBalance
{
    public class Payload
    {
        [JsonPropertyAttribute("balances")]
        public Balance[] Balances { get; set; }
    }
}