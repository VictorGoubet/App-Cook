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
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    /// 
    
    public partial class Panier : UserControl
    {
        public static Panier PagePanier = null;

        public Panier()
        {
            InitializeComponent();
            PagePanier = this;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Rechercher.PageRechercher.titres != null && Rechercher.PageRechercher.titres.Count() > 0)
            {
                AffichageRecap(Rechercher.PageRechercher.titres, Rechercher.PageRechercher.prixs, Rechercher.PageRechercher.qts, Rechercher.PageRechercher.urls);
            }

        }

        private void AffichageRecap(List<string> TitleListe, List<double> PrixListe,List<int> QtListe,List<string> UrlListe)
        {
            Stck_Rcp.Children.Clear();

            double tt = 0;
            //On va creer et remplir tout les récap d'achat de recette que l'on a fait :
            for (int k = 0; k < TitleListe.Count(); k++)
            {

                
                MdlRecap item = new MdlRecap(TitleListe[k], PrixListe[k], QtListe[k], UrlListe[k]);
                item.Width = 500;
                item.Height = 50;
                item.Margin = new Thickness(0,0,0,5);

                Stck_Rcp.Children.Add(item);
                tt += QtListe[k] * PrixListe[k];




            }
            //on affiche le prix total:
            PrxTT.Text = "Total : " + tt.ToString()+" Ck";

        }

        

        public void Btn_DelPanier_Click(object sender, RoutedEventArgs e)
        {
            //On annule le panier :

            Stck_Rcp.Children.Clear();
            Rechercher.PageRechercher.titres.Clear();
            Rechercher.PageRechercher.prixs.Clear();
            Rechercher.PageRechercher.qts.Clear();
            Rechercher.PageRechercher.urls.Clear();
            PrxTT.Text = "Total : 0 Ck";

        }

        private void Btn_ValPanier_Click(object sender, RoutedEventArgs e)
        {

            //On prend en compte la commande: (régles detaillé dans le sujet → augmentation du prix etc )
            //THOMAS

            //On supprime le panier :
            Btn_DelPanier_Click(sender, e);
        }
    }
}
