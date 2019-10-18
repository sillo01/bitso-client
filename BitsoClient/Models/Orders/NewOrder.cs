namespace BitsoClient.Models.Orders
{
    public class NewOrder
    {
        public NewOrder(string book, string side, string type)
        {
            this.book = book;
            this.side = side;
            this.type = type;
        }
        public string book { get; set; }
        public string side { get; set; }
        public string type { get; set; }
        public string major { get; set; }
        public string minor { get; set; }
        public string price { get; set; }
        public string stop { get; set; }
        public string time_in_force { get; set; }
        public string client_id { get; set; }
    }
}