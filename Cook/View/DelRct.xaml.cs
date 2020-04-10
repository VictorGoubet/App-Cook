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
    /// Logique d'interaction pour DelRct.xaml
    /// </summary>
    public partial class DelRct : UserControl
    {
        public DelRct()
        {
            InitializeComponent();
        }

        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            //On récupére la liste des recette :
            //THOMAS

            //On met les données sous cette forme :
            //Pour l'instant on reprend notre exemple des 3 recettes:
            List<string> urlListe = new List<string> { "https://cache.marieclaire.fr/data/photo/w1000_c17/cuisine/4r/tartiflette-express-au-reblochon-1.jpg", "https://cac.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2Fcac.2F2020.2F02.2F13.2Ff5f778dd-ad0a-421b-a35d-bad4e518a612.2Ejpeg/750x562/quality/80/crop-from/center/cr/wqkgR2luZXQtRHJpbiAvIFBob3RvY3Vpc2luZSAvIEN1aXNpbmUgQWN0dWVsbGU%3D/la-poule-au-riz-de-la-mere-michele.jpeg" };
            List<string> DescListe = new List<string> { "La tartiflette est une recette de cuisine inspirée de recettes traditionnelles de cuisine savoyarde La tartiflette est une recette de cuisine inspirée de recettes traditionnelles de cuisine savoyarde La tartiflette est une recette de cuisine inspirée de recettes traditionnelles de cuisine savoyarde La tartiflette est une recette de cuisine inspirée de recettes traditionnelles de cuisine savoyarde", "La poule au pot est une recette de cuisine traditionnelle de la cuisine française, ainsi qu'une spécialité de la cuisine gersoise et du Béarn, à base de pot-au-feu ou potée de poule cuite au bouillon, dans une cocotte, avec des légumes." };
            List<string> TitleListe = new List<string> { "Tartiflette", "Poule au riz" };
            List<string> TypeListe = new List<string> { "Plat", "Poté" };
            List<double> PrixListe = new List<double> { 18.50, 25.40 };

            #region listePrdts
            List<string> PrdtTartiflette = new List<string> { "Pomme de terre", "Reblochons", "Lardons", "Creme", "Oignons" };
            List<string> PrdtPoule = new List<string> { "Poule", "Riz", "Beure", "Carottes", "Choux" };
            #endregion

            #region liste QtPrdt
            List<double> QtPrdtBurger = new List<double> { 1, 150, 35, 1, 100 };
            List<double> QtPrdtTartiflette = new List<double> { 10, 250, 200, 20, 2 };
            List<double> QtrdtPoule = new List<double> { 1, 200, 50, 3, 1 };
            #endregion

            #region liste QtPrdt
            List<string> UnPrdtTartiflette = new List<string> { "", "g", "g", "cl", "" };
            List<string> UnrdtPoule = new List<string> { "", "g", "g", "", "" };
            #endregion

            List<List<string>> PrdtListe = new List<List<string>> { PrdtTartiflette, PrdtPoule };
            List<List<double>> QtListe = new List<List<double>> { QtPrdtTartiflette, QtrdtPoule };
            List<List<string>> UnListe = new List<List<string>> { UnPrdtTartiflette, UnrdtPoule };

            Pannel_Del_Rct.Children.Clear();
            //On créé les controles DetailRecette et on les affiche dans un scrollViewer
            for (int k = 0; k < urlListe.Count(); k++)
            {
                DetailRecette item = new DetailRecette(false, urlListe[k], DescListe[k], TitleListe[k], TypeListe[k], PrdtListe[k], QtListe[k], UnListe[k], PrixListe[k]);
                item.Margin = new Thickness(0, 0, 0, 10);
                item.Width = 600;
                item.Height = 300;
                Pannel_Del_Rct.Children.Add(item);
            }

        }
    }
}
