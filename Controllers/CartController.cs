using Microsoft.AspNetCore.Mvc;
using SAOnlineMart.Helpers;
using SAOnlineMart.Models;
using System.Collections.Generic;
using System.Linq;

namespace SAOnlineMart.Controllers
{
    public class CartController : Controller
    {
        private readonly SAOnlineMartContext _context;

        public CartController(SAOnlineMartContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCartFromSession();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var cart = GetCartFromSession();
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                var cartItem = cart.FirstOrDefault(c => c.ProductID == productId);
                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    cart.Add(new OrderItem
                    {
                        ProductID = productId,
                        Product = product,
                        Quantity = quantity,
                        UnitPrice = product.Price
                    });
                }
                SaveCartToSession(cart);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCart(int productId, int quantity)
        {
            var cart = GetCartFromSession();
            var cartItem = cart.FirstOrDefault(c => c.ProductID == productId);

            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                SaveCartToSession(cart);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cart = GetCartFromSession();
            var cartItem = cart.FirstOrDefault(c => c.ProductID == productId);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
                SaveCartToSession(cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = GetCartFromSession();
            // Logic to process the checkout, e.g., creating an Order in the database
            SaveCartToSession(new List<OrderItem>());
            return View();
        }
        private List<OrderItem> GetCartFromSession()
        {
            // Retrieve the cart object from session
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>("Cart");
            return cart ?? new List<OrderItem>(); // Return an empty list if the cart is null
        }

        private void SaveCartToSession(List<OrderItem> cart)
        {
            // Save the cart object to session
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }

        private List<OrderItem> GetCartFromSession()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>("Cart");
            return cart ?? new List<OrderItem>();
        }

        private void SaveCartToSession(List<OrderItem> cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
    }
}

