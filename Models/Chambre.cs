using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{   
    public class Chambre:Ressource
    {

        public int Numero { get; set; }
        public int NombreDeLists { get; set; }
   

        public Chambre(int id, string nom, Responsable responsable,/* string contact,*/ int numero, int nombreDeLit) :
            base(id, nom, responsable)
        {

                Numero = numero;
                NombreDeLists = nombreDeLit;
            
        }
        public override string GetTypeRessource()
        {
            return "Chambre";
        }

    }
}
