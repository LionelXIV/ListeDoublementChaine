Projet Liste Doublement Chainee

Systeme utilise :
- Windows 11
- Visual Studio 2022
- .NET 6.0

Ce projet implemente deux types de listes doublement chainees en C# :
1. Une liste doublement chainee classique
2. Une liste doublement chainee utilisant un noeud sentinelle

Structure du projet :
- Noeud.cs : Classe representant un noeud de la liste
- ListeDoublementChainee.cs : Implementation de la liste classique
- ListeAvecSentinelle.cs : Implementation de la liste avec sentinelle
- Program.cs : Interface utilisateur pour tester les deux types de listes

Fonctionnalites :
- Ajout de valeurs
- Suppression de valeurs
- Affichage de la liste
- Compaction de la liste (suppression physique des noeuds marques comme libres)

Pour tester le programme :
1. Compiler et executer le projet
2. Choisir le type de liste a tester (normale ou avec sentinelle)
3. Utiliser les options du menu pour :
   - Ajouter des valeurs
   - Supprimer des valeurs
   - Afficher la liste
   - Compacter la liste
   - Retourner au menu principal

La liste avec sentinelle utilise un noeud special qui marque le debut et la fin de la liste, ce qui simplifie certaines operations.