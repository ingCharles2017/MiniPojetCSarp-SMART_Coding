using System.Collections.Generic;
using System.Linq;
using GestionReservations.Models;

namespace GestionReservations.Services
{
    public class ReservationService
    {
        private List<Reservation> reservations = new List<Reservation>();

        public void CreerReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public Reservation ObtenirParId(int id)
        {
            return reservations.FirstOrDefault(r => r.Id == id);
        }

        public List<Reservation> ListerReservations()
        {
            return reservations;
        }
    }
}
