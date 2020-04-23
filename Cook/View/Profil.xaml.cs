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
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : UserControl
    {
        public Profil()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            //THOMAS


            //On remplit chaque champs avec les données de la session courante : 
            NomTxtBx_Profil.Text = MainWindow.sessionCourante.Nom;


            //ATTENTION : si c'est un cdr on rajoute le compteur de cook:

            bool cdr = true;
            if (cdr)
            {
                solde.Visibility = Visibility.Visible;
            }
            else
            {
                solde.Visibility = Visibility.Hidden;
            }

            //Ensuite on bloque la modification de tout les champs:
            SetEnable(false);
        }

        public void SetEnable(bool x)
        {
            IdTxtBx_Profil.IsEnabled = x;
            AdrMailTxtBx_Profil.IsEnabled = x;
            AdrTxtBx_Profil.IsEnabled = x;
            NumTelTxtBx_Profil.IsEnabled = x;
            NomTxtBx_Profil.IsEnabled = x;
            PrenomTxtBx_Profil.IsEnabled = x;
            IdTxtBx_Profil.IsEnabled = x;
            CdrN_Profil.IsEnabled = x;
            CdrY_Profil.IsEnabled = x;
            RadioF_Profil.IsEnabled = x;
            RadioM_Profil.IsEnabled = x;
            PswrdTxtBx_Profil.IsEnabled = x;

            Btn_Edit.IsEnabled = !x;
            Btn_Valid_Edit.IsEnabled = x;

            if (x)
            {
                
                Btn_Valid_Edit.Visibility = Visibility.Visible;
                Btn_Edit.Visibility = Visibility.Hidden;
            }
            else
            {
                Btn_Valid_Edit.Visibility = Visibility.Hidden;
                Btn_Edit.Visibility = Visibility.Visible;
            }

        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            //On débloque tout le champs
            SetEnable(true);
        }

        private void Btn_Valid_Edit_Click(object sender, RoutedEventArgs e)
        {
            //On rebloque tout les champs
            SetEnable(false);

            //Puis on emet à jour les données de l'utilisateur avec les données modifiées:
            //THOMAS

        }
    }
}
