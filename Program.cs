using MiniPojetCSarp_SMART_Coding.Models;
using MiniPojetCSarp_SMART_Coding.Services;
using System;


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
                    Console.WriteLine("Choix invalide.");
                    Pause();
                    break;
            }
        }
    }

    static void AfficherMenuPrincipal()
    {
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║        SYSTÈME DE GESTION DES RÉSERVATIONS       ║");
        Console.WriteLine("╠══════════════════════════════════════════════════╣");
        Console.WriteLine("║ 1 - Lister les ressources                        ║");
        Console.WriteLine("║ 2 - Créer une réservation                        ║");
        Console.WriteLine("║ 3 - Lister les réservations (Récapitulatif)      ║");
        Console.WriteLine("║ 0 - Quitter                                      ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
    }

    static void InitialiserDonnees(RessourceService service)
    {
        Responsable resp1 = new Responsable(1, "Marie Laurent", "marie.laurent@entreprise.com");
        Responsable resp2 = new Responsable(2, "Paul Martin", "paul.martin@entreprise.com");

        service.AjouterRessource(new Salle(1, "Salle de réunion A", resp1, "Poste 402", 20));
        service.AjouterRessource(new Chambre(2, "Chambre visiteurs", resp2, "Réception", 101, 2));
        service.AjouterRessource(new Equipement(3, "Projecteur Epson", resp1, "Dépôt B", "Vidéo"));
    }

    static void ListerRessources(RessourceService service)
    {
        Console.Clear();
        Console.WriteLine("========= LISTE DES RESSOURCES =========");
        foreach (var r in service.ListerRessources())
        {
            Console.WriteLine($"ID: {r.Id} | {r.GetTypeRessource().PadRight(10)} | Nom: {r.Nom}");
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
        string nom = Console.ReadLine();
        Console.Write("Email du client : ");
        string email = Console.ReadLine();
        Console.Write("Date (JJ/MM/AAAA) : ");
        DateTime.TryParse(Console.ReadLine(), out DateTime date);

        var reservation = new Reservation(
            revSvc.ListerReservations().Count + 1,
            res,
            new Client(new Random().Next(1, 1000), nom, email),
            date,
            Reservation.StatutReservation.Confirmee
        );

        if (revSvc.CreerReservation(reservation))
            Console.WriteLine("\nSuccès : Réservation confirmée !");
        else
            Console.WriteLine("\nErreur : La ressource est déjà prise à cette date.");

        Pause();
    }

    static void ListerReservationsInteractive(ReservationService service)
    {
        Console.Clear();
        var list = service.ListerReservations();
        if (!list.Any()) Console.WriteLine("Aucune réservation.");
        foreach (var r in list) AfficherDesignRecapitulatif(r);
        Pause();
    }

    static void AfficherDesignRecapitulatif(Reservation r)
    {
        Console.WriteLine("══════════════════════════════════════════════════════════");
        Console.WriteLine("                RÉCAPITULATIF DE RÉSERVATION              ");
        Console.WriteLine("══════════════════════════════════════════════════════════");
        Console.WriteLine("\nRessource");
        Console.WriteLine($"  Type      : {r.Ressource.GetTypeRessource()}");
        Console.WriteLine($"  Nom       : {r.Ressource.Nom} | Resp : {r.Ressource.Responsable.Nom}");
        Console.WriteLine($"  Contact   : {r.Ressource.Responsable.Email}");
        Console.WriteLine("\nClient");
        Console.WriteLine($"  Nom       : {r.ClientInterne.Nom}");
        Console.WriteLine($"  Email     : {r.ClientInterne.Email}");
        Console.WriteLine("\nRéservation");
        Console.WriteLine($"  Date      : {r.DateReservation:dd MMMM yyyy} | Statut : {r.Statut}");
        Console.WriteLine("\n══════════════════════════════════════════════════════════\n");
    }

    static void Pause() { Console.WriteLine("\nAppuyez sur une touche..."); Console.ReadKey(); }
}
}