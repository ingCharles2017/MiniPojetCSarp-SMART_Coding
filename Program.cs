using System;
using System.Transactions;
using Reservation.Models;
using RessourceService.Services;


namespace GestionReservations
{
    class Program
    {

        static void Main(string[] Args)
        {

            ResourceService resourceService = new ResourceService();
            ReservationService reservationService = new ReservationService();

            InitialiserDonnees(resourceService);

            bool quitter = false;

            while (!quitter)
            {
                Console.Clear();
                AfficherMenuPrincipal();
                Console.Write("Votre choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        ListerRessources(resourceService);
                        break;

                    case "2":
                        CreerReservation(resourceService, reservationService);
                        break;

                    case "3":
                        ListerReservations(reservationService);
                        break;

                    case "0":
                        quitter = true;
                        break;

                    default:
                        Console.WriteLine("Choix invalide.");
                        Pause();
                        break;
                }
            }
        }

    }
    


}

