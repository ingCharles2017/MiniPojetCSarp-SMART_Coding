using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{
    public class Client
    {
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

