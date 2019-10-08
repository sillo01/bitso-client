namespace BitsoClient.Models.AccountBalance
{
    public class Balance
    {
        public string currency { get; set; }
        public string total { get; set; }
        public string locked { get; set; }
        public string available { get; set; }
    }
}