<<<<<<< HEAD
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
=======
using System;
using System.Collections.Generic;
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
public void AjouterRessource(Ressource ressource)
        {
            ressources.Add(ressource);
            Console.WriteLine("Ressource ajoutée avec succès.");
        }

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

        public Ressource ObtenirParId(int id)
        {
            foreach (Ressource r in ressources)
            {
                if (r.Id == id)
                {
                    return r;
                }
            }
            return null;
>>>>>>> 52cb777b38368aa3fec9567d5e7448d68038284c
        }

        public List<Ressource> ListerRessources()
        {
            return ressources;
        }
    }
<<<<<<< HEAD

=======
>>>>>>> 52cb777b38368aa3fec9567d5e7448d68038284c
}