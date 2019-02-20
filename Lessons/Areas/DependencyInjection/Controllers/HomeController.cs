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

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            //Action is depend of MemoryRepository
            // return View(new MemoryRepository().Products);

            //return View(Repository.Products);
            return View(repository.Products);
        }
    }
}