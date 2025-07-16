using MVC_TrendGiysi_Tekrar_.Models.Contexts;
using MVC_TrendGiysi_Tekrar_.Models.ViewModel;

namespace MVC_TrendGiysi_Tekrar_.Views.Services
{
    public class ProductService : IProductService
    {
        private readonly GiysiContext _context;
        public ProductService(GiysiContext context)
        {
            _context = context;
        }
        public List<ProductViewModel> GetProducts()
        {

            var products = _context.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice
                }).ToList();
            return products;
        }

        public ProductViewModel GetProductViewModel(int id)
        {
            
            ProductViewModel productView=GetProducts().FirstOrDefault(p => p.Id == id);
            return productView;
        }
    }
}
