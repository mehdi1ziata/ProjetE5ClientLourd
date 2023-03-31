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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace PPEProjet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=root;Pwd='';";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM utilisateurs WHERE login=@username";
                    command.Parameters.AddWithValue("@username", username);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hashedPassword = Hashage.GenerateSHA256String(password).ToLower();
                            if (hashedPassword == reader["mdp"].ToString())
                            {
                                MessageBox.Show("Connexion réussie !");
                                int niveauAdmin = 2;
                                if (niveauAdmin == int.Parse(reader["niveau"].ToString()))
                                {
                                    fenetreAdmin uneFenetreAdmin = new fenetreAdmin();
                                    uneFenetreAdmin.Show();
                                    uneFenetreAdmin.textBlockLabelAdmin.Content = uneFenetreAdmin.textBlockLabelAdmin.Content + " " + reader["prenom"];
                                }
                                else
                                {
                                    fenetreOperateur uneFenetreOperateur = new fenetreOperateur();
                                    uneFenetreOperateur.Show();
                                    uneFenetreOperateur.textBlockLabelOp.Text = uneFenetreOperateur.textBlockLabelOp.Text + " " + reader["prenom"];
                                }
                            }else MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !");
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
