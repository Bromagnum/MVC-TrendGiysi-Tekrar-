using System.ComponentModel;

namespace MVC_TrendGiysi_Tekrar_.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitINStock { get; set; }

        
        public Category CategoryId { get; set; }
    }
}
