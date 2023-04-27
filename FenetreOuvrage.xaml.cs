using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace PPEProjet
{
    /// <summary>
    /// Logique d'interaction pour FenetreOuvrage.xaml
    /// </summary>
    public partial class FenetreOuvrage : Window

    {

        public fenetreOperateur fo;
        public FenetreOuvrage(fenetreOperateur unefenetre)
        {
            InitializeComponent();
            fo = unefenetre;
            Ouvrage monOuvrage = new Ouvrage();
            monOuvrage = (Ouvrage)fo.listOuvrage.SelectedItem;
            string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=admin;Pwd='visualstudio';";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT livres.idLivre, livres.titreLivre, editeurs.nomEditeur, illustrateurs.nomIllustrateur, illustrateurs.prenomIllustrateur, collection.libelleeCollection, auteurs.nomAuteur, auteurs.prenomAuteur FROM livres, auteurs, collection, editeurs, illustrateurs WHERE auteurs.idAuteur=livres.Auteur AND illustrateurs.idIllustrateur=livres.Illustrateur AND collection.idCollection=livres.Collection AND editeurs.idEditeur=livres.Editeur AND idLivre=@ISBN;";
                command.Parameters.AddWithValue("@ISBN", monOuvrage.Id);
                MySqlDataReader reader = command.ExecuteReader();
                TitreTextBox.Text= reader["titreLivre"].ToString();
                AuteurTextBox.Text = reader["nomAuteur"].ToString() + " " + reader["prenomAuteur"].ToString();
                IsbnTextBox.Text = reader["idLivre"].ToString();
                CollectionTextBox.Text = reader["libelleeCollection"].ToString();
                EditeurTextBox.Text = reader["nomEditeur"].ToString();
                IllustrateurTextBox.Text = reader["nomIllustrateur"] +" "+ reader["prenomIllustrateur"];
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
