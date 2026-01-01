using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{
    public class Salle : Ressource
    {
        public Salle(int id, string nom, string responsable, string contact)
            : base(id, nom, responsable, contact) { }
        public override string GetTypeRessource()
        {
            return "Salle";
        }
    }
     

    }
