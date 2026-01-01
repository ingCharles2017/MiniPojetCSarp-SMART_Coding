using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{
    public class Equipement:Ressource
    {
        public Equipement(int id, string nom, string responsable, string contact) : base(id, nom, responsable, contact) 
        { }
        public override string GetTypeRessource()
        {
            return "Equipement";
        }

    }
}
