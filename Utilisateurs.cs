using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PPEProjet
{
    internal class Utilisateurs
    {

        private string prenom;
        private string nom;
        private string mdp;
        private string login;
        private int id;

        public Utilisateurs(string lePrenom, string leNom, string leMdp, string leLogin, int leId)
        {
            prenom = lePrenom;
            nom = leNom;
            mdp = leMdp;
            login = leLogin;
            id = leId;
        }

        public Utilisateurs() { }

        public Utilisateurs(string lePrenom, string leNom, string leMdp, string leLogin) {
        prenom = lePrenom;
        nom = leNom;
        mdp = leMdp;
        login=leLogin;
        }

        public string Prenom { get { return prenom; } set { prenom = value; } }

        public string Nom { get { return nom; } set { nom = value; } }

        public string Mdp { get { return mdp; } set { mdp = value; } }

        public string Login { get { return login; } set { login = value; } }

        public int Id { get { return id; } set { id = value; } }

        public void Delete()
        {
            string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=admin;Pwd='visualstudio';";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM utilisateurs WHERE id=?;";
                command.Parameters.AddWithValue("?", Id);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex) { }
        }

        public string Ajouter(string nom, string prenom, string login, string mdp, int niveau)
        {
            try
            {
                string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=admin;Pwd='visualstudio';";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT login FROM utilisateurs WHERE login=@login;";
                command.Parameters.AddWithValue("@login", login);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    connection.Close();
                    return "Un utilisateur avec cet identifiant existe déjà";
                }
                else
                {
                    reader.Close();
                    MySqlCommand insertion = connection.CreateCommand();
                    insertion.CommandText = "INSERT INTO utilisateurs (nom, prenom, login, mdp, niveau) VALUES (@nom, @prenom, @login, @mdp, @niveau);";
                    insertion.Parameters.AddWithValue("@nom", nom);
                    insertion.Parameters.AddWithValue("@prenom", prenom);
                    insertion.Parameters.AddWithValue("@login", login);
                    insertion.Parameters.AddWithValue("@mdp", Hashage.GenerateSHA256String(mdp).ToLower());
                    insertion.Parameters.AddWithValue("@niveau", niveau);
                    insertion.ExecuteNonQuery();
                    connection.Close();
                    return "L'utilisateur a été ajouté avec succès";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Modifier(string nom, string prenom, string login, string mdp, int niveau)
        {   
            try
            {   
               
                string connectionString = "Server=127.0.0.1;Database=bibliotheque;Uid=admin;Pwd='visualstudio';";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE utilisateurs set nom = @nom , prenom = @prenom , login = @login , mdp = @mdp , niveau = @niveau WHERE id = @id;";
                command.Parameters.AddWithValue("@nom", nom);
                command.Parameters.AddWithValue("@prenom", prenom);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@mdp", Hashage.GenerateSHA256String(mdp).ToLower());
                command.Parameters.AddWithValue("@niveau", niveau);
                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
                connection.Close();
                return "Modification effectuée";

            }
            catch(Exception ex) { return ex.ToString(); }
        }
    }
}
