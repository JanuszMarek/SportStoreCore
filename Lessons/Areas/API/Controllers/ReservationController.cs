using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lessons.Areas.API.Models;

namespace Lessons.Areas.API.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private IReservRepository repository;

        public ReservationController(IReservRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet("{id}")]
        public Reservation Get(int id) => repository[id];

        [HttpPost]
        public Reservation Post([FromBody] Reservation res) => repository.AddReservation(new Reservation
          {
              ClientName = res.ClientName,
              Location = res.Location
          });

        [HttpPut]
        public Reservation Put([FromBody] Reservation res) => repository.UpdateReservation(res);

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReservation(id);
    }
}