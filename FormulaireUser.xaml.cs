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
    /// Logique d'interaction pour FormulaireUser.xaml
    /// </summary>
    public partial class FormulaireUser : Window
    {
        public fenetreAdmin faMere;
        public FormulaireUser(fenetreAdmin fa)
        {
            InitializeComponent();
            faMere = fa;
        }

        private void btnInscription_Click(object sender, RoutedEventArgs e)
        {   
            if (faMere.listUser.SelectedItem != null)
            {
                Utilisateurs monUser = new Utilisateurs();
                monUser = (Utilisateurs)faMere.listUser.SelectedItem;
                try
                {
                    MessageBox.Show((monUser.Modifier(txtNom.Text, txtPrenom.Text, txtLogin.Text, txtPassword.Password, int.Parse(comboboxNiveau.Text))));

                }
                catch (Exception ex) {MessageBox.Show(ex.ToString()); }
            }
            else
            {
                Utilisateurs unUser = new Utilisateurs();
                MessageBox.Show(unUser.Ajouter(txtNom.Text, txtPrenom.Text, txtLogin.Text, txtPassword.Password, int.Parse(comboboxNiveau.Text)));
            }
        }

        
    }
}
