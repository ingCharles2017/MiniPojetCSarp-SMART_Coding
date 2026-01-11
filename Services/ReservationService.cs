using System.Collections.Generic;
using System.Linq;
using MiniPojetCSarp_SMART_Coding.Models;

namespace MiniPojetCSarp_SMART_Coding.Services
{
    public class ReservationService
    {
        public static List<Reservation> reservations = new List<Reservation>();

        public static void CreerReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public Reservation ObtenirParId(int id)
        {
            return reservations.FirstOrDefault(r => r.Id == id);
        }

        public static List<Reservation> ListerReservations()
        {
            return reservations;
        }
    }
}
