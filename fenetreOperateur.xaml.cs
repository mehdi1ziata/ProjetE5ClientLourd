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
using System.Collections.ObjectModel;

namespace PPEProjet
{
    /// <summary>
    /// Logique d'interaction pour fenetreOperateur.xaml
    /// </summary>
    public partial class fenetreOperateur : Window
    {
        public fenetreOperateur()
        {
            InitializeComponent();
            string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=admin;Pwd='visualstudio';";
            MySqlConnection connection = new MySqlConnection(connectionString);
            ObservableCollection<Ouvrage> listOuvrages = new ObservableCollection<Ouvrage>();

            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT livres.idLivre, livres.titreLivre, editeurs.nomEditeur, illustrateurs.nomIllustrateur, illustrateurs.prenomIllustrateur, collection.libelleeCollection, auteurs.nomAuteur, auteurs.prenomAuteur FROM livres, auteurs, collection, editeurs, illustrateurs WHERE auteurs.idAuteur=livres.Auteur AND illustrateurs.idIllustrateur=livres.Illustrateur AND collection.idCollection=livres.Collection AND editeurs.idEditeur=livres.Editeur ORDER BY livres.idLivre;";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read() && listOuvrages.Count < 30)
                {


                    Ouvrage ouvrage = new Ouvrage(int.Parse(reader["idLivre"].ToString()), reader["titreLivre"].ToString(), reader["nomEditeur"].ToString(), reader["nomIllustrateur"].ToString()+" "+reader["prenomIllustrateur"].ToString(), reader["libelleeCollection"].ToString(), reader["nomAuteur"].ToString()+" "+reader["prenomAuteur"]);
                    listOuvrages.Add(ouvrage);


                }
                listOuvrage.ItemsSource = listOuvrages;
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ouvrir_Click(object sender, RoutedEventArgs e)
        {
            
            FenetreOuvrage unefenetre = new FenetreOuvrage(this);
           /* if (listOuvrage.SelectedItem != null)
            {
                unefenetre.Show();
            }*/
        }
    }
}
