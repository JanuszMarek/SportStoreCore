using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.UsingTagHelpers.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public ViewResult Edit()
        {
            ViewBag.Countries = new SelectList(repository.Cities.Select(c => c.Country).Distinct());

            return View("Create", repository.Cities.First());
        }

        public ViewResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TagCity city)
        {
            ViewBag.Countries = new SelectList(repository.Cities.Select(c => c.Country).Distinct());

            repository.AddCity(city);
            return RedirectToAction("Index");
        }

    }
}