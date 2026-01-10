using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using MiniPojetCSarp_SMART_Coding.Models;

=======
using GestionReservations.Models;
>>>>>>> d8c38fb67960cc8509f0f6bbbb90e466a60d9186

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
