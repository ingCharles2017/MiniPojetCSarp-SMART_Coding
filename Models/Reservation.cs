using System;
using System.Collections.Generic;
using System.Text;


namespace MiniPojetCSarp_SMART_Coding.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Ressource Ressource { get; set; }
        public Client ClientInterne { get; set; }
        public DateTime DateReservation { get; set; }

        public enum StatutReservation
        {
            EnAttente,
            Confirmee,
            Annulee
        }

        public StatutReservation Statut { get; set; }

        public Reservation(int id, Ressource ressource, Client client, DateTime date,StatutReservation statu)
        {
            Id = id;
            Ressource = ressource;
            ClientInterne = client;
            DateReservation = date;
            Statut = statu;
        }
    }
}

