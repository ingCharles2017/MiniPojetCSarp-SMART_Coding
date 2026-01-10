using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
using MiniPojetCSarp_SMART_Coding.Models;

namespace RessourceService
=======
using MiniPojetCSarp_SMART_Coding.Models;

namespace MiniPojetCSarp_SMART_Coding.Services
>>>>>>> d8c38fb67960cc8509f0f6bbbb90e466a60d9186
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
<<<<<<< HEAD
            return ressources.FirstOrDefault(r => r.Id == id);
=======
            foreach (Ressource r in ressources)
            {
                if (r.Id == id)
                {
                    return r;
                }
            }
            return null;
>>>>>>> d8c38fb67960cc8509f0f6bbbb90e466a60d9186
        }

        // Retourner la liste des ressources
        public List<Ressource> ListerRessources()
        {
            return ressources;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> d8c38fb67960cc8509f0f6bbbb90e466a60d9186
