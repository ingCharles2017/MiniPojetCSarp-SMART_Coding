using MiniPojetCSarp_SMART_Coding.Models;
using MiniPojetCSarp_SMART_Coding.Services;
using System;
using System.Linq;

class Program
{
    private static RessourceService _resourceService = new RessourceService();
    private static ReservationService _reservationService = new ReservationService();

    static void Main(string[] args)
    {
        InitialiserDonnees(_resourceService);

        bool quitter = false;
        while (!quitter)
        {
            Console.Clear();
            AfficherMenuPrincipal();
            Console.Write("Votre choix : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1": ListerRessources(_resourceService); break;
                case "2": CreerReservationInteractive(_resourceService, _reservationService); break;
                case "3": ListerReservationsInteractive(_reservationService); break;
                case "0": quitter = true; break;
                default:
                    Console.WriteLine("Choix invalide."); Pause(); break;
            }
        }
    }

    static void AfficherMenuPrincipal()
    {
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║     SYSTÈME DE GESTION DES RÉSERVATIONS ║");
        Console.WriteLine("╠════════════════════════════════════════╣");
        Console.WriteLine("║ 1 - Lister les ressources              ║");
        Console.WriteLine("║ 2 - Créer une réservation              ║");
        Console.WriteLine("║ 3 - Lister les réservations            ║");
        Console.WriteLine("║ 0 - Quitter                            ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
    }

    static void InitialiserDonnees(RessourceService service)
    {
        // Création de responsables
        Responsable resp1 = new Responsable(1, "Marie Laurent", "marie.laurent@entreprise.com");
        Responsable resp2 = new Responsable(2, "Paul Martin", "paul.martin@entreprise.com");

        // Ajout de ressources
        service.AjouterRessource(new Salle(1, "Salle A", resp1, "Poste 402", 20));
        service.AjouterRessource(new Chambre(2, "Chambre visiteurs", null, "Réception", 101, 2)); // responsable non attribué
        service.AjouterRessource(new Equipement(3, "Projecteur Epson", resp1, "Dépôt B", "Vidéo"));
    }

    static void ListerRessources(RessourceService service)
    {
        Console.Clear();
        Console.WriteLine("========= LISTE DES RESSOURCES =========");
        foreach (var r in service.ListerRessources())
        {
            var resp = r.Responsable;
            Console.WriteLine($"ID: {r.Id} | {r.GetTypeRessource().PadRight(10)} | Nom: {r.Nom} | Resp: {(resp != null ? resp.Nom : "Non attribué")}");
        }
        Pause();
    }

    static void CreerReservationInteractive(RessourceService resSvc, ReservationService revSvc)
    {
        Console.Clear();
        Console.WriteLine("========= CRÉATION D'UNE RÉSERVATION =========");
        Console.Write("ID de la ressource : ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        var res = resSvc.ObtenirParId(id);
        if (res == null) { Console.WriteLine("Ressource non trouvée."); Pause(); return; }

        Console.Write("Nom du client : ");
        string nom = Console.ReadLine()!;
        Console.Write("Email du client : ");
        string email = Console.ReadLine()!;
        Console.Write("Date (JJ/MM/AAAA) : ");
        DateTime.TryParse(Console.ReadLine(), out DateTime date);

        if (!revSvc.EstDisponible(res, date))
        {
            Console.WriteLine("La ressource est déjà réservée à cette date.");
            Pause();
            return;
        }

        var client = new Client(nom, email);
        var reservation = new Reservation(revSvc.ListerReservations().Count + 1, res, client, date, Reservation.StatutReservation.Confirmee);

        revSvc.CreerReservation(reservation);
        Console.WriteLine("\nSuccès : Réservation confirmée !");
        Pause();
    }

    static void ListerReservationsInteractive(ReservationService service)
    {
        Console.Clear();
        var list = service.ListerReservations();
        if (!list.Any()) { Console.WriteLine("Aucune réservation."); Pause(); return; }
        foreach (var r in list) AfficherDesignRecapitulatif(r);
        Pause();
    }

    static void AfficherDesignRecapitulatif(Reservation r)
    {
        Console.WriteLine("══════════════════════════════════════════════════════════");
        Console.WriteLine("                RÉCAPITULATIF DE RÉSERVATION              ");
        Console.WriteLine("══════════════════════════════════════════════════════════");

        var resp = r.Ressource.Responsable;

        Console.WriteLine("\nRessource");
        Console.WriteLine($"  Type      : {r.Ressource.GetTypeRessource()}");
        Console.WriteLine($"  Nom       : {r.Ressource.Nom}");
        Console.WriteLine($"  Responsable : {(resp != null ? resp.Nom : "Non attribué")}");
        Console.WriteLine($"  Contact   : {(resp != null ? resp.Email : "N/A")}");

        Console.WriteLine("\nClient");
        Console.WriteLine($"  Nom       : {r.ClientInterne.Nom}");
        Console.WriteLine($"  Email     : {r.ClientInterne.Email}");

        Console.WriteLine("\nRéservation");
        Console.WriteLine($"  Date      : {r.DateReservation:dd MMMM yyyy}");
        Console.WriteLine($"  Statut    : {r.Statut}");
        Console.WriteLine("══════════════════════════════════════════════════════════\n");
    }

    static void Pause()
    {
        Console.WriteLine("\nAppuyez sur une touche...");
        Console.ReadKey();
    }
}
