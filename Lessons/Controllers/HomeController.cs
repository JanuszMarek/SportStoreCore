using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lessons.Models;
using System.Text;
using Lessons.Infrastructure;

namespace Lessons.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        }

        public ViewResult CustomVariable(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable),
            };
            //r.Data["id"] = RouteData.Values["id"];
            r.Data["id"] = id ?? "<no value>";
            r.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", r);
        }

        public ViewResult SimpleForm() => View();

        /*
        public ViewResult ReceiveForm()
        {
            var name = Request.Form["name"];
            var city = Request.Form["city"];
            return View("StringResult", $"{name} lives in {city}");
        }
        
            //Create HTML Response
        public void ReceiveForm(string name, string city)
        {
            Response.StatusCode = 200;
            Response.ContentType = "text/html";
            byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} lives in {city}</body></html>");
            Response.Body.WriteAsync(content, 0, content.Length);
        }
        
            //Create HTML Response using CustomHtmlResult
        public IActionResult ReceiveForm(string name, string city) => new CustomHtmlResult
        {
            Content = $"{name} lives in {city}"
        };
        */

        public ViewResult ReceiveForm(string name, string city) => View("StringResult", $"{name} lives in {city}");

    }
}