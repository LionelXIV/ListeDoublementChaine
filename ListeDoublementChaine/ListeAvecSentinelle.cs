using System;
using System.Collections;
using System.Collections.Generic;

namespace ListeDoublementChaine
{
    // Liste doublement chainee utilisant un noeud sentinelle
    public class ListeAvecSentinelle : IEnumerable<int>
    {
        private readonly Noeud sentinelle;  // Noeud special marquant le debut et la fin de la liste

        public ListeAvecSentinelle()
        {
            sentinelle = new Noeud(0);
            sentinelle.Precedent = sentinelle;
            sentinelle.Suivant = sentinelle;
        }

        // Ajoute une valeur a la fin de la liste
        public void Ajouter(int valeur)
        {
            if (sentinelle.Precedent == null || sentinelle.Suivant == null)
                throw new InvalidOperationException("La sentinelle n'est pas correctement initialisee");

            Noeud nouveau = new Noeud(valeur);
            nouveau.Precedent = sentinelle.Precedent;
            nouveau.Suivant = sentinelle;
            sentinelle.Precedent.Suivant = nouveau;
            sentinelle.Precedent = nouveau;
        }

        // Trouve le premier noeud contenant la valeur
        public Noeud? Trouver(int valeur)
        {
            if (sentinelle.Suivant == null)
                throw new InvalidOperationException("La sentinelle n'est pas correctement initialisee");

            Noeud courant = sentinelle.Suivant;
            while (courant != sentinelle)
            {
                if (courant.Valeur == valeur)
                    return courant;
                if (courant.Suivant == null)
                    throw new InvalidOperationException("La liste est corrompue");
                courant = courant.Suivant;
            }
            return null;
        }

        // Marque un noeud comme libre
        public void Supprimer(Noeud noeud)
        {
            if (noeud == null)
                throw new ArgumentNullException(nameof(noeud));
            if (noeud == sentinelle)
                throw new ArgumentException("Impossible de supprimer la sentinelle", nameof(noeud));

            noeud.EstLibre = true;
        }

        // Supprime les noeuds libres de la liste
        public void Compacter()
        {
            if (sentinelle.Suivant == null)
                throw new InvalidOperationException("La sentinelle n'est pas correctement initialisee");

            Noeud courant = sentinelle.Suivant;
            while (courant != sentinelle)
            {
                if (courant.Suivant == null)
                    throw new InvalidOperationException("La liste est corrompue");

                Noeud suivant = courant.Suivant;
                if (courant.EstLibre)
                {
                    if (courant.Precedent == null || courant.Suivant == null)
                        throw new InvalidOperationException("La liste est corrompue");

                    courant.Precedent.Suivant = courant.Suivant;
                    courant.Suivant.Precedent = courant.Precedent;
                }
                courant = suivant;
            }
        }

        // Retourne un iterateur sur les valeurs des noeuds non libres
        public IEnumerator<int> GetEnumerator()
        {
            if (sentinelle.Suivant == null)
                throw new InvalidOperationException("La sentinelle n'est pas correctement initialisee");

            Noeud courant = sentinelle.Suivant;
            while (courant != sentinelle)
            {
                if (!courant.EstLibre)
                    yield return courant.Valeur;
                if (courant.Suivant == null)
                    throw new InvalidOperationException("La liste est corrompue");
                courant = courant.Suivant;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}