using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsStoreCore.Infrastructure;
using SportsStoreCore.Models;
using SportsStoreCore.Models.ViewModels;

namespace SportsStoreCore.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            uptime = up;
            logger = log;
        }


        public ViewResult Index(bool throwException = false)
        {
            if (throwException)
            {
                throw new System.NullReferenceException();
            }

            logger.LogDebug($"Handled {Request.Path} at uptime {uptime.Uptime}");

            HomeIndexViewModel indexViewModel = new HomeIndexViewModel();
            indexViewModel.StringDict = new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{uptime.Uptime}ms"
            };

            indexViewModel.Result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            };

            return View(indexViewModel);
        }
            

        public ViewResult Error()
        {
            return View(nameof(Index), new Dictionary<string, string>
            {
                ["Message"] = "Something goes wrong.... Try again!"
            });
        }

    }
}