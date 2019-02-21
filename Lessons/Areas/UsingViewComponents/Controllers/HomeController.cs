using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.UsingViewComponents.Models;

namespace Lessons.Areas.UsingViewComponents.Controllers
{
    [Area("UsingViewComponents")]
    public class HomeController : Controller
    {
        private IProductCompRepository repository;

        public HomeController(IProductCompRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(ProductComp newProduct)
        {
            repository.AddProduct(newProduct);

            return RedirectToAction("Index");
        }

    }
}