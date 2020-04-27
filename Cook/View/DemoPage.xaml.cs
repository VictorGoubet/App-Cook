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
    /// Logique d'interaction pour DemoPage.xaml
    /// </summary>
    public partial class DemoPage : UserControl
    {


        int index;
        int nbClient;
        int nbCdr;
        List<string> Liste_Nom;
        List<int> Liste_nb;

        public DemoPage()
        {
            InitializeComponent();
            Liste_Nom = new List<string>();
            Liste_nb = new List<int>();
            index = 1;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            //On va enregistrer les réponses de toutes les requêtes :

            MySqlConnection c = Tools.GetConnexion();
            string req = "select count(*) from client";
            nbClient = Convert.ToInt32(Tools.Selection(req, c)[0][0]);

            req = "select count(*),client.nom from commande_has_recette as cr join cdr on cr.Recette_CDR_idCDR=cdr.idCDR join client on cdr.Client_idClient=client.idClient group by idCDR;";
            List<List<object>> res = Tools.Selection(req, c);
            foreach( List<object> ligne in res){
                Liste_nb.Add(Convert.ToInt32(res[0]));
                Liste_Nom.Add(res[1].ToString());
            }
            c.Close();


            Affichage(index);
            
        }


        private void DisplayChoice(object sender, RoutedEventArgs e)
        {
            ///On retourne en arrière en affichant la page des choix Login/Register
            Application.Current.MainWindow.DataContext = Choice.vChoice;
        }


        private void next_Click(object sender, RoutedEventArgs e)
        {
            //On va appeler l'affichage relié à l'indexe i
            if (index < 5)
            {
                index++;
                Affichage(index);
            }
            
            

        }

        private void previous_Click(object sender, RoutedEventArgs e)
        {

            //On va appeler l'affichage relié à l'indexe i
            if (index > 1)
            {
                index--;
                Affichage(index);
            }
            
            
        }


        private void Affichage(int i)
        {
            viewer.Children.Clear();

            if (i == 1)
            {
                Affichage1();
            }
            else if (i == 2)
            {
                Affichage2();
            }
            else if (i == 3)
            {
                Affichage3();
            }
            else if (i == 4)
            {
                Affichage4();
            }
            else if (i == 5)
            {
                Affichage5();
            }



        }


        //Ici on définit les 5 affichages possibles :

        private void Affichage1()
        {
            //THOMAS : Il faut ici récupérer le nombre n de client
           
            TextBlock t = new TextBlock();
            t.Foreground = Brushes.Black;
            t.FontWeight = FontWeights.Bold;
            t.Text = "Nombre de client : "+ nbClient.ToString();
            viewer.Children.Add(t);

        }
        private void Affichage2()
        {
            //THOMAS : Il faut ici récupérer le nombre n de CDR
            TextBlock t = new TextBlock();
            t.Foreground = Brushes.Black;
            t.FontWeight = FontWeights.Bold;
            t.Text = "Nombre de CDR : " + nbCdr.ToString()+"\n";
            viewer.Children.Add(t);

            //THOMAS : On récupére la liste des noms des CDR et pour chacun leurs nombre de recette commandées

            for(int k = 0; k < Liste_nb.Count(); k++)
            {
                TextBlock t2 = new TextBlock();
                t2.Text = Liste_Nom[k]+" : "+Liste_nb[k]+" recettes";
                viewer.Children.Add(t2);

            }

            


        }
        private void Affichage3()
        {

            //THOMAS : Il faut ici récupérer le nombre n de recettes

            int n = 52;
            TextBlock t = new TextBlock();
            t.Foreground = Brushes.Black;
            t.FontWeight = FontWeights.Bold;
            t.Text = "Nombre de recette : " + n.ToString();
            viewer.Children.Add(t);

        }
        private void Affichage4()
        {
            TextBlock t = new TextBlock();
            t.Foreground = Brushes.Black;
            t.FontWeight = FontWeights.Bold;
            t.Text = "Liste des produits ayant une quantité en stock inférieure ou\négale à deux fois leur quantité minimale : \n";
            viewer.Children.Add(t);


            //THOMAS : Il faut ici récupérer la Liste des produits ayant une quantité en stock inférieure ou égale à deux fois leur quantité minimale

            List<string> Liste_prdt = new List<string> { "Farine", "Oeuf", "Boeuf", "Salade", "Mais", "Jambon", "Farine", "Oeuf", "Boeuf", "Salade", "Mais", "Jambon" };

            foreach(string elem in Liste_prdt)
            {
                TextBlock t2 = new TextBlock();
                t2.Text = elem;
                viewer.Children.Add(t2);
            }
            


        }
        private void Affichage5()
        {

            
            TextBox searchbox = new TextBox();
            searchbox.Tag = "Search";
            Style style = this.FindResource("placeHolder") as Style;
            searchbox.Style = style;
            searchbox.KeyDown += AffichageRecette5;

            viewer.Children.Add(searchbox);

            


        }

        private void AffichageRecette5(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                
                string nomIngredient = (sender as TextBox).Text;
                viewer.Children.Clear();
                Affichage5();

                //THOMAS : Il faut ici récupérer la Liste des recettes utilisant le produit recherché et également prendre sa quantité dans cette recette et l'unité associé au produit
                string unite = "kg";
                List<string> Nom_Recette = new List<string> { "Burger", "Poule au riz" };
                List<double> Qt = new List<double> {14.5, 25};

                TextBlock prdt= new TextBlock();
                prdt.Text = "\nIngrédient : "+ nomIngredient+"\n";
                prdt.Foreground = Brushes.Black;
                prdt.FontWeight = FontWeights.Bold;

                viewer.Children.Add(prdt);

                if (Nom_Recette.Count() > 0)
                {
                    for (int k = 0; k < Nom_Recette.Count(); k++)
                    {
                        TextBlock t = new TextBlock();
                        t.Text = Nom_Recette[k] + " : " + Qt[k] + unite;
                        viewer.Children.Add(t);
                    }

                }
                else
                {
                    TextBlock t = new TextBlock();
                    t.Text = "Oops, il semblerait que ce produit est utilisé dans aucunes recettes !";
                    viewer.Children.Add(t);
                }

                
                
            }
            

        }



    }
}
