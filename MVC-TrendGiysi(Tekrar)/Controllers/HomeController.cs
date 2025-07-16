using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_TrendGiysi_Tekrar_.Models;
using MVC_TrendGiysi_Tekrar_.Models.CartModel;
using MVC_TrendGiysi_Tekrar_.Views.Services;

namespace MVC_TrendGiysi_Tekrar_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_productService.GetProducts());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AddToCart(int id)
        {
            var product = _productService.GetProductViewModel(id);
            if (product != null)
            {
                Cart cart = new Cart();

                cart.id = product.Id;
                cart.ProductName = product.ProductName;
                cart.UnitPrice = product.UnitPrice;

                CartItem cartItem = new CartItem();
                

            }
            else
            {
                TempData["Message"] = "Product not found.";
            }
            return RedirectToAction("Index");
        }
    }
}
