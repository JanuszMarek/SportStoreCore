using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Lessons.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Message = "Heloł";
            return View(DateTime.Now);
        }

        public ViewResult StringResult()
        {
            return View((object)"Hello World");
        }
        /*
        public RedirectResult Redirect() => RedirectPermanent("/Example/Index");
        
        public RedirectToRouteResult Redirect() => RedirectToRoute(new
            {
                controller = "Example",
                action = "Index",
                id = 21
            });
            */
        public RedirectToActionResult Redirect() => RedirectToAction(nameof(Index));

        public JsonResult JsonAction() => Json(new[] { "Alice", "Bob", "Joe" });

        public ContentResult ContentAction() => Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");

        public ObjectResult ObjectAction() => Ok(new string[] { "Alice", "Bob", "Joe" });

        public VirtualFileResult VirtualFileAction() => File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");
        //thank that you can use <link rel="stylesheet" href="@Url.Action("VirtualFileAction", "Example")" /> in Layout to set bootstrap.css


        //public StatusCodeResult NotFoundAction() => StatusCode(StatusCodes.Status404NotFound);
        public StatusCodeResult NotFoundAction() => NotFound();
    }
}