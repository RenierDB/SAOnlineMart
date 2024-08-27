// Controllers/OrderController.cs
using Microsoft.AspNetCore.Mvc;
using SAOnlineMart.Data;
using SAOnlineMart.Models;
using SAOnlineMart.Services;
using System.Threading.Tasks;

namespace SAOnlineMart.Controllers
{
    public class OrderController : Controller
    {
        private readonly SAOnlineMartContext _context;
        private readonly CartService _cartService;

        public OrderController(SAOnlineMartContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        public IActionResult Checkout()
        {
            var cartItems = _cartService.GetCartItems();
            var orderViewModel = new OrderViewModel { CartItems = cartItems };
            return View(orderViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    UserId = 1, // Replace with actual user ID
                    OrderDate = DateTime.Now,
                    Products = orderViewModel.CartItems,
                    ShippingAddress = orderViewModel.ShippingAddress,
                    Payment = orderViewModel.Payment
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // Clear the cart
                _cartService.ClearCart();

                return RedirectToAction("Confirmation");
            }

            return View(orderViewModel);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
