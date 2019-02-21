using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lessons.Areas.ViewLesson.Controllers
{
    [Area("ViewLesson")]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(new string[] { "Apple", "Orange", "Pear" });
        }

        public ViewResult List() => View();

    }
}