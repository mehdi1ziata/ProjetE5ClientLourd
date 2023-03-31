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
    /// Logique d'interaction pour fenetreAdmin.xaml
    /// </summary>
    public partial class fenetreAdmin : Window
    {
        public fenetreAdmin()
        {
            InitializeComponent();
            string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=root;Pwd='';";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM utilisateurs;";
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            List<Utilisateurs> listUtilisateurs = new List<Utilisateurs>();
                            Utilisateurs utilisateur = new Utilisateurs(reader["prenom"].ToString(), reader["nom"].ToString(), reader["prenom"].ToString(), reader["prenom"].ToString());
                            listUtilisateurs.Add(utilisateur);
                            
                        }
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }   
        }

        public class Utilisateurs
        {
            private string prenom;
            private string nom;
            private string mdp;
            private string login;

            public Utilisateurs(string lePrenom, string leNom, string leMdp, string leLogin)
            {
                prenom = lePrenom;
                nom = leNom;
                mdp = leMdp;
                login = leLogin;
            }

            public string Prenom { get { return prenom; } set { prenom = value; } }

            public string Nom { get { return nom; } set { nom = value; } }

            public string Mdp { get { return mdp; } set { mdp = value; } }

            public string Login { get { return login; } set { login = value; } }

        }
    }
}

