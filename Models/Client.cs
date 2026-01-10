using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// Représente un client interne effectuant une réservation.
/// </summary>
namespace MiniPojetCSarp_SMART_Coding.Models
{
    public class Client
    {
        private static int _nextId = 1; // compteur auto pour ID
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }

        public Client(string nom, string email)
        {
            Nom = nom;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Nom} ({Email})";
        }

    }
}


