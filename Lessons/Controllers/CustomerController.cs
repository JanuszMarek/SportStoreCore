using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessons.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lessons.Controllers
{
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    public class CustomerController : Controller
    {
        //[Route("myroute")]
        public ViewResult Index() => View("Result",
            new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            });

        
        public ViewResult List(string id)
        {
            Result r = new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(List)
            };
            r.Data["id"] = id ?? "<no value>";
            r.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", r);
        }

    }
}