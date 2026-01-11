using MiniPojetCSarp_SMART_Coding.Models;
using MiniPojetCSarp_SMART_Coding.Services;
using System;
using System.Linq;

class Program
{
    private static RessourceService _resourceService = new RessourceService();
    private static ReservationService _reservationService = new ReservationService();

    static void Main()
    {
        bool quitter = false;
        while (!quitter)
        {
            Console.Clear();
            AfficherMenuPrincipal();
            Console.Write("Votre choix : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1": MenuRessources(); break;
                case "2": MenuReservations(); break;
                case "3": ListerReservationsInteractive(); break;
                case "0": quitter = true; break;
                default: Console.WriteLine("Choix invalide."); Pause(); break;
            }
        }
    }

    static void AfficherMenuPrincipal()
    {
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║     SYSTÈME DE GESTION DES RÉSERVATIONS       ║");
        Console.WriteLine("╠════════════════════════════════════════════════╣");
        Console.WriteLine("║ 1 - Gérer les ressources                        ║");
        Console.WriteLine("║ 2 - Gérer les réservations                      ║");
        Console.WriteLine("║ 3 - Lister les réservations                     ║");
        Console.WriteLine("║ 0 - Quitter                                    ║");
        Console.WriteLine("╚════════════════════════════════════════════════╝");
    }

    #region Menu Ressources
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

        switch (choix)
        {
            case "1": AjouterChambre(); break;
            case "2": AjouterSalle(); break;
            case "3": AjouterEquipement(); break;
            case "4": ListerRessources(); break;
        }
    }

    static void AjouterChambre()
    {
        int id = LireEntier("ID de la chambre : ");
        string nom = LireTexte("Nom de la chambre : ");
        int numero = LireEntier("Numéro de chambre : ");
        int lits = LireEntier("Nombre de lits : ");
        Responsable resp = CreerResponsable();

        var chambre = new Chambre(id, nom, resp, "N/A", numero, lits);
        _resourceService.AjouterRessource(chambre);
        Console.WriteLine("Chambre ajoutée !");
        Pause();
    }

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

    static void ListerRessources()
    {
        Console.Clear();
        Console.WriteLine("=== RESSOURCES ===");
        foreach (var r in _resourceService.ListerRessources())
        {
            var resp = r.Responsable;
            Console.WriteLine($"ID:{r.Id} | Type:{r.GetTypeRessource().PadRight(10)} | Nom:{r.Nom} | Resp:{resp?.Nom ?? "Non attribué"}");
        }
        Pause();
    }
    #endregion

    #region Menu Réservations
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

    static void CreerReservation()
    {
        int idRes = LireEntier("ID de la ressource : ");
        var res = _resourceService.ObtenirParId(idRes);
        if (res == null) { Console.WriteLine("Ressource non trouvée."); Pause(); return; }

        string nom = LireTexte("Nom du client : ");
        string email = LireTexte("Email : ");
        DateTime date = LireDate("Date (JJ/MM/AAAA) : ");

        if (!_reservationService.EstDisponible(res, date))
        {
            Console.WriteLine("Ressource déjà réservée à cette date."); Pause(); return;
        }

        var client = new Client(nom, email);
        var resv = new Reservation(_reservationService.ListerReservations().Count + 1, res, client, date, Reservation.StatutReservation.Confirmee);
        _reservationService.CreerReservation(resv);
        Console.WriteLine("Réservation confirmée !");
        Pause();
    }

    static void ListerReservationsInteractive()
    {
        Console.Clear();
        var list = _reservationService.ListerReservations();
        if (!list.Any()) { Console.WriteLine("Aucune réservation."); Pause(); return; }
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
    static Responsable CreerResponsable()
    {
        int id = LireEntier("ID Responsable : ");
        string nom = LireTexte("Nom : ");
        string email = LireTexte("Email : ");
        return new Responsable { Id = id, Nom = nom, Email = email };
    }

    static int LireEntier(string msg)
    {
        int val; while (true)
        {
            Console.Write(msg);
            if (int.TryParse(Console.ReadLine(), out val)) return val;
            Console.WriteLine("Entrée invalide.");
        }
    }

    static string LireTexte(string msg) { Console.Write(msg); return Console.ReadLine() ?? ""; }

    static DateTime LireDate(string msg)
    {
        DateTime val; while (true)
        {
            Console.Write(msg);
            if (DateTime.TryParse(Console.ReadLine(), out val)) return val;
            Console.WriteLine("Date invalide.");
        }
    }

    static void Pause() { Console.WriteLine("Appuyez sur une touche..."); Console.ReadKey(); }
    #endregion
}
