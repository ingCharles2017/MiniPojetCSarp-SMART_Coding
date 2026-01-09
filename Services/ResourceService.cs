using System.Collections.Generic;
using System.Linq;
using MiniPojetCSarp_SMART_Coding.Models;
using Ressource.Models;

namespace RessourceService
{
   public class RessourceService
    {
        private List<Ressource> ressources = new List<Ressource>();

        public void AjouterRessource( Ressource ressource)
        {
            return ressource.Add(ressource);
        }

        public Ressource TrouverParId (int Id)
        {
            return ressources.FirstOrDefault(r => r.Id == id);
        }

        public List<Ressource> ListerRessources()
        {
            return ressources;
        }
    }

}