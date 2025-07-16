using Microsoft.EntityFrameworkCore;
using MVC_TrendGiysi_Tekrar_.Models.Contexts;

namespace MVC_TrendGiysi_Tekrar_.Models.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
