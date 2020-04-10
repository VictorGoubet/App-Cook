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
    /// Logique d'interaction pour Commande.xaml
    /// </summary>
    public partial class Commande : UserControl
    {

        public static Commande PageCommande = null;
        DateTime dateCmd;
        public Commande()
        {
            InitializeComponent();
            PageCommande = this;
            this.dateCmd = new DateTime();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On  récupére la liste des produits uniques (unic) , leur quantité max/min/actuelle et leurs fournisseur :
            //THOMAS

            //Mise à jour des quantités max et min :
            //On récupére la date du dernier changement de la quantité actuelle (j'espere que c'est faisable en bdd) 
            //Si cela fait plus de 30 jour alors on divise Qmax et Qmin par 2 sinon on fait rien
            //A noter que la quantité actuelle on va dire que c'est le stock annuel ou alors faut rajouter un attribu quantité actuelle pcq il en a pas parlé
                //On met à jour la date de la dernière commande:
                //this.dateCmd = DateTime(date de la dernière modif);

            //On stock les données obtenues sous cette forme :

            //Liste des fournisseurs
            List<string> Liste_fournisseur = new List<string> { "SuperMarecher", "CremeIndustrie", "ButsherCop", "FeculeMine" };

            //Liste des prdt pour chaque fournisseur
            List<string> Liste_Prdt_Marecher = new List<string> { "Pomme de terre", "Oignons", "Carottes", "Choux" };
            List<string> Liste_Prdt_CremeIndustrie = new List<string> { "Reblochons", "Creme", "Beure" };
            List<string> Liste_Prdt_Butsher = new List<string> { "Poule", "Lardons" };
            List<string> Liste_Prdt_Fecule = new List<string> { "riz" };

            //Pour savoir la quantité commandée, on récupére la quantité max et actuelle de chaque produit et on fait la differrence
            //THOMAS

            //Liste des quantité pour chaque fournisseur dans le bon ordre ( quantité à l'index 3 correspond au produit à l'index 3 dans la liste des prdt)
            List<double> Liste_Qt_Marecher = new List<double> { 10, 2, 3, 1 };
            List<double> Liste_Qt_CremeIndustrie = new List<double> { 250, 20,50 };
            List<double> Liste_Qt_Butsher = new List<double> { 1, 200.5 };
            List<double> Liste_Qt_Fecule = new List<double> { 200 };

            //Liste des unités (pareil que pour quantité)
            List<string> Liste_Un_Marecher = new List<string> { "", "", "", "" };
            List<string> Liste_Un_CremeIndustrie = new List<string> { "g", "cl", "g" };
            List<string> Liste_Un_Butsher = new List<string> { "", "g" };
            List<string> Liste_Un_Fecule = new List<string> { "g" };

            //On stock chaque sous listes
            List<List<string>> Liste_Prdt = new List<List<string>> { Liste_Prdt_Marecher, Liste_Prdt_CremeIndustrie, Liste_Prdt_Butsher, Liste_Prdt_Fecule };
            List<List<double>> Liste_Qt = new List<List<double>> { Liste_Qt_Marecher, Liste_Qt_CremeIndustrie, Liste_Qt_Butsher, Liste_Qt_Fecule };
            List<List<string>> List_Un = new List<List<string>> { Liste_Un_Marecher, Liste_Un_CremeIndustrie, Liste_Un_Butsher, Liste_Un_Fecule };


            Pannel_Cmd.Children.Clear();
            //On créé le controle fournisseur et on l'affiche dans un scrollviewer:
            for (int k = 0; k < Liste_fournisseur.Count(); k++)
            {
                Fournisseur item = new Fournisseur(Liste_Prdt[k],Liste_fournisseur[k], Liste_Qt[k], List_Un[k]);
                item.Width = 600;
                item.Height = 300;
                item.Margin = new Thickness(0, 0, 0, 10);
                Pannel_Cmd.Children.Add(item);

            }
            this.date.Text = "Date de la dernière commande : " + this.dateCmd.ToShortDateString();

        }

        private void Btn_Send_Cmd_Click(object sender, RoutedEventArgs e)
        {

            //On Reaprovisionne les stocks (On ajoute les quantités calculées à la quantité de chaque produit ):
            //THOMAS

            
            //On actualise l'affichage :
            UserControl_Loaded(sender, e);

        }
    }
}
