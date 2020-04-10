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

namespace Cook.View
{
    /// <summary>
    /// Logique d'interaction pour ModelCDR.xaml
    /// </summary>
    public partial class ModelCDR : UserControl
    {
        string prenom;
        string nom;
        string numTel;
        string IdUser;
        string IdCDR;
        string Adresse;
        string AdrMail;
        int nbRecette;

        public ModelCDR(string prenom, string nom, string numTel, string idUser, string idCDR, string adresse, string adrMail, int nbRecette)
        {
            InitializeComponent();
            this.prenom = prenom;
            this.nom = nom;
            this.numTel = numTel;
            IdUser = idUser;
            IdCDR = idCDR;
            Adresse = adresse;
            AdrMail = adrMail;
            this.nbRecette = nbRecette;
        }


        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            //On supprime le cdr de la bdd
            //THOMAS

            //On actualise l'affichage :
            ((Application.Current.MainWindow.DataContext as AccueilGestionnaire).DataContext as DelCdr).UserControl_Loaded(sender, e);

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On va remplir le controle avec les données renseignées:
            this.Id_Cdr_del.Text = this.IdCDR;
            this.Id_User_del.Text = this.IdUser;

            this.Nom_Del.Text = this.nom;
            this.Prenom_Del.Text = this.prenom;

            this.numTel_del.Text = this.numTel;

            this.nb_del.Text =this.nbRecette.ToString()+" Recettes";

            this.Adr_del.Text = this.Adresse;
            this.AdrMail_del.Text = this.AdrMail;

        }
    }
}
