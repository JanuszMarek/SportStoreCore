using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Lessons.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class ClaimsController : Controller
    {
        [Authorize]
        public ViewResult Index() => View(User?.Claims);

    }
}