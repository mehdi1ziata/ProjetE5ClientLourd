using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour fenetreAdmin.xaml
    /// </summary>
    public partial class fenetreAdmin : Window
    {
        public fenetreAdmin()
        {
            InitializeComponent();
            string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=admin;Pwd='visualstudio';";
            MySqlConnection connection = new MySqlConnection(connectionString);
            ObservableCollection<Utilisateurs> listUtilisateurs = new ObservableCollection<Utilisateurs>();

            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM utilisateurs;";
                MySqlDataReader reader = command.ExecuteReader();
         
                while (reader.Read())
                {


                    Utilisateurs utilisateur = new Utilisateurs(reader["prenom"].ToString(), reader["nom"].ToString(), reader["mdp"].ToString(), reader["login"].ToString(), int.Parse(reader["id"].ToString()));
                    listUtilisateurs.Add(utilisateur);


                }
                listUser.ItemsSource = listUtilisateurs;
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (listUser.SelectedItem != null)
            { 
                Utilisateurs monUser = new Utilisateurs();
                monUser=(Utilisateurs)listUser.SelectedItem;
                try
                {
                    monUser.Delete();
                    listUser.Items.Remove((Utilisateurs)listUser.SelectedItem);
                }
                catch (Exception ex) { }
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            FormulaireUser formulaireUser = new FormulaireUser(this);
            formulaireUser.Show();
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=admin;Pwd='visualstudio';";
            MySqlConnection connection = new MySqlConnection(connectionString);
            ObservableCollection<Utilisateurs> listUtilisateurs = new ObservableCollection<Utilisateurs>();

            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM utilisateurs;";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {


                    Utilisateurs utilisateur = new Utilisateurs(reader["prenom"].ToString(), reader["nom"].ToString(), reader["mdp"].ToString(), reader["login"].ToString(), int.Parse(reader["id"].ToString()));
                    listUtilisateurs.Add(utilisateur);


                }
                listUser.ItemsSource = listUtilisateurs;
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {

            FormulaireUser formulaireUser = new FormulaireUser(this);
            formulaireUser.Show();
            
        }
    }
}

