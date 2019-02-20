using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.DependencyInjection.Models;
using Lessons.Areas.DependencyInjection.Infrastructure;

namespace Lessons.Areas.DependencyInjection.Controllers
{
    [Area("DependencyInjection")]
    public class HomeController : Controller
    {
        //public IRepository Repository { get; set; } = new MemoryRepository();
        //custom DI
        //public IRepository Repository { get; } = TypeBroker.Repository;

        private IRepository repository;
        //private ProductTotalizer totalizer;

        public HomeController(IRepository repo, ProductTotalizer total)
        {
            repository = repo;
            //totalizer = total;
        }

        public IActionResult Index([FromServices]ProductTotalizer totalizer)
        {
            //Action is depend of MemoryRepository
            // return View(new MemoryRepository().Products);

            //return View(Repository.Products);

            //Manually Requesting an Implementation Object 
            //IRepository repository = HttpContext.RequestServices.GetService<IRepository>();

            ViewBag.Total = totalizer.Total;
            ViewBag.Totalizer = totalizer.Repository.ToString();
            ViewBag.HomeController = repository.ToString();

            return View(repository.Products);
        }
    }
}