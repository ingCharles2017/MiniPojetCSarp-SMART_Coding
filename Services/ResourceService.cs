using System;
using System.Collections.Generic;
using System.Linq;
using MiniPojetCSarp_SMART_Coding.Models;

namespace MiniPojetCSarp_SMART_Coding.Services
{
    public class RessourceService
    {
        private List<Ressource> ressources;

        public RessourceService()
        {
            ressources = new List<Ressource>();
        }

        // Ajouter une ressource
        public void AjouterRessource(Ressource ressource)
        {
            ressources.Add(ressource);
            Console.WriteLine("Ressource ajoutée avec succès.");
        }

        // Afficher toutes les ressources
        public void AfficherRessources()
        {
            if (ressources.Count == 0)
            {
                Console.WriteLine("Aucune ressource disponible.");
                return;
            }

            foreach (Ressource r in ressources)
            {
                Console.WriteLine(
                    "ID : " + r.Id +
                    " | Nom : " + r.Nom +
                    " | Type : " + r.GetTypeRessource()
                );
            }
        }

        // Obtenir une ressource par ID
        public Ressource ObtenirParId(int id)
        {
            return ressources.FirstOrDefault(r => r.Id == id);
        }

        // Retourner la liste des ressources
        public List<Ressource> ListerRessources()
        {
            return ressources;
        }
    }
}
