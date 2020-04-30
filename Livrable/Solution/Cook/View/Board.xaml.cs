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
    /// Logique d'interaction pour Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On récupére les cdr d'or/d'argent et les 5 meilleurs recettes

            //Pour les cdr d'or et d'argent :
            List<string> List_prenom = new List<string>();
            List<string> List_nom = new List<string>();
            List<int> List_nbCmd = new List<int>();


            MySqlConnection c = Tools.GetConnexion();
            string req = "select client.nom,client.prenom,sum(cr.nbRecette),idCDR from commande_has_recette as cr join recette on cr.Recette_idRecette=recette.idRecette join cdr on cdr.idCDR=recette.CDR_idCDR join client on client.idClient=cdr.Client_idClient group by idCDR having sum(cr.nbRecette) >= ALL (select sum(cr.nbRecette) from commande_has_recette as cr join recette on cr.Recette_idRecette = recette.idRecette join cdr on cdr.idCDR = recette.CDR_idCDR group by idCDR);";
            List<List<object>> res = Tools.Selection(req, c);
            List_prenom.Add(res[0][1].ToString());
            List_nom.Add(res[0][0].ToString());
            List_nbCmd.Add(Convert.ToInt32(res[0][2]));
            string idGoldenCDR = res[0][3].ToString();

            
            req = "select client.nom,client.prenom,sum(cr.nbRecette) from commande_has_recette as cr join recette on cr.Recette_idRecette=recette.idRecette join cdr on cdr.idCDR=recette.CDR_idCDR join client on client.idClient=cdr.Client_idClient join commande on commande.idCommande=cr.Commande_idCommande where DATEDIFF(NOW(), commande.Date)< 8 group by idCDR having sum(cr.nbRecette) >= ALL (select sum(cr.nbRecette) from commande_has_recette as cr join recette on cr.Recette_idRecette = recette.idRecette join cdr on cdr.idCDR = recette.CDR_idCDR join commande on commande.idCommande = cr.Commande_idCommande where DATEDIFF(NOW(), commande.Date) < 8 group by idCDR);";
            res = Tools.Selection(req, c);
            List_prenom.Add(res[0][1].ToString());
            List_nom.Add(res[0][0].ToString());
            List_nbCmd.Add(Convert.ToInt32(res[0][2]));

            req = "select recette.nom,sum(cr.nbRecette) from recette join cdr on cdr.idCDR=recette.CDR_idCDR join commande_has_recette as cr on cr.Recette_idRecette=recette.idRecette  where idCDR = '"+ idGoldenCDR + "' group by idRecette order by sum(cr.nbRecette) limit 5;";
            res = Tools.Selection(req, c);
            foreach (List<object> ligne in res)
            {
                TextBlock t = new TextBlock();
                t.FontFamily = new FontFamily("Helvetica");
                t.FontSize = 15;
                t.Margin = new Thickness(0, 0, 0, 5);
                t.Text ="•"+ ligne[0].ToString()+" x"+ ligne[1].ToString();
                t.TextWrapping = TextWrapping.Wrap;
                RctCdr.Children.Add(t);
            }

            //Pour les 5 recettes 

            List<string> urlListe = new List<string>();
            List<string> DescListe = new List<string>();
            List<string> TitleListe = new List<string>();
            List<string> TypeListe = new List<string>();
            List<double> PrixListe = new List<double>();

            List<List<string>> PrdtListe = new List<List<string>>();
            List<List<double>> QtListe = new List<List<double>>();
            List<List<string>> UnListe = new List<List<string>>();

            req = "select recette.*,sum(cr.nbRecette) from recette join commande_has_recette as cr on cr.Recette_idRecette=recette.idRecette group by idRecette order by sum(cr.nbRecette) desc limit 5;";
            res = Tools.Selection(req, c);

            foreach (List<object> ligne in res)
            {
                TitleListe.Add(ligne[1].ToString()+" x"+ ligne[7].ToString());
                DescListe.Add(ligne[2].ToString());
                PrixListe.Add(Convert.ToDouble(ligne[3]));
                urlListe.Add(ligne[4].ToString());
                TypeListe.Add(ligne[5].ToString());
                

                //On ajoute les produits correspondants :
                string reqP = "select p.Nom,p.Unite,rp.Quantite from produit as p join recette_has_produit as rp on p.idProduit=rp.Produit_idProduit join recette as r on rp.Recette_idRecette=r.idRecette where r.idRecette=" + ligne[0] + ";";
                List<List<object>> resP = Tools.Selection(reqP, c);

                List<string> sousListePrdt = new List<string>();
                List<double> sousListeQtt = new List<double>();
                List<string> sousListeUn = new List<string>();

                foreach (List<object> produit in resP)
                {
                    sousListePrdt.Add(produit[0].ToString());
                    sousListeQtt.Add(Convert.ToDouble(produit[2]));
                    sousListeUn.Add(produit[1].ToString());

                }
                PrdtListe.Add(sousListePrdt);
                QtListe.Add(sousListeQtt);
                UnListe.Add(sousListeUn);
            }

            //On affiche les CDR d'or et d'argent :

            Gold_cdr.Text = List_prenom[0] +" "+ List_nom[0];
            Silver_cdr.Text = List_prenom[1]+" "+List_nom[1];

            Gold_n.Text = List_nbCmd[0].ToString();
            Silver_n.Text = List_nbCmd[1].ToString();

            //On créé les controle Details recette en les remplissant avec les informations obtenues et on les stack dans un pannel:
            for (int k = 0; k < urlListe.Count(); k++)
            {
                DetailRecette item = new DetailRecette(true, urlListe[k], DescListe[k], TitleListe[k], TypeListe[k], PrdtListe[k], QtListe[k], UnListe[k], PrixListe[k]);
                item.Margin = new Thickness(0, 0, 0, 10);
                item.Width = 600;
                item.Height = 300;
                Pannel_Board.Children.Add(item);
            }



        }
    }
}
