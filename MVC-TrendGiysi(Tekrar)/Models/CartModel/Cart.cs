namespace MVC_TrendGiysi_Tekrar_.Models.CartModel
{
    public class Cart
    {
        public Cart()
        {
            Quantity = 1;
        }
        public int id { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? SubTotal
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }


    }
}
