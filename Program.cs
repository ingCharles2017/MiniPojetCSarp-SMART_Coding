using MiniPojetCSarp_SMART_Coding.Models;
using MiniPojetCSarp_SMART_Coding.Services;
using System;
using System.Linq;

/*
 * Classe principale du programme.
 * Elle contient le point d’entrée Main et gère les menus de l’application.
 */
class Program

namespace MiniPojetCSarp_SMART_Coding
>>>>>>> Charles-Program
{
    // Service qui gère les ressources (chambres, salles, équipements)
    private static RessourceService _resourceService = new RessourceService();

    // Service qui gère les réservations
    private static ReservationService _reservationService = new ReservationService();

    /*
     * Point d’entrée du programme.
     * Affiche le menu principal et boucle tant que l'utilisateur ne quitte pas.
     */
    static void Main()
    {
<<<<<<< HEAD
        bool quitter = false;

        // Boucle principale du programme
        while (!quitter)
        {
            Console.Clear();                 // Nettoie la console
            AfficherMenuPrincipal();         // Affiche le menu principal
            Console.Write("Votre choix : ");
            string choix = Console.ReadLine();

            // Gestion du choix utilisateur
            switch (choix)
            {
                case "1": MenuRessources(); break;
                case "2": MenuReservations(); break;
                case "3": ListerReservationsInteractive(); break;
                case "0": quitter = true; break;   // Quitte le programme
                default:
                    Console.WriteLine("Choix invalide.");
                    Pause();
                    break;
            }
=======


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


>>>>>>> Charles-Program
        }
    }

    /*
     * Affiche le menu principal de l'application.
     */
    static void AfficherMenuPrincipal()
    {
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║     SYSTÈME DE GESTION DES RÉSERVATIONS        ║");
        Console.WriteLine("╠════════════════════════════════════════════════╣");
        Console.WriteLine("║ 1 - Gérer les ressources                       ║");
        Console.WriteLine("║ 2 - Gérer les réservations                     ║");
        Console.WriteLine("║ 3 - Lister les réservations                    ║");
        Console.WriteLine("║ 0 - Quitter                                    ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");
    }

    #region Menu Ressources

    /*
     * Menu permettant de gérer les ressources :
     * - Chambres
     * - Salles
     * - Équipements
     */
    static void MenuRessources()
    {
        Console.Clear();
        Console.WriteLine("--- GESTION DES RESSOURCES ---");
        Console.WriteLine("1 - Ajouter une chambre");
        Console.WriteLine("2 - Ajouter une salle");
        Console.WriteLine("3 - Ajouter un équipement");
        Console.WriteLine("4 - Lister les ressources");
        Console.WriteLine("0 - Retour");
        Console.Write("Choix : ");
        string choix = Console.ReadLine();

        // Redirige selon le choix
        switch (choix)
        {
            case "1": AjouterChambre(); break;
            case "2": AjouterSalle(); break;
            case "3": AjouterEquipement(); break;
            case "4": ListerRessources(); break;
        }
    }

    /*
     * Permet de créer une chambre et de l'ajouter au service.
     */
    static void AjouterChambre()
    {
        int id = LireEntier("ID de la chambre : ");
        string nom = LireTexte("Nom de la chambre : ");
        int numero = LireEntier("Numéro de chambre : ");
        int lits = LireEntier("Nombre de lits : ");
        Responsable resp = CreerResponsable();

        // Création de l'objet Chambre
        var chambre = new Chambre(id, nom, resp, "N/A", numero, lits);

        // Ajout dans le service des ressources
        _resourceService.AjouterRessource(chambre);

        Console.WriteLine("Chambre ajoutée !");
        Pause();
    }

    /*
     * Permet de créer une salle.
     */
    static void AjouterSalle()
    {
        int id = LireEntier("ID de la salle : ");
        string nom = LireTexte("Nom de la salle : ");
        int capacite = LireEntier("Capacité : ");
        Responsable resp = CreerResponsable();

        var salle = new Salle(id, nom, resp, "N/A", capacite);
        _resourceService.AjouterRessource(salle);

        Console.WriteLine("Salle ajoutée !");
        Pause();
    }

    /*
     * Permet de créer un équipement.
     */
    static void AjouterEquipement()
    {
        int id = LireEntier("ID de l'équipement : ");
        string nom = LireTexte("Nom : ");
        string cat = LireTexte("Catégorie : ");
        Responsable resp = CreerResponsable();

        var equip = new Equipement(id, nom, resp, "N/A", cat);
        _resourceService.AjouterRessource(equip);

        Console.WriteLine("Équipement ajouté !");
        Pause();
    }

    /*
     * Affiche toutes les ressources enregistrées.
     */
    static void ListerRessources()
    {
        Console.Clear();
        Console.WriteLine("=== RESSOURCES ===");

        foreach (var r in _resourceService.ListerRessources())
        {
            var resp = r.Responsable;

            Console.WriteLine(
                $"ID:{r.Id} | " +
                $"Type:{r.GetTypeRessource().PadRight(10)} | " +
                $"Nom:{r.Nom} | " +
                $"Resp:{resp?.Nom ?? "Non attribué"}"
            );
        }
        Pause();
    }

    #endregion

    #region Menu Réservations

    /*
     * Menu de gestion des réservations.
     */
    static void MenuReservations()
    {
        Console.Clear();
        Console.WriteLine("--- GESTION DES RÉSERVATIONS ---");
        Console.WriteLine("1 - Créer une réservation");
        Console.WriteLine("0 - Retour");
        Console.Write("Choix : ");

        string choix = Console.ReadLine();
        if (choix == "1") CreerReservation();
    }

    /*
     * Crée une nouvelle réservation pour une ressource.
     */
    static void CreerReservation()
    {
        int idRes = LireEntier("ID de la ressource : ");
        var res = _resourceService.ObtenirParId(idRes);

        // Vérifie si la ressource existe
        if (res == null)
        {
            Console.WriteLine("Ressource non trouvée.");
            Pause();
            return;
        }

        string nom = LireTexte("Nom du client : ");
        string email = LireTexte("Email : ");
        DateTime date = LireDate("Date (JJ/MM/AAAA) : ");

        // Vérifie si la ressource est disponible
        if (!_reservationService.EstDisponible(res, date))
        {
            Console.WriteLine("Ressource déjà réservée à cette date.");
            Pause();
            return;
        }

        // Création du client et de la réservation
        var client = new Client(nom, email);
        var resv = new Reservation(
            _reservationService.ListerReservations().Count + 1,
            res,
            client,
            date,
            Reservation.StatutReservation.Confirmee
        );

        _reservationService.CreerReservation(resv);

        Console.WriteLine("Réservation confirmée !");
        Pause();
    }

    /*
     * Affiche toutes les réservations existantes.
     */
    static void ListerReservationsInteractive()
    {
        Console.Clear();
        var list = _reservationService.ListerReservations();

        if (!list.Any())
        {
            Console.WriteLine("Aucune réservation.");
            Pause();
            return;
        }

        foreach (var r in list)
        {
            var resp = r.Ressource.Responsable;

            Console.WriteLine("════════════════════════════════════════");
            Console.WriteLine($"Ressource : {r.Ressource.Nom} ({r.Ressource.GetTypeRessource()})");
            Console.WriteLine($"Responsable : {resp?.Nom ?? "N/A"} / Email : {resp?.Email ?? "N/A"}");
            Console.WriteLine($"Client : {r.ClientInterne.Nom} ({r.ClientInterne.Email})");
            Console.WriteLine($"Date : {r.DateReservation:dd/MM/yyyy} | Statut : {r.Statut}");
            Console.WriteLine("════════════════════════════════════════");
        }
        Pause();
    }

    #endregion

    #region Utilitaires

    /*
     * Crée un responsable à partir des informations saisies.
     */
    static Responsable CreerResponsable()
    {
        int id = LireEntier("ID Responsable : ");
        string nom = LireTexte("Nom : ");
        string email = LireTexte("Email : ");

        return new Responsable { Id = id, Nom = nom, Email = email };
    }

    /*
     * Lit un entier sécurisé depuis la console.
     * Tant que la saisie n'est pas valide, on redemande.
     */
    static int LireEntier(string msg)
    {
        int val;
        while (true)
        {
            Console.Write(msg);
            if (int.TryParse(Console.ReadLine(), out val))
                return val;

            Console.WriteLine("Entrée invalide.");
        }
    }

    /*
     * Lit un texte depuis la console.
     */
    static string LireTexte(string msg)
    {
        Console.Write(msg);
        return Console.ReadLine() ?? "";
    }

    /*
     * Lit une date valide depuis la console.
     */
    static DateTime LireDate(string msg)
    {
        DateTime val;
        while (true)
        {
            Console.Write(msg);
            if (DateTime.TryParse(Console.ReadLine(), out val))
                return val;

            Console.WriteLine("Date invalide.");
        }
    }

    /*
     * Met le programme en pause jusqu'à ce que l'utilisateur appuie sur une touche.
     */
    static void Pause()
    {
        Console.WriteLine("Appuyez sur une touche...");
        Console.ReadKey();
    }

    #endregion
}
