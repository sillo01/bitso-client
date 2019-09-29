namespace BitsoClient.Models.OrderBook
{
    public class Order
    {
        public string book { get; set; }
        public string price { get; set; }
        public string amount { get; set; }

        public double pPrice
        {
            get
            {
                return double.Parse(price);
            }
        }
        public double pAmount
        {
            get
            {
                return double.Parse(amount);
            }
        }

        public override string ToString()
        {
            return $"Price ${this.price}\nAmount {this.amount}\nBook {this.book}";
        }
    }
}