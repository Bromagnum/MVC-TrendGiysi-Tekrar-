using MVC_TrendGiysi_Tekrar_.Models.ViewModel;

namespace MVC_TrendGiysi_Tekrar_.Views.Services
{
    public interface IProductService
    {
        List<ProductViewModel> GetProducts();
        ProductViewModel GetProductViewModel(int id);
    }
}
