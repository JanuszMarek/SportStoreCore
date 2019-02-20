using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lessons.Areas.Filters.Controllers
{
    [Area("Filters")]
    [RequireHttps]
    public class HomeController : Controller
    {
        /* You can get the same with RequireHttps Attribute
        public IActionResult Index()
        {
            if (!Request.IsHttps)
            {
                return new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
            else
            {
                return View("Message","This is the Index action on the Home controller");
            }

        }
        */

        
        public ViewResult Index() => View("Message","This is the Index action on the Home controller");

        [RequireHttps]
        public ViewResult SecondAction() => View("Message","This is the SecondAction action on the Home controller");

    }
}