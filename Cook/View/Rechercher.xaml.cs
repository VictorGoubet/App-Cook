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

        public Rechercher()
        {

            InitializeComponent();
            this.titres = new List<string>();
            this.prixs = new List<double>();
            this.qts = new List<int>();
            this.urls = new List<string>();
            PageRechercher = this;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On remplis l'adresse avec celle de la session courante :
            AdrTxtBx_Search.Text = MainWindow.sessionCourante.Adresse;

            //On récupére les données des differentes recettes: 
            //THOMAS


            //On stock les données sous cette forme :
            List<string> urlListe = new List<string> { "https://cache.marieclaire.fr/data/photo/w1000_c17/cuisine/4r/tartiflette-express-au-reblochon-1.jpg", "https://i.pinimg.com/originals/78/90/3d/78903d8a71699d0e5ad2fc6a27ca8191.jpg", "https://cac.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2Fcac.2F2020.2F02.2F13.2Ff5f778dd-ad0a-421b-a35d-bad4e518a612.2Ejpeg/750x562/quality/80/crop-from/center/cr/wqkgR2luZXQtRHJpbiAvIFBob3RvY3Vpc2luZSAvIEN1aXNpbmUgQWN0dWVsbGU%3D/la-poule-au-riz-de-la-mere-michele.jpeg" };
            List<string> DescListe = new List<string> { "La tartiflette est une recette de cuisine inspirée de recettes traditionnelles de cuisine savoyarde, de gratin de pommes de terre, oignons, lardons, le tout gratiné au reblochon.", "Un hamburger est un sandwich d'origine allemande, composé de deux pains de forme ronde généralement garnis de steak haché (généralement du bœuf) et de crudités, salade, tomate, oignon, cornichon (pickles), et de sauce…", "La poule au pot est une recette de cuisine traditionnelle de la cuisine française, ainsi qu'une spécialité de la cuisine gersoise et du Béarn, à base de pot-au-feu ou potée de poule cuite au bouillon, dans une cocotte, avec des légumes." };
            List<string> TitleListe = new List<string> { "Tartiflette", "Burger", "Poule au riz" };
            List<double> PrixListe = new List<double> { 18.50, 9.80, 25.40 };

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


                ModelRecette rct = new ModelRecette(urlListe[k], DescListe[k], TitleListe[k], PrixListe[k]);
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

            //On stock toutes les recettes trouvées sous cette forme :
            List<string> urlListe = new List<string> {"https://cac.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2Fcac.2F2020.2F02.2F13.2Ff5f778dd-ad0a-421b-a35d-bad4e518a612.2Ejpeg/750x562/quality/80/crop-from/center/cr/wqkgR2luZXQtRHJpbiAvIFBob3RvY3Vpc2luZSAvIEN1aXNpbmUgQWN0dWVsbGU%3D/la-poule-au-riz-de-la-mere-michele.jpeg" };
            List<string> DescListe = new List<string> {"La poule au pot est une recette de cuisine traditionnelle de la cuisine française, ainsi qu'une spécialité de la cuisine gersoise et du Béarn, à base de pot-au-feu ou potée de poule cuite au bouillon, dans une cocotte, avec des légumes." };
            List<string> TitleListe = new List<string> {"Poule au riz" };
            List<double> PrixListe = new List<double> {25.40 };

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
