using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SAOnlineMart.Models;
using System.Collections.Generic;

namespace SAOnlineMart.Services
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string CartCookieName = "CartCookie";

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<OrderProduct> GetCartItems()
        {
            var cartCookie = _httpContextAccessor.HttpContext.Request.Cookies[CartCookieName];
            if (string.IsNullOrEmpty(cartCookie))
            {
                return new List<OrderProduct>();
            }

            return JsonConvert.DeserializeObject<List<OrderProduct>>(cartCookie);
        }

        public void AddToCart(Product product)
        {
            var curprod = new OrderProduct { Product = product, Quantity = 1, ProductId = product.Id };
            var cartItems = GetCartItems();
            if (cartItems.Exists(p => p.ProductId == product.Id))
            {
                var item = cartItems.Find(p => p.ProductId == product.Id);
                curprod.Quantity += item.Quantity;
                cartItems.RemoveAll(p => p.ProductId == product.Id);
            }
            cartItems.Add(curprod);
            SaveCartItems(cartItems);
        }

        public void RemoveFromCart(int productId)
        {
            var cartItems = GetCartItems();
            var itemToRemove = cartItems.Find(p => p.Product.Id == productId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
                SaveCartItems(cartItems);
            }
        }

        public void ClearCart()
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(CartCookieName);
        }

        private void SaveCartItems(List<OrderProduct> cartItems)
        {
            var cartCookie = JsonConvert.SerializeObject(cartItems);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(CartCookieName, cartCookie, new CookieOptions
            {
                Expires = System.DateTimeOffset.UtcNow.AddDays(1)
            });
        }
    }
}
