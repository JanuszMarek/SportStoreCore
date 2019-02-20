using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessons.Areas.Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lessons.Areas.Filters.Controllers
{
    
  //  [RequireHttps]
    [HttpsOnly]
  //  [Profile]
   // [ProfileAsync]
    [Area("Filters")]
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

        //[RequireHttps]
        [ViewResultDetails]
        public ViewResult Index() => View("Message","This is the Index action on the Home controller");

        //[RequireHttps]
        public ViewResult SecondAction() => View("Message","This is the SecondAction action on the Home controller");

        [RangeException]
        public ViewResult GenerateException(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else if (id > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else
            {
                return View("Message", $"The value is {id}");
            }
        }

    }
}