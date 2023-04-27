using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PPEProjet
{
    internal class Ouvrage
    {
        private string collection;
        private string editeur;
        private string auteur;
        private string titre;
        private int id;
        private string illustrateur;

        public Ouvrage(int unid, string untitre, string unediteur, string unillustrateur, string unecollection, string unauteur) { 

            id = unid;
            collection = unecollection;
            titre = untitre;
            editeur = unediteur;
            auteur = unauteur;
            illustrateur = unillustrateur;
        }

        public Ouvrage() { }

        public int Id {get {return id;} set { id = value; } }
        public string Collection { get { return collection; } set { collection = value; } }
        public string Auteur{ get { return auteur ; } set { auteur = value; } }

        public string Illustrateur { get { return illustrateur; } set { illustrateur = value; } }

        public string Titre { get { return titre; } set { titre = value; } }

        public string Editeur { get { return editeur; } set { editeur = value; } }












    }
}
