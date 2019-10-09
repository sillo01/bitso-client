namespace BitsoClient.Models.Orders
{
    public class NewOrder
    {
        public string book { get; set; }
        public string side { get; set; }
        public string type { get; set; }
        public string major { get; set; }
        public string minor { get; set; }
        public string price { get; set; }
    }
}