using System;
using System.Collections;
using System.Collections.Generic;

namespace ListeDoublementChaine
{
    // Liste doublement chainee avec gestion des noeuds libres
    public class ListeDoublementChainee : IEnumerable<int>
    {
        private Noeud? debut;  // Premier noeud de la liste
        private Noeud? fin; // Dernier noeud de la liste

        public ListeDoublementChainee()
        {
            debut = null;
            fin = null;
        }

        // Ajoute une valeur a la fin de la liste
        public void Ajouter(int valeur)
        {
            Noeud? noeudLibre = TrouverNoeudLibre();
            if (noeudLibre != null)
            {
                noeudLibre.Valeur = valeur;
                noeudLibre.EstLibre = false;
            }
            else
            {
                Noeud nouveau = new Noeud(valeur);
                if (fin != null)
                {
                    fin.Suivant = nouveau;
                    nouveau.Precedent = fin;
                    fin = nouveau;
                }
                else
                {
                    debut = nouveau;
                    fin = nouveau;
                }
            }
        }

        // Trouve le premier noeud contenant la valeur
        public Noeud? Trouver(int valeur)
        {
            Noeud? courant = debut;
            while (courant != null)
            {
                if (!courant.EstLibre && courant.Valeur == valeur)
                    return courant;
                courant = courant.Suivant;
            }
            return null;
        }

        // Marque un noeud comme libre
        public void Supprimer(Noeud noeud)
        {
            if (noeud == null)
                throw new ArgumentNullException(nameof(noeud));

            noeud.EstLibre = true;
        }

        // Supprime les noeuds libres de la liste
        public void Compacter()
        {
            Noeud? courant = debut;
            while (courant != null)
            {
                Noeud? suivant = courant.Suivant;
                if (courant.EstLibre)
                {
                    if (courant.Precedent != null)
                        courant.Precedent.Suivant = courant.Suivant;
                    else
                        debut = courant.Suivant;

                    if (courant.Suivant != null)
                        courant.Suivant.Precedent = courant.Precedent;
                    else
                        fin = courant.Precedent;
                }
                courant = suivant;
            }
        }

        // Trouve le premier noeud libre dans la liste
        private Noeud? TrouverNoeudLibre()
        {
            Noeud? courant = debut;
            while (courant != null)
            {
                if (courant.EstLibre)
                    return courant;
                courant = courant.Suivant;
            }
            return null;
        }

        // Implemente l'interface IEnumerable pour permettre l'iteration
        public IEnumerator<int> GetEnumerator()
        {
            Noeud? courant = debut;
            while (courant != null)
            {
                if (!courant.EstLibre)
                    yield return courant.Valeur;
                courant = courant.Suivant;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}