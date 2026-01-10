using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{
    public class Salle : Ressource
    {

        public int Capacite { get; set; }

        public Salle(int id, string nom, Responsable responsable, string contact, int capacite)
            : base(id, nom, responsable, contact)
        {

            Capacite = capacite;
        }
           
        public override string GetTypeRessource()
        {
            return "Salle";
        }
    }
     

    }
