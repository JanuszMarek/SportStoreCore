using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.API.Models;

namespace Lessons.Areas.API.Controllers
{
    [Area("API")]
    public class HomeController : Controller
    {
        private IReservRepository repository { get; set; }

        public HomeController(IReservRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(repository.Reservations);
        }

        [HttpPost]
        public IActionResult AddReservations(Reservation reservation)
        {
            repository.AddReservation(reservation);
            return RedirectToAction(nameof(Index));
        }
    }
}