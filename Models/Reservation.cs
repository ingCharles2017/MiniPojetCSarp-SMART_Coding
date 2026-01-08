using System;
using System.Collections.Generic;
using System.Text;

namespace GestionReservations.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Ressource Ressource { get; set; }
        public Client ClientInterne { get; set; }
        public DateTime DateReservation { get; set; }
        public string Statut { get; set; }

        public Reservation(int id, Ressource ressource, Personne client, DateTime date)
        {
            Id = id;
            Ressource = ressource;
            ClientInterne = client;
            DateReservation = date;
            Statut = "Confirmée";
        }
    }
}
