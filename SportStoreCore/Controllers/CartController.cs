using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStoreCore.Models;
using SportsStoreCore.Infrastructure;
using Newtonsoft.Json;
using SportsStoreCore.Models.ViewModels;

namespace SportsStoreCore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl) =>
            View(new CartIndexViewModel
            {
                //Cart = GetCart(),
                Cart = cart,
                ReturnUrl = returnUrl
            });

        public RedirectToActionResult AddToCart(int productID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

            if(product != null)
            {
               //Cart cart = GetCart();
                cart.AddItem(product, 1);
                //SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

            if (product != null)
            {
                //Cart cart = GetCart();
                cart.RemoveLine(product);
                //SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        /* Not neccesary, because of add service to manage Cart
        private Cart GetCart()
        {
            //var str = HttpContext.Session.GetString("Cart");
            //Cart cart = JsonConvert.DeserializeObject<Cart>(str) ?? new Cart();
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
        */
    }
}