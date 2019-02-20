using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.API.Models
{
    public interface IReservRepository
    {
        IEnumerable<Reservation> Reservations { get; }

        Reservation this[int id] { get; }

        Reservation AddReservation(Reservation reservation);

        Reservation UpdateReservation(Reservation reservation);

        void DeleteReservation(int id);

    }
}
