using Newtonsoft.Json;

namespace BitsoClient.Models.AccountStatus
{
    public class Payload
    {
        [JsonPropertyAttribute("client_id")]
        public string ClientId { get; set; }
        [JsonPropertyAttribute("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyAttribute("last_name")]
        public string LastName { get; set; }
        [JsonPropertyAttribute("status")]
        public string Status { get; set; }
        [JsonPropertyAttribute("daily_limit")]
        public string DailyLimit { get; set; }
        [JsonPropertyAttribute("monthly_limit")]
        public string MonthlyLimit { get; set; }
        [JsonPropertyAttribute("daily_remaining")]
        public string DailyRemaining { get; set; }
        [JsonPropertyAttribute("monthly_remaining")]
        public string MonthlyRemaining { get; set; }
        [JsonPropertyAttribute("cell_phone")]
        public string CellPhone { get; set; }
        [JsonPropertyAttribute("cell_phone_stored")]
        public string CellPhoneStored { get; set; }
        [JsonPropertyAttribute("email_stored")]
        public string EmailStored { get; set; }
        [JsonPropertyAttribute("official_id")]
        public string OfficialId { get; set; }
        [JsonPropertyAttribute("proof_of_residency")]
        public string ProofOfResidency { get; set; }
        [JsonPropertyAttribute("signed_contract")]
        public string SignedContract { get; set; }
        [JsonPropertyAttribute("origin_of_funds")]
        public string OriginOfFunds { get; set; }
    }
}