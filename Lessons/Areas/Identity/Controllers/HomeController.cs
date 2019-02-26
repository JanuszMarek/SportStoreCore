using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lessons.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class HomeController : Controller
    {
        public ViewResult Index() => View(new Dictionary<string, object>
            {
                ["Placeholder"] = "Placeholder"
            });

    }
}