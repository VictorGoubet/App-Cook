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
        int nbRct;
        Dictionary<string, int> ListeAf2;
        List<string> prdts;

        public DemoPage()
        {
            InitializeComponent();
            ListeAf2= new Dictionary<string, int>();
            prdts = new List<string>();
            index = 1;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            //On va enregistrer les réponses de toutes les requêtes :

            MySqlConnection c = Tools.GetConnexion();
            string req = "select count(*) from client";
            nbClient = Convert.ToInt32(Tools.Selection(req, c)[0][0]);

            req = "select count(*) from cdr";
            nbCdr = Convert.ToInt32(Tools.Selection(req, c)[0][0]);

            req = "select sum(cr.nbRecette),client.nom from commande_has_recette as cr join recette on cr.Recette_idRecette=recette.idRecette join cdr on cdr.idCDR=recette.CDR_idCDR join client on client.idClient=cdr.Client_idClient group by idCDR;";
            List<List<object>> res = Tools.Selection(req, c);
            foreach( List<object> ligne in res){

                ListeAf2.Add(ligne[1].ToString(), Convert.ToInt32(ligne[0]));
            }

            req = "select count(*) from recette";
            nbRct = Convert.ToInt32(Tools.Selection(req, c)[0][0]);

            req = "select nom from produit where stockActuel<=2*StockMin";
            foreach(List<object> l in Tools.Selection(req, c))
            {
                prdts.Add(l[0].ToString());
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
           
            TextBlock t = new TextBlock();
            t.Foreground = Brushes.Black;
            t.FontWeight = FontWeights.Bold;
            t.Text = "Nombre de client : "+ nbClient.ToString();
            viewer.Children.Add(t);

        }
        private void Affichage2()
        {

            TextBlock t = new TextBlock();
            t.Foreground = Brushes.Black;
            t.FontWeight = FontWeights.Bold;
            t.Text = "Nombre de CDR : " + nbCdr.ToString()+"\n";
            viewer.Children.Add(t);

            foreach(KeyValuePair<string,int> elem in ListeAf2.OrderByDescending(key=>key.Value))
            {
                TextBlock t2 = new TextBlock();
                t2.Text =String.Format("{0} : recettes {1}",elem.Key,elem.Value);
                viewer.Children.Add(t2);
            }
            

        }
        private void Affichage3()
        {

            TextBlock t = new TextBlock();
            t.Foreground = Brushes.Black;
            t.FontWeight = FontWeights.Bold;
            t.Text = "Nombre de recette : " + nbRct.ToString();
            viewer.Children.Add(t);

        }
        private void Affichage4()
        {
            TextBlock t = new TextBlock();
            t.Foreground = Brushes.Black;
            t.FontWeight = FontWeights.Bold;
            t.Text = "Liste des produits ayant une quantité en stock inférieure ou\négale à deux fois leur quantité minimale : \n";
            viewer.Children.Add(t);


            foreach(string elem in prdts)
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

                string unite;
                List<string> Nom_Recette = new List<string>();
                List<string> Qt = new List<string>();

                MySqlConnection c = Tools.GetConnexion();
                string req = "select Quantite,p.Unite,r.nom from recette_has_produit as rc join produit as p on p.idProduit=rc.Produit_idProduit join recette as r on r.idRecette=rc.Recette_idRecette where p.nom ='"+nomIngredient+"';";
                List<List<object>> res = Tools.Selection(req, c);
                if (res.Count() > 0)
                {
                    unite = res[0][1].ToString();
                    foreach (List<object> ligne in res)
                    {
                        Nom_Recette.Add(ligne[2].ToString());
                        Qt.Add(ligne[0].ToString());
                    }



                    TextBlock prdt = new TextBlock();
                    prdt.Text = "\nIngrédient : " + nomIngredient + "\n";
                    prdt.Foreground = Brushes.Black;
                    prdt.FontWeight = FontWeights.Bold;

                    viewer.Children.Add(prdt);

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
