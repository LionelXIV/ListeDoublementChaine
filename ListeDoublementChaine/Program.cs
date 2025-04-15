using System;

namespace ListeDoublementChaine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("     Liste Doublement Chainee");

            ListeDoublementChainee listeNormale = new ListeDoublementChainee();
            ListeAvecSentinelle listeSentinelle = new ListeAvecSentinelle();
            bool continuer = true;

            while (continuer)
            {
                AfficherMenuPrincipal();
                string? choix = Console.ReadLine();
                if (string.IsNullOrEmpty(choix))
                {
                    Console.WriteLine("Veuillez entrer un choix valide.");
                    continue;
                }

                switch (choix)
                {
                    case "1":
                        GererListeNormale(listeNormale);
                        break;

                    case "2":
                        GererListeSentinelle(listeSentinelle);
                        break;

                    case "3":
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("Desole, cette option n'existe pas. Veuillez reessayer.");
                        break;
                }
            }

            Console.WriteLine("\nMerci ");
        }

        static void AfficherMenuPrincipal()
        {
            Console.WriteLine("\nQue souhaitez-vous faire ?");
            Console.WriteLine("1. Gerer la liste normale");
            Console.WriteLine("2. Gerer la liste avec sentinelle");
            Console.WriteLine("3. Terminer le programme");
            Console.Write("Votre choix : ");
        }

        static void GererListeNormale(ListeDoublementChainee liste)
        {
            bool retour = false;
            while (!retour)
            {
                AfficherMenuListe("normale");
                string? choix = Console.ReadLine();
                if (string.IsNullOrEmpty(choix))
                {
                    Console.WriteLine("Veuillez entrer un choix valide.");
                    continue;
                }

                switch (choix)
                {
                    case "1":
                        AjouterValeur(liste);
                        break;

                    case "2":
                        SupprimerValeur(liste);
                        break;

                    case "3":
                        AfficherListe(liste);
                        break;

                    case "4":
                        CompacterListe(liste);
                        break;

                    case "5":
                        retour = true;
                        break;

                    default:
                        Console.WriteLine("Desole, cette option n'existe pas. Veuillez reessayer.");
                        break;
                }
            }
        }

        static void GererListeSentinelle(ListeAvecSentinelle liste)
        {
            bool retour = false;
            while (!retour)
            {
                AfficherMenuListe("avec sentinelle");
                string? choix = Console.ReadLine();
                if (string.IsNullOrEmpty(choix))
                {
                    Console.WriteLine("Veuillez entrer un choix valide.");
                    continue;
                }

                switch (choix)
                {
                    case "1":
                        AjouterValeurSentinelle(liste);
                        break;

                    case "2":
                        SupprimerValeurSentinelle(liste);
                        break;

                    case "3":
                        AfficherListeSentinelle(liste);
                        break;

                    case "4":
                        CompacterListeSentinelle(liste);
                        break;

                    case "5":
                        retour = true;
                        break;

                    default:
                        Console.WriteLine("Desole, cette option n'existe pas. Veuillez reessayer.");
                        break;
                }
            }
        }

        static void AfficherMenuListe(string typeListe)
        {
            Console.WriteLine($"\nMenu de la liste {typeListe}");
            Console.WriteLine("1. Ajouter une valeur");
            Console.WriteLine("2. Supprimer une valeur");
            Console.WriteLine("3. Afficher la liste");
            Console.WriteLine("4. Une compaction");
            Console.WriteLine("5. Retour au menu principal");
            Console.Write("Votre choix : ");
        }

        static void AjouterValeur(ListeDoublementChainee liste)
        {
            Console.Write("Entrez une valeur a ajouter : ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int valeur))
            {
                Console.WriteLine("Valeur invalide.");
                return;
            }

            liste.Ajouter(valeur);
            Console.WriteLine($"Valeur {valeur} ajoutee avec succes.");
        }

        static void AjouterValeurSentinelle(ListeAvecSentinelle liste)
        {
            Console.Write("Entrez une valeur a ajouter : ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int valeur))
            {
                Console.WriteLine("Valeur invalide.");
                return;
            }

            liste.Ajouter(valeur);
            Console.WriteLine($"Valeur {valeur} ajoutee avec succes.");
        }

        static void SupprimerValeur(ListeDoublementChainee liste)
        {
            Console.Write("Entrez une valeur a supprimer : ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int valeur))
            {
                Console.WriteLine("Valeur invalide.");
                return;
            }

            Noeud? noeud = liste.Trouver(valeur);
            if (noeud != null)
            {
                liste.Supprimer(noeud);
                Console.WriteLine($"Valeur {valeur} supprimee avec succes.");
            }
            else
            {
                Console.WriteLine("Valeur non trouvee.");
            }
        }

        static void SupprimerValeurSentinelle(ListeAvecSentinelle liste)
        {
            Console.Write("Entrez une valeur a supprimer : ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || !int.TryParse(input, out int valeur))
            {
                Console.WriteLine("Valeur invalide.");
                return;
            }

            Noeud? noeud = liste.Trouver(valeur);
            if (noeud != null)
            {
                liste.Supprimer(noeud);
                Console.WriteLine($"Valeur {valeur} supprimee avec succes.");
            }
            else
            {
                Console.WriteLine("Valeur non trouvee.");
            }
        }

        static void AfficherListe(ListeDoublementChainee liste)
        {
            Console.WriteLine("\nVoici le contenu de votre liste :");

            bool listeVide = true;
            foreach (int val in liste)
            {
                Console.Write($"{val} ");
                listeVide = false;
            }

            if (listeVide)
            {
                Console.WriteLine("La liste est vide pour le moment.");
            }
            Console.WriteLine();
        }

        static void AfficherListeSentinelle(ListeAvecSentinelle liste)
        {
            Console.WriteLine("\nVoici le contenu de votre liste :");

            bool listeVide = true;
            foreach (int val in liste)
            {
                Console.Write($"{val} ");
                listeVide = false;
            }

            if (listeVide)
            {
                Console.WriteLine("La liste est vide pour le moment.");
            }
            Console.WriteLine();
        }

        static void CompacterListe(ListeDoublementChainee liste)
        {
            liste.Compacter();
            Console.WriteLine("La liste a ete nettoyee avec succes !");
        }

        static void CompacterListeSentinelle(ListeAvecSentinelle liste)
        {
            liste.Compacter();
            Console.WriteLine("La liste a ete nettoyee avec succes !");
        }
    }
}