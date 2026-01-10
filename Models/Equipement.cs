using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{
    public class Equipement:Ressource
    {

        public string Categorie { get; set; }
        public bool EstDisponible { get; set; }

        public Equipement(int id, string nom, Responsable responsable, /*string contact,*/ string categorie,bool EstDispo ) : base(id,nom,responsable) 
        {
            Categorie = categorie;
            EstDisponible = EstDispo;

        }
        public override string GetTypeRessource()
        {
            return "Equipement";
        }

    }
}
