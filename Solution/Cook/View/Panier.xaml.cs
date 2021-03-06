﻿using MySql.Data.MySqlClient;
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
        double prixTotal;

        public Panier()
        {   

            InitializeComponent();
            prixTotal = 0;
            PagePanier = this;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                if (Rechercher.PageRechercher.titres != null && Rechercher.PageRechercher.titres.Count() > 0)
                {
                    AffichageRecap(Rechercher.PageRechercher.titres, Rechercher.PageRechercher.prixs, Rechercher.PageRechercher.qts, Rechercher.PageRechercher.urls);
                }

            }
            catch
            {
                MessageBox.Show("Erreure lors du chargement de la page");
            }
            

        }

        private void AffichageRecap(List<string> TitleListe, List<double> PrixListe,List<int> QtListe,List<string> UrlListe)
        {
            Stck_Rcp.Children.Clear();
            prixTotal = 0;

            
            //On va creer et remplir tout les récap d'achat de recette que l'on a fait :
            for (int k = 0; k < TitleListe.Count(); k++)
            {

                
                MdlRecap item = new MdlRecap(TitleListe[k], PrixListe[k], QtListe[k], UrlListe[k]);
                item.Width = 500;
                item.Height = 50;
                item.Margin = new Thickness(0,0,0,5);

                Stck_Rcp.Children.Add(item);
                prixTotal += QtListe[k] * PrixListe[k];

            }
            //on affiche le prix total:
            PrxTT.Text = "Total : " + prixTotal.ToString()+" Ck";

        }

        

        public void Btn_DelPanier_Click(object sender, RoutedEventArgs e)
        {
            //On annule la commande :

            //On nettoie le contenue de la page panier
            Stck_Rcp.Children.Clear();

            //On clear le contenue du panier :
            Rechercher.PageRechercher.titres.Clear();
            Rechercher.PageRechercher.prixs.Clear();
            Rechercher.PageRechercher.qts.Clear();
            Rechercher.PageRechercher.urls.Clear();

            //On reset le prix total
            prixTotal = 0;
            PrxTT.Text = "Total : 0 Ck";

            //On debloque le contenue de la page rechercher
            Rechercher.PageRechercher = new Rechercher();

        }

        private void Btn_ValPanier_Click(object sender, RoutedEventArgs e)
        {

            //On prend en compte la commande: (régles detaillé dans le sujet → augmentation du prix etc )

            MySqlConnection c = Tools.GetConnexion();

            DateTime date = DateTime.Now;

            //On créé la commande
            string req1 = "insert into commande (Date,Montant,Client_idClient) values('" + date.ToString("yyyy-MM-dd") + "','" + prixTotal.ToString().Replace(',','.') + "', " + MainWindow.sessionCourante.Id + ");";
            Tools.Commande(req1, c);

            //On récupére son id
            string req2 = "select MAX(idCommande) from commande;";
            string idCmd = Tools.Selection(req2, c)[0][0].ToString();

           

            for (int k = 0; k < Rechercher.PageRechercher.titres.Count(); k++)
            {
                //On récupére l'id de la recette
                string req3 ="select idRecette from recette where Nom='" + Rechercher.PageRechercher.titres[k] + "';";
                string idRct= Tools.Selection(req3, c)[0][0].ToString();

                //On créé la commande 
                string req4 = "insert into commande_has_recette values(" + idCmd + "," + idRct + "," + Rechercher.PageRechercher.qts[k] + " );";
                Tools.Commande(req4, c);

                //On reduit les stocks :

                //On récupére l'id et la quantité de chaque produit présent dans la recette
                string reqP = "select p.idProduit,rp.Quantite from produit as p join recette_has_produit as rp on p.idProduit=rp.Produit_idProduit where rp.Recette_idRecette=" + idRct+ ";";
                List<List<object>> resP = Tools.Selection(reqP, c);


                foreach (List<object> produit in resP)
                {
                    string qtNecessaire = (Rechercher.PageRechercher.qts[k] * Convert.ToDouble(produit[1].ToString().Replace(".", ","))).ToString().Replace(",", ".");

                    string reqRed = "update produit set stockActuel=stockActuel-"+ qtNecessaire+" where idProduit="+produit[0]+";";
                    Tools.Commande(reqRed, c);

                }



            }

            c.Close();
            

            //Puis on debite le commpte 
            if(MainWindow.sessionCourante.Cdr && MainWindow.sessionCourante.Solde - this.prixTotal >= 0)
            {
                //On met à jour le solde qui a changé grace au trigger en cas de gain d'argent
                MainWindow.sessionCourante.GetandSetSolde();

                MainWindow.sessionCourante.Solde = MainWindow.sessionCourante.Solde - this.prixTotal;
                MainWindow.sessionCourante.UpdtSolde();

            }
            


            //On supprime le panier :
            Btn_DelPanier_Click(sender, e);
        }
    }
}
