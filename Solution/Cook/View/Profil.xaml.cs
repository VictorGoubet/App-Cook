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
            PrenomTxtBx_Profil.Text = MainWindow.sessionCourante.Prenom;
            PswrdTxtBx_Profil.Password = MainWindow.sessionCourante.Mdp;
            IdTxtBx_Profil.Text = MainWindow.sessionCourante.Pseudo;
            AdrMailTxtBx_Profil.Text = MainWindow.sessionCourante.AdresseMail;
            AdrTxtBx_Profil.Text = MainWindow.sessionCourante.Adresse;
            NumTelTxtBx_Profil.Text = MainWindow.sessionCourante.NumerTel;

            if (MainWindow.sessionCourante.Sexe == "M")
            {
                RadioF_Profil.IsChecked = false;
                RadioM_Profil.IsChecked = true;
            }
            else
            {
                RadioF_Profil.IsChecked = true;
                RadioM_Profil.IsChecked = false;

            }

            if (MainWindow.sessionCourante.Cdr)
            {
                solde.Text = MainWindow.sessionCourante.Solde.ToString()+" Cooks";
                solde.Visibility = Visibility.Visible;
                CdrN_Profil.IsChecked = false;
                CdrY_Profil.IsChecked = true;

            }
            else
            {
                solde.Visibility = Visibility.Hidden;
                CdrN_Profil.IsChecked = true;
                CdrY_Profil.IsChecked = false;
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
             MainWindow.sessionCourante.Nom= NomTxtBx_Profil.Text;
             MainWindow.sessionCourante.Prenom= PrenomTxtBx_Profil.Text;
             MainWindow.sessionCourante.Mdp= PswrdTxtBx_Profil.Password;
             MainWindow.sessionCourante.Pseudo= IdTxtBx_Profil.Text;
             MainWindow.sessionCourante.AdresseMail= AdrMailTxtBx_Profil.Text;
             MainWindow.sessionCourante.Adresse= AdrTxtBx_Profil.Text;
             MainWindow.sessionCourante.NumerTel= NumTelTxtBx_Profil.Text;

            if (RadioF_Profil.IsChecked==true)
            {
                MainWindow.sessionCourante.Sexe = "F";
            }
            else
            {
                MainWindow.sessionCourante.Sexe = "M";

            }

            if (!MainWindow.sessionCourante.UpdateBdd())
            {
                MessageBox.Show("Erreure lors de la mise à jour des informations..");
            }




        }
    }
}
