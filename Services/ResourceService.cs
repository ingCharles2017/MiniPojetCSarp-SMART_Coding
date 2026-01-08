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