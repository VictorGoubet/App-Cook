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


namespace Cook.View
{
    /// <summary>
    /// Logique d'interaction pour Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void DisplayChoice(object sender, RoutedEventArgs e)
        {
            ///On retourne en arrière en affichant la page des choix Login/Register
            Application.Current.MainWindow.DataContext = Choice.vChoice;
        }

        private void Btn_SubRegis_Click(object sender, RoutedEventArgs e)
        {
            /// On verifie que tout les champs sont remplis
            if (NomTxtBx.Text != "" && PrenomTxtBx.Text != "" && AdrMailTxtBx.Text != "" && NumTelTxtBx.Text != "")
            {
                string s = "F";
                if(RadioM.IsChecked == true)
                {
                    s = "M";
                }
                

                //On ajoute la personne comme utilisateur à la bdd afin de pouvoir se connecter et également comme cuisto ou utilisateur de l'appli:
                //THOMAS

                ///Une fois connecté on affiche l'accueil

                //Pour cela on distingue les affichage selon le type d'utilisateur:

                ///En réalité ici il faut comparer le type d'utilisateur et non pas les id:
                //THOMAS
                if (IdTxtBx.Text == "root")
                {
                    Application.Current.MainWindow.DataContext = new AccueilGestionnaire();
                }
                else if (CdrY.IsChecked==true)
                {
                    Application.Current.MainWindow.DataContext = new Accueil(1);
                }
                else
                {
                    Application.Current.MainWindow.DataContext = new Accueil(0);
                }

            }

        }


        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            //Permet de valider le register par la simple touche entrée
            if (e.Key == Key.Enter)
            {
                Btn_SubRegis_Click(sender, e);
            }
        }
    }
}
