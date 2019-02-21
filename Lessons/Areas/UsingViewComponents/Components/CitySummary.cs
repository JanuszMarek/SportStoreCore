using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;
using Lessons.Areas.UsingViewComponents.Models;

namespace Lessons.Areas.UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke(bool showList)
        {
            //return $"{repository.Cities.Count()} cities, {repository.Cities.Sum(c => c.Population)} people";

            //returning PartialView
            /*
            return View(new CityViewModel
            {
                Cities = repository.Cities.Count(),
                Population = repository.Cities.Sum(c => c.Population)
            });
            */

            //returning HTML Content
            //return new HtmlContentViewComponentResult(new HtmlString("This is <h3><i>Sparta</i></h3>"));

            //Getting Context Data 

            if(showList)
            {
                return View("CityList", repository.Cities);
            }
            else
            {
                string target = RouteData.Values["id"] as string;
                var cities = repository.Cities.Where(city => target == null || string.Compare(city.Country, target, true) == 0);
                return View(new CityViewModel
                {
                    Cities = cities.Count(),
                    Population = cities.Sum(c => c.Population)
                });
            }

        }
    }
}
