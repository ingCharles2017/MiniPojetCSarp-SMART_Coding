using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{   
    public class Chambre:Ressource
    {

        public int Numero { get; set; }
        public int NombreDeLists { get; set; }
   

        public Chambre(int id, string nom, Responsable responsable, string contact, int numero, int nombreDeLists) : base(id, nom, responsable, contact)
        {

                Numero = numero;
                NombreDeLists = nombreDeLits;
            
        }
        public override string GetTypeRessource()
        {
            return "Chambre";
        }

    }
}
