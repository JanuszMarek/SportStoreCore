using Microsoft.AspNetCore.Mvc;
using SportsStoreCore.Models;

namespace SportsStoreCore.Component
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartservice)
        {
            cart = cartservice;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
