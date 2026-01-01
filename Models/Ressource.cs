using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{
    public abstract class Ressource
    {
        public int Id { get; }
        public string Nom { get; set; }
        public string Responsable { get; set; }
        public string Contact { get; set; }

        protected Ressource(int id, string nom, string responsable, string contact)
        {
            Id = id;
            Nom = nom;
            Responsable = responsable;
            Contact = contact;
        }

        public abstract string GetTypeRessource();
    }
}
