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
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On  récupére la liste des produits uniques (unic) , leur quantité max/min/actuelle et leurs fournisseur :


            //Liste des fournisseurs
            List<string> Liste_fournisseur = new List<string>();

            //On stock chaque sous listes
            List<List<string>> Liste_Prdt = new List<List<string>>();
            List<List<double>> Liste_Qt = new List<List<double>>();
            List<List<string>> List_Un = new List<List<string>>();


            MySqlConnection c = Tools.GetConnexion();
            string reqF = "select * from fournisseur";
            List<List<object>> res = Tools.Selection(reqF, c);

            this.dateCmd = Convert.ToDateTime(res[0][3]);

            List<string> Produit_Fourn;
            List<double> Qt_Fourn;
            List<string> Un_Fourn;
            foreach (List<object> fournisseur in res)
            {
                Liste_fournisseur.Add(fournisseur[1].ToString()+"   "+fournisseur[2].ToString());

                Produit_Fourn = new List<string>();
                Qt_Fourn = new List<double>();
                Un_Fourn = new List<string>();
                
                //On recherche les produits disponible chez ce fournisseur
                reqF= "select * from produit where Fournisseur_idFournisseur ="+fournisseur[0].ToString()+";";
                res = Tools.Selection(reqF, c);

                foreach (List<object> p in res)
                {
                    Produit_Fourn.Add(p[1].ToString());
                    Un_Fourn.Add(p[3].ToString());
                    double qtp = Convert.ToDouble(p[6].ToString().Replace(".", ","));
                    Qt_Fourn.Add(qtp);

                    
                    
                }
                Liste_Prdt.Add(Produit_Fourn);
                List_Un.Add(Un_Fourn);
                Liste_Qt.Add(Qt_Fourn);

                
            }
            

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

            c.Close();
        }

        private void Btn_Send_Cmd_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection c = Tools.GetConnexion();

            //Pour chaque fournisseur on met à jour la date de la dernière commande/verification
            string req = "UPDATE fournisseur set DateCommande='" + DateTime.Now.ToString("yyyy'-'MM'-'dd") + "';";
            Tools.Commande(req, c);

            req = "select * from produit";
            List<List<object>> res = Tools.Selection(req, c);

            foreach (List<object> produit in res)
            {

                //Pour chaque produit on va mettre à jour les quantite min et max celon les régles du sujet :

                //Si cela fait plus de 30 jour alors on divise Qmax et Qmin par 2 sinon on fait rien
                DateTime dateDernierUpdate = Convert.ToDateTime(produit[8]);
                if ((DateTime.Now - dateDernierUpdate).Days > 30)
                {
                    req = "UPDATE produit set StockMin=StockMin/2;";
                    Tools.Commande(req, c);
                    req = "UPDATE produit set StockMax=StockMax/2;";
                    Tools.Commande(req, c);
                }

                //On réaprovisionne les stocks :
                double qtActu = Convert.ToDouble(produit[6].ToString().Replace(".", ","));
                double qtMax = Convert.ToDouble(produit[5].ToString().Replace(".", ","));
                double QuantiteRecharge = qtMax - qtActu;
               
                //si il est necessaire de faire un raprovisionnement alors on met à jour la date de réaprovisionnement de ce produit
                if (QuantiteRecharge > 0)
                {
                    
                    req = "UPDATE produit SET DateUpdate='" + DateTime.Now.ToString("yyyy'-'MM'-'dd") + "';";
                    Tools.Commande(req, c);
                    //On met à jour la quantite
                    req = "UPDATE produit SET StockActuel =StockMax;";
                    Tools.Commande(req, c);
                }

                

            }

            c.Close();

            //On actualise l'affichage :
            UserControl_Loaded(sender, e);


        }
            

        
    }
}
