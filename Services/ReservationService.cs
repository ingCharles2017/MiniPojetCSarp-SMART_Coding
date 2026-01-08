using System.Collections.Generic;
using System.Linq;
using GestionReservations.Models;


namespace ReservationService {

    public class ReservationService
    {
        private List<Reservation> reservations = new List<Reservation>();

        public void CreerReservation(Reservation reservation)
        {
            reservation.Add(reservation);

        }

        public Reservation ObtenirParId(int Id)
        {
            return reservations.FirstOrDefault(r => r.Id == id);
        }

        }



}