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
    /// Logique d'interaction pour Rechercher.xaml
    /// </summary>
    public partial class Rechercher : UserControl
    {
        public static Rechercher PageRechercher = null;

        public List<string> titres;
        public List<double> prixs;
        public List<int> qts;
        public List<string> urls;
        bool gris;
        

        public Rechercher()
        {

            InitializeComponent();
            this.titres = new List<string>();
            this.prixs = new List<double>();
            this.qts = new List<int>();
            this.urls = new List<string>();
            this.gris = true;
            PageRechercher = this;

            //On remplis l'adresse avec celle de la session courante :
            AdrTxtBx_Search.Text = MainWindow.sessionCourante.Adresse;

            //On récupére les données des differentes recettes: 
            MySqlConnection c = Tools.GetConnexion();
            string req = "select * from recette";
            List<List<object>> res = Tools.Selection(req, c);

            //On stock les données sous cette forme :
            List<string> urlListe = new List<string>();
            List<string> DescListe = new List<string>();
            List<string> TitleListe = new List<string>();
            List<double> PrixListe = new List<double>();
            

            foreach (List<object> ligne in res)
            {
                TitleListe.Add(ligne[1].ToString());
                DescListe.Add(ligne[2].ToString());
                PrixListe.Add(Convert.ToDouble(ligne[3]));
                urlListe.Add(ligne[4].ToString());

                string req2="select rp.Quantite,p.StockActuel from produit as p join recette_has_produit as rp on p.idProduit=rp.Produit_idProduit where rp.Recette_idRecette=" + ligne[0].ToString() + ";";
                List <List<object>> res2 = Tools.Selection(req2, c);
                foreach(List <object> produit in res2)
                {
                    double qtNec = Convert.ToDouble(produit[0].ToString().Replace(".", ","));
                    double qtActu = Convert.ToDouble(produit[1].ToString().Replace(".", ","));
                    if (qtNec - qtActu < 0)
                    {
                        this.gris = true;
                        break;
                    }
                }
            }

            c.Close();



            //On ajoute un controle "ModelRecette" par recette
            AffichageRct(urlListe, DescListe, TitleListe, PrixListe);
        }


       

        private void Btn_Edit_Search_Click(object sender, RoutedEventArgs e)
        {
            //On redirige vers la page profil
            (Application.Current.MainWindow.DataContext as Accueil).DataContext = new Profil();
            (Application.Current.MainWindow.DataContext as Accueil).ChangeColor(4);
            

        }

        

        private void AffichageRct(List<string> urlListe, List<string> DescListe, List<string> TitleListe,List<double> PrixListe)
        {
            scroll.Children.Clear();

            //On remplis les control Modelrecette avec les info fournie et on les stocks dans un scrolViewer :
            for (int k = 0; k < urlListe.Count(); k++)
            {

                MessageBox.Show(gris.ToString());
                ModelRecette rct = new ModelRecette(urlListe[k], DescListe[k], TitleListe[k], PrixListe[k],gris);
                rct.Width = 600;
                rct.Height = 200;
                rct.Margin = new Thickness(0, 0, 0, 50);
                scroll.Children.Add(rct);
            }

        }

        private void Search_field_button_Click(object sender, RoutedEventArgs e)
        {
            //On récupére le contenu de la recherche:

            string rch = Search_field.Text;

            //On va rechercher parmis les titres de recettes existant :
            //THOMAS (utilisation de LIKE %rch%)
            MySqlConnection c = Tools.GetConnexion();
            string req = "select * from recette where nom like '%" + Search_field.Text + "%';";
            List<List<object>> res = Tools.Selection(req, c);

            //On stock toutes les recettes trouvées sous cette forme :
            List<string> urlListe = new List<string> {};
            List<string> DescListe = new List<string> {};
            List<string> TitleListe = new List<string> {};
            List<double> PrixListe = new List<double> {};

            foreach (List<object> ligne in res)
            {
                TitleListe.Add(ligne[1].ToString());
                DescListe.Add(ligne[2].ToString());
                PrixListe.Add(Convert.ToDouble(ligne[3]));
                urlListe.Add(ligne[4].ToString());
            }

            c.Close();

            //On les affiches
            AffichageRct(urlListe, DescListe, TitleListe,PrixListe);

        }

        private void Search_field_KeyDown(object sender, KeyEventArgs e)
        {
            //Permet de valider la recherche par la touche entré
            if (e.Key == Key.Enter)
            {
                Search_field_button_Click(sender, e);
            }

        }
    }
}
