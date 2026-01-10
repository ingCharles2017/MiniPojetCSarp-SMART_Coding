using MiniPojetCSarp_SMART_Coding.Models;
using MiniPojetCSarp_SMART_Coding.Services;
using System;

namespace MiniPojetCSarp_SMART_Coding
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // Création des services (logique métier)
            RessourceService ressourceService = new RessourceService();
            ReservationService reservationService = new ReservationService();
            //Methode Utilitaire pour creer les responsable:
            static Responsable CreerResponsable()
            {
                Console.Write("ID Responsable : ");
                int idResp = int.Parse(Console.ReadLine());

                Console.Write("Nom Responsable : ");
                string nomResp = Console.ReadLine();

                Console.Write("Email Responsable : ");
                string emailResp = Console.ReadLine();

                return new Responsable
                {
                    Id = idResp,
                    Nom = nomResp,
                    Email = emailResp
                };
            }

            //
            //
            // ==================================
            // MENU DE GESTION DES RESSOURCES
            // ==================================
            static void MenuRessources(RessourceService service)
            {
                Console.Clear(); //pour nettoyyer la console
                Console.WriteLine("--- GESTION DES RESSOURCES ---");
                Console.WriteLine("1. Ajouter une chambre");
                Console.WriteLine("2. Ajouter une salle");
                Console.WriteLine("3. Ajouter un équipement");
                Console.WriteLine("4. Afficher les ressources");
                Console.WriteLine("0. Retour");
                Console.Write("Choix : ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    // ==================================================
                    // 1️⃣ AJOUT D’UNE CHAMBRE
                    // ==================================================
                    case "1":
                        {
                            

                            Console.Write("ID Chambre : ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Nom Chambre : ");
                            string nom = Console.ReadLine();

                            /*Console.Write("Contact : ");
                            string contact = Console.ReadLine();*/

                            Console.Write("Numéro de chambre : ");
                            int numero = int.Parse(Console.ReadLine());

                            Console.Write("Nombre de lits : ");
                            int nbLits = int.Parse(Console.ReadLine());
                            Console.WriteLine("Ajouter le responsable de la Chambre : ");
                            Responsable responsable = CreerResponsable();

                            //Creation de la chambre
                            Chambre chambre = new Chambre(
                                id,
                                nom,
                                responsable,
                               /* contact,*/
                                numero,
                                nbLits
                            );

                            service.AjouterRessource(chambre);
                            Console.WriteLine("Chambre ajoutée avec succès !");
                            Console.WriteLine("Presser une touche pour continuer !");
                            Console.ReadKey();
                            break;
                        }
                    // ==================================================
                    //  AJOUT D’UNE SALLE
                    // ==================================================
                    case "2":
                        {
                           

                            Console.Write("ID Salle : ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Nom Salle : ");
                            string nom = Console.ReadLine();                          

                            Console.Write("Capacité : ");
                            int capacite = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ajouter le responsable de la Salle : ");
                             //appel de la fonction utilitaire pour creer le responsable
                            Responsable responsable = CreerResponsable();
                           //Creation de la salle
                            Salle salle = new Salle(
                                id,
                                nom,
                                responsable,                               
                                capacite
                            );

                            service.AjouterRessource(salle);
                            Console.WriteLine("Salle ajoutée avec succès !");
                            Console.WriteLine("Presser une touche pour continuer !");
                            Console.ReadKey();
                            break;
                        }
                    // ==================================================
                    // 3️ AJOUT D’UN ÉQUIPEMENT
                    // ==================================================
                    case "3":
                        {                          

                            Console.Write("ID Équipement : ");
                            int id = int.Parse(Console.ReadLine());

                            Console.Write("Nom Équipement : ");
                            string nom = Console.ReadLine();

                            Console.Write("Catégorie : ");
                            string categorie = Console.ReadLine();
                            bool EstDispo = true;
                            Console.WriteLine("Ajouter le responsable de l'equipement : ");
                            //appel de la fonction utilitaire pour creer le responsable
                            Responsable responsable = CreerResponsable();
                            Equipement equipement = new Equipement(
                                id,
                                nom,
                                responsable,
                               /* contact,*/
                                categorie,
                                EstDispo

                            );

                            service.AjouterRessource(equipement);
                            Console.WriteLine("Équipement ajouté avec succès !");
                            Console.WriteLine("Presser une touche pour continuer !");
                            Console.ReadKey();
                            break;
                        }

                    case "4":
                        // ===== Affichage des ressources =====
                        Console.WriteLine("\nListe des ressources :");
                        foreach (Ressource r in service.ListerRessources())
                        {
                            Console.WriteLine(
                                $"ID: {r.Id} | Nom: {r.Nom} | Type: {r.GetTypeRessource()} |Responsable :{r.Responsable.Nom} Contact:{r.Responsable.Email}"
                            );
                        }
                        Console.ReadKey();
                        break;
                }
            }







            // Variable pour contrôler la sortie du programme
            bool quitter = false;
            
            // Boucle principale du menu
            while (!quitter)
            {
                Console.Clear(); // Nettoie l’écran
                Console.WriteLine("=== GESTION DES RÉSERVATIONS ===");
                Console.WriteLine("1. Gérer les ressources");
                Console.WriteLine("2. Gérer les réservations");
                Console.WriteLine("0. Quitter");
                Console.Write("Choix : ");

                // Lecture du choix utilisateur
                string choix = Console.ReadLine();

                // Traitement du choix
                switch (choix)
                {
                    case "1":
                        // Appel du sous-menu Ressources
                       MenuRessources(ressourceService);
                        break;

                    case "2":
                        // Appel du sous-menu Réservations
                        //MenuReservations(reservationService);
                        break;

                    case "0":
                        // Quitter l’application
                        quitter = true;
                        break;

                    default:
                        // Cas d’un choix invalide
                        Console.WriteLine("Choix invalide !");
                        Console.WriteLine("Presser une touche pour continuer !");                    
                        Console.ReadKey();
                        break;
                }
            }


        }
    }
}