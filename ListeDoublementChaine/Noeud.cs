using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeDoublementChaine
{
    // Classe representant un noeud dans une liste doublement chainee
    public class Noeud
    {
        // Valeur stockee dans le noeud
        public int Valeur { get; set; }

        // Reference au noeud precedent
        public Noeud? Precedent { get; set; }

        // Reference au noeud suivant
        public Noeud? Suivant { get; set; }

        // Indique si le noeud est libre (supprime)
        public bool EstLibre { get; set; }

        // Cree un nouveau noeud avec la valeur specifiee
        public Noeud(int valeur)
        {
            Valeur = valeur;
            Precedent = null;
            Suivant = null;
            EstLibre = false;
        }
    }
}

