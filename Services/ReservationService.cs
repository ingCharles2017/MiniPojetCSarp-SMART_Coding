
using System;   
using System.Collections.Generic;
using GestionReservations.Models;

namespace GestionReservations.Services
{
    public class ReservationService
    {
        private List<Reservation> reservations;

        public ReservationService()
        {
            reservations = new List<Reservation>();
        }