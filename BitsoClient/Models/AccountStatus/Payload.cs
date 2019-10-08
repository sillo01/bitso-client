namespace BitsoClient.Models.AccountStatus
{
    public class Payload
    {
        public string client_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string status { get; set; }
        public string daily_limit { get; set; }
        public string monthly_limit { get; set; }
        public string daily_remaining { get; set; }
        public string monthly_remaining { get; set; }
        public string cell_phone { get; set; }
        public string cell_phone_stored { get; set; }
        public string email_stored { get; set; }
        public string official_id { get; set; }
        public string proof_of_residency { get; set; }
        public string signed_contract { get; set; }
        public string origin_of_funds { get; set; }
    }
}