using Microsoft.AspNetCore.Mvc;
using SAOnlineMart.Models;
using SAOnlineMart.Services;

namespace SAOnlineMart.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public IActionResult AddToCart(Product product)
        {
            _cartService.AddToCart(product);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
