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
    /// Logique d'interaction pour ListeRct.xaml
    /// </summary>
    public partial class ListeRct : UserControl
    {
        public ListeRct()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On récupére la liste des recette faites par le chef (utilisateur connecté) :
            //THOMAS

            //On stock les données obtenue sous cette forme :

            //Pour l'instant on reprend notre exemple des 3 recettes:
            List<string> urlListe = new List<string>();
            List<string> DescListe = new List<string>();
            List<string> TitleListe = new List<string>();
            List<string> TypeListe = new List<string>();
            List<double> PrixListe = new List<double>();

            List<List<string>> PrdtListe = new List<List<string>>();
            List<List<double>> QtListe = new List<List<double>>();
            List<List<string>> UnListe = new List<List<string>>();

            MySqlConnection c = Tools.GetConnexion();
            string req = "select * from recette join cdr on recette.CDR_idCDR=cdr.idCDR where Client_idClient="+MainWindow.sessionCourante.Id+";";
            List<List<object>> res = Tools.Selection(req, c);

            foreach (List<object> ligne in res)
            {
                TitleListe.Add(ligne[1].ToString());
                DescListe.Add(ligne[2].ToString());
                PrixListe.Add(Convert.ToDouble(ligne[3]));
                TypeListe.Add(ligne[5].ToString());
                urlListe.Add(ligne[4].ToString());

                //On ajoute les produits correspondants :
                string reqP = "select p.Nom,p.Unite,rp.Quantite from produit as p join recette_has_produit as rp on p.idProduit=rp.Produit_idProduit join recette as r on rp.Recette_idRecette=r.idRecette where r.idRecette="+ ligne[0] + ";";
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

            c.Close();



            


            //On créé les controles Detail Recette et on les affiche dan le ScrollViewer
            for (int k = 0; k < urlListe.Count(); k++)
            {
                DetailRecette item = new DetailRecette(true,urlListe[k], DescListe[k], TitleListe[k], TypeListe[k], PrdtListe[k], QtListe[k], UnListe[k],PrixListe[k]);
                item.Margin = new Thickness(0, 0, 0, 10);
                item.Width = 600;
                item.Height = 300;
                Pannel_Rct.Children.Add(item);
            }
            
            


        }
    }
}
