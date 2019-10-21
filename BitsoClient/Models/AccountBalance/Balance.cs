using Newtonsoft.Json;

namespace BitsoClient.Models.AccountBalance
{
    public class Balance
    {
        [JsonPropertyAttribute("currency")]
        public string Currency { get; set; }
        [JsonPropertyAttribute("total")]
        public string Total { get; set; }
        [JsonPropertyAttribute("locked")]
        public string Locked { get; set; }
        [JsonPropertyAttribute("available")]
        public string Available { get; set; }
    }
}