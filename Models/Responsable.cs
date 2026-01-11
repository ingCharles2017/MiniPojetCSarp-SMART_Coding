using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPojetCSarp_SMART_Coding.Models
{
    /// <summary>
    /// Représente un responsable interne chargé de la gestion d'une ressource.
    /// </summary>
    public class Responsable
    {
        public int Id { get; set; }
        public string Nom { get; set; } 
        public string Email { get; set; } 

        public Responsable() { }
    }
}