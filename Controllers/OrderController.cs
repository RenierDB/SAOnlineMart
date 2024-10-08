﻿// Controllers/OrderController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SAOnlineMart.Data;
using SAOnlineMart.Models;
using SAOnlineMart.Services;
using System.Security.Claims;
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
                var viewmodelOrders = orderViewModel.CartItems;
                List<Product> products = new();

                foreach (var item in viewmodelOrders)
                {
                    products.Add(item.Product);
                }

                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    ShippingAddress = orderViewModel.ShippingAddress,
                    Payment = orderViewModel.Payment,
                    Products = products
                };

     


                _context.Add(order);
                await _context.SaveChangesAsync();
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
