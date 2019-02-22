using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.UsingTagHelpers.Models;

namespace Lessons.Areas.UsingTagHelpers.Controllers
{
    [Area("UsingTagHelpers")]
    public class HomeController : Controller
    {
        private ITagRepository repository;

        public HomeController(ITagRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Cities);

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(TagCity city)
        {
            repository.AddCity(city);
            return RedirectToAction("Index");
        }

    }
}