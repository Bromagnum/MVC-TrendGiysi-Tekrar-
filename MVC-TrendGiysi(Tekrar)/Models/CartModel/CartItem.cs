using MVC_TrendGiysi_Tekrar_.Models.ViewModel;
using MVC_TrendGiysi_Tekrar_.Models.Contexts;

namespace MVC_TrendGiysi_Tekrar_.Models.CartModel
{
    public class CartItem
    {
        Dictionary<int, Cart> _MyCart = new Dictionary<int, Cart>();
        public void AddItem(Cart item)
        {
            if (_MyCart.ContainsKey(item.id))
            {
                _MyCart[item.id].Quantity++;
            }
            else
            {
                _MyCart.Add(item.id, item);
            }
        }
    }
}
