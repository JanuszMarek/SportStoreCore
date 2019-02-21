using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Lessons.Areas.UsingViewComponents.Models;

namespace Lessons.Areas.UsingViewComponents.Controllers
{
    //Combo Controller-ViewComponent
    [ViewComponent(Name = "ComboComponent")]
    [Area("UsingViewComponents")]
    public class CityController : Controller
    {
        private ICityRepository repository;
        public CityController(ICityRepository repo)
        {
            repository = repo;
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(City newCity)
        {
            repository.AddCity(newCity);
            return RedirectToAction("Index", "Home");
        }

        public IViewComponentResult Invoke() => new ViewViewComponentResult()
        {
            ViewData = new ViewDataDictionary<IEnumerable<City>>(ViewData,repository.Cities)
        };

    }
}