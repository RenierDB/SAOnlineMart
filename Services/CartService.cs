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

        public void AddToCart(OrderProduct product)
        {
            var cartItems = GetCartItems();
            if (cartItems.Exists(p => p.Id == product.Id))
            {
                var item = cartItems.Find(p => p.Id == product.Id);
                product.Quantity += item.Quantity;
                cartItems.RemoveAll(p => p.Id == product.Id);
            }
            cartItems.Add(product);
            SaveCartItems(cartItems);
        }

        public void RemoveFromCart(int productId)
        {
            var cartItems = GetCartItems();
            var itemToRemove = cartItems.Find(p => p.Id == productId);
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
