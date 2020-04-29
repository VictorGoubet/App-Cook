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
    /// Logique d'interaction pour Fournisseur.xaml
    /// </summary>
    public partial class Fournisseur : UserControl
    {
        List<string> Liste_Prdt;
        string nom_Fournisseur;
        List<double> Liste_Qt;
        List<string> List_Un;

        public Fournisseur(List<string> Liste_Prdt,string nom_Fournisseur, List<double> Liste_Qt, List<string> List_Un)
        {
            InitializeComponent();
            //On stock les données rentrées en parametre
            this.Liste_Prdt = Liste_Prdt;
            this.nom_Fournisseur = nom_Fournisseur;
            this.Liste_Qt = Liste_Qt;
            this.List_Un = List_Un;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On remplis le control avec les element renseignés:


            Nom_Fournisseur.Text = this.nom_Fournisseur;

            //On affiche les lignes afin d'avoir un tableau :
            Prdt1.ShowGridLines = true;
            Prdt2.ShowGridLines = true;
            Qt1.ShowGridLines = true;
            Qt2.ShowGridLines = true;


            //On va ajouter tout les produits que l'on achete à ce fournisseur avec les quantités
            for (int k=0; k < Liste_Prdt.Count(); k++)
            {

                //Une fois sur deux on insere dans la ligne du dessous
                if (k % 2 == 0)
                {
                    ColumnDefinition colonne = new ColumnDefinition();
                    Prdt1.ColumnDefinitions.Add(colonne);

                    TextBlock itemPrdt1 = new TextBlock();
                    itemPrdt1.Text = Liste_Prdt[k];
                    itemPrdt1.HorizontalAlignment = HorizontalAlignment.Center;
                    itemPrdt1.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(itemPrdt1,(k/2));
                    Prdt1.Children.Add(itemPrdt1);

                    //On ajoute egalement la quantité : 
                    ColumnDefinition colonneQ = new ColumnDefinition();
                    Qt1.ColumnDefinitions.Add(colonneQ);

                    TextBlock itemQt1 = new TextBlock();
                    itemQt1.Text = Liste_Qt[k].ToString()+List_Un[k];
                    itemQt1.HorizontalAlignment = HorizontalAlignment.Center;
                    itemQt1.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(itemQt1, (k / 2));
                    Qt1.Children.Add(itemQt1);

                }
                else
                {
                    ColumnDefinition colonne = new ColumnDefinition();
                    Prdt2.ColumnDefinitions.Add(colonne);

                    TextBlock itemPrdt2 = new TextBlock();
                    itemPrdt2.Text = Liste_Prdt[k];
                    itemPrdt2.HorizontalAlignment = HorizontalAlignment.Center;
                    itemPrdt2.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(itemPrdt2, (k / 2));
                    Prdt2.Children.Add(itemPrdt2);

                    //On ajoute egalement la quantité : 
                    ColumnDefinition colonneQ = new ColumnDefinition();
                    Qt2.ColumnDefinitions.Add(colonneQ);

                    TextBlock itemQt2 = new TextBlock();
                    itemQt2.Text = Liste_Qt[k].ToString()+ List_Un[k];
                    itemQt2.HorizontalAlignment = HorizontalAlignment.Center;
                    itemQt2.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(itemQt2, (k / 2));
                    Qt2.Children.Add(itemQt2);

                }
            }

        }
    }
}
