using MySql.Data.MySqlClient;
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
            if (Rechercher.PageRechercher.titres != null && Rechercher.PageRechercher.titres.Count() > 0)
            {
                AffichageRecap(Rechercher.PageRechercher.titres, Rechercher.PageRechercher.prixs, Rechercher.PageRechercher.qts, Rechercher.PageRechercher.urls);
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
            //On annule le panier :

            Stck_Rcp.Children.Clear();
            Rechercher.PageRechercher.titres.Clear();
            Rechercher.PageRechercher.prixs.Clear();
            Rechercher.PageRechercher.qts.Clear();
            Rechercher.PageRechercher.urls.Clear();
            prixTotal = 0;
            PrxTT.Text = "Total : 0 Ck";
            Rechercher.PageRechercher = null;

        }

        private void Btn_ValPanier_Click(object sender, RoutedEventArgs e)
        {

            //On prend en compte la commande: (régles detaillé dans le sujet → augmentation du prix etc )
            //THOMAS

            MySqlConnection c = Tools.GetConnexion();

            DateTime date = DateTime.Now;


            string req1 = "insert into commande (Date,Montant,Client_idClient) values('" + date.ToString("yyyy-MM-dd") + "','" + prixTotal.ToString().Replace(',','.') + "', " + MainWindow.sessionCourante.Id + ");";
            Tools.Commande(req1, c);

            string req2 = "select MAX(idCommande) from commande;";
            string idCmd = Tools.Selection(req2, c)[0][0].ToString();

           

            for (int k = 0; k < Rechercher.PageRechercher.titres.Count(); k++)
            {
                
                string req3 ="select idRecette from recette where Nom='" + Rechercher.PageRechercher.titres[k] + "';";
                string idRct= Tools.Selection(req3, c)[0][0].ToString();


                string req4 = "insert into commande_has_recette values(" + idCmd + "," + idRct + "," + Rechercher.PageRechercher.qts[k] + " );";
                Tools.Commande(req4, c);


                string req5 = "select sum(nbRecette) from commande_has_recette where Recette_idRecette=" + idRct + "  ;";

                object nbV = Tools.Selection(req5, c)[0][0];
                if (nbV is DBNull)
                {
                    nbV = 0;
                }
                int nbVente = Convert.ToInt32(nbV);


                if (nbVente >= 50)
                {
                    string req6 = "select CDR_idCDR from recette where idRecette='" + idRct + "';";
                    string idCdr = Tools.Selection(req3, c)[0][0].ToString();


                    string req7 = "UPDATE recette SET Prix=Prix+5 where idRecette='" + idRct + "';";
                    Tools.Commande(req7, c);

                    string req8 = "UPDATE cdr SET solde=solde+4 where idCDR='" + idCdr + "';";
                    Tools.Commande(req8, c);
                }
                else if (nbVente >= 10)
                {
                    
                    string req9 = "UPDATE recette SET Prix=Prix+2 where idRecette='" + idRct + "';";
                    Tools.Commande(req9, c);
                }

            }


            

           
            





            c.Close();
            




            




            //On supprime le panier :
            Btn_DelPanier_Click(sender, e);
        }
    }
}
