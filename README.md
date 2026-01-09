# MiniPojetCSarp-SMART_Coding

## Description
Application console C# permettant la gestion de ressources partagées 
(salles, chambres et équipements) ainsi que leurs réservations au sein 
d’une organisation.

Ce projet a été réalisé dans le cadre du mini-projet de Programmation 
Orientée Objet en C#.

---

## Objectifs
- Gérer les ressources (ajout, consultation)
- Créer et consulter des réservations
- Proposer un affichage clair et structuré en console
- Appliquer les concepts fondamentaux de la Programmation Orientée Objet

---

## Modélisation
Le système repose sur :
- Une classe abstraite `Ressource`
- Des spécialisations : `Salle`, `Chambre`, `Equipement`
- Une classe `Reservation` reliant une ressource et un client interne
- Des services dédiés à la gestion métier

---

## Structure du projet

GestionReservations
├── Program.cs
│
├── Models
│ ├── Client.cs
│ ├── Ressource.cs
| |── Responsable.cs
│ ├── Salle.cs
│ ├── Chambre.cs
│ ├── Equipement.cs
│ └── Reservation.cs
│
├── Services
│ ├── ResourceService.cs
│ └── ReservationService.cs






