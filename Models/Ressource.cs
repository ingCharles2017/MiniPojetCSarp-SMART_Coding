using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Classe de base abstraite pour toutes les ressources (Salles, Chambres, Équipements).
/// </summary>
/// 
namespace MiniPojetCSarp_SMART_Coding.Models
{
    public abstract class Ressource
    {
        public int Id { get; }
        public string Nom { get; set; }
        public Responsable Responsable { get; set; }
        public string Contact { get; set; } = "N/A"; // valeur par défaut

        protected Ressource(int id, string nom, Responsable responsable, string contact = "N/A")
        {
            Id = id;
            Nom = nom;
            Responsable = responsable ?? new Responsable(); // jamais null
            Contact = contact;
        }

        /// <summary>
        /// Retourne le type de ressource sous forme de chaîne de caractères.
        /// </summary>
        public abstract string GetTypeRessource();
    }



}

