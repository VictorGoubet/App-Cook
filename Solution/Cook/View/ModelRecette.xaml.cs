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
    /// Logique d'interaction pour ModelRecette.xaml
    /// </summary>
    public partial class ModelRecette : UserControl
    {
        string title;
        string url;
        string description;
        double prixRct;
        string id;
        List<double> Liste_qtNec;
        List<double> Liste_qtActu;

        public ModelRecette(string url, string description, string title,double prixRct,string id)
        {
            this.description = description;
            this.url = url;
            this.title = title;
            this.prixRct = prixRct;
            this.id = id;
            this.Liste_qtNec = new List<double>();
            this.Liste_qtActu = new List<double>();

            InitializeComponent();
            

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On remplis le controle  avec les données fournies:
            try
            {
                UrlSource.ImageSource = new BitmapImage(new Uri(this.url));
            }
            catch
            {
                UrlSource.ImageSource = new BitmapImage(new Uri("https://www.labaleine.fr/sites/default/files/image-not-found.jpg"));
            
            }
           
            Title_Rct.Text = this.title;
            Description_Rct.Text = this.description;
            Prix.Text = this.prixRct.ToString() + " Ck";

            //----------VERIFICATION QUANTITE SUFFISANTE-----
            MySqlConnection c = Tools.GetConnexion();
            string req2 = "select rp.Quantite,p.StockActuel from produit as p join recette_has_produit as rp on p.idProduit=rp.Produit_idProduit where rp.Recette_idRecette=" +this.id + ";";
            List<List<object>> res2 = Tools.Selection(req2, c);

            bool gris = false;
            foreach (List<object> produit in res2)
            {
                double qtNec = Convert.ToDouble(produit[0].ToString().Replace(".", ","));
                double qtActu = Convert.ToDouble(produit[1].ToString().Replace(".", ","));
                Liste_qtActu.Add(qtActu);
                Liste_qtNec.Add(qtNec);
                if (qtActu - qtNec < 0)
                {
                    gris = true;
                    break;
                }
            }

            c.Close();

            if (gris)
            {
                Epuise.Visibility = Visibility.Visible;
                this.Opacity = 0.5;
                this.IsEnabled = false;
                
            }

            //----------

        }

        private void Btn_PLus_Click(object sender, RoutedEventArgs e)
        {

            //On va verifier si il reste assez d'ingredient pour ajouter encore une recette :
            bool possible = true;
            int n = Convert.ToInt32(compteur.Text);
            for (int k = 0; k < this.Liste_qtNec.Count(); k++)
            {
                if (Liste_qtActu[k] - (n+1) * Liste_qtNec[k]<0)
                {
                    possible = false;
                    break;
                }
            }
            //Si c'est possible on augmente le compteur de 1
            if (possible)
            {
                compteur.Text = Convert.ToString(Convert.ToInt32(compteur.Text) + 1);
            }

        }

        private void Btn_Moins_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(compteur.Text) > 0)
            {
                //On diminue le compteur de 1 (seulement si le compteur actuelle est superieur à 0 )
                compteur.Text = Convert.ToString(Convert.ToInt32(compteur.Text) - 1);
            }
        }

        private void Btn_Commander_Click(object sender, RoutedEventArgs e)
        {
            //Il faut récupérer le montant du compteur
            int n = Convert.ToInt32(compteur.Text);

            //On envoie la commande
            if (n > 0)
            {
                Rechercher.PageRechercher.titres.Add(this.title);
                Rechercher.PageRechercher.qts.Add(n);
                Rechercher.PageRechercher.prixs.Add(this.prixRct);
                Rechercher.PageRechercher.urls.Add(this.url);

                //On reinitialise le compteur:
                //compteur.Text = "0";
                Btn_Moins.IsEnabled = false;
                Btn_Plus.IsEnabled = false;
                Btn_Commander.IsEnabled = false;
                Btn_Commander.Opacity = 0.2;

            }

            
        }

        
    }
}
