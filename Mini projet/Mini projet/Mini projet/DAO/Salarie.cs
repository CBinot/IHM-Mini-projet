using System;

namespace Mini_projet.DAO
{
    enum Sexe
    {
        M,
        F
    }

    enum SituationFamiliale
    {
        Celibataire,
        Marie,
        Separe,
        Divorce,
        Veuf
    }

    enum TypeContrat
    {
        CDI,
        CDD,
        Interim
    }

    class Salarie
    {
        // attributs
        private string matricule;
        private string nomSal;
        private string nomEpouseSal;
        private string prenom;
        private DateTime dateProcheConv1;
        private DateTime dateProcheConv2;
        private Sexe sexe;
        private SituationFamiliale situationFam;
        private string adrPerso;
        private TypeContrat typeContrat;
        private string posteOccupe;

        // clés étrangères
        private int codeCat; // Categorie
        private string noAdherent; // Adherent

        // ...

    }
}
