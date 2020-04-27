using MySql.Data.MySqlClient;
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
    /// Logique d'interaction pour NewRct.xaml
    /// </summary>
    public partial class NewRct : UserControl
    {

        List<string> prdts;
        List<string> qt;


        public static NewRct PageNewRct =null;
        public NewRct()
        {
            InitializeComponent();
            PageNewRct = this;
            prdts = new List<string>();
            qt = new List<string>();
        }



        private void Btn_Add_Prdt_Click(object sender, RoutedEventArgs e)
        {

            //On verifie que tout les champs sont remplis
            if(Qt.Text!="" && ListePrdt.SelectedItem!=null)
            {
                //On ajoute le produit et sa quantité à la liste afin de le stocker jusqu'à la finalisation
                
                
                try
                {
                    Qt.Text = Qt.Text.Replace(".", ",");
                    double q = Convert.ToDouble(Qt.Text);
                    Qt.Text = Qt.Text.Replace(",", ".");

                    this.qt.Add(Qt.Text);
                    this.prdts.Add(ListePrdt.SelectedItem.ToString());
                }
                catch
                {
                    MessageBox.Show("Erreure, la valeure rentrée n'est pas numérique");
                }
                
                Qt.Text = "";
                ListePrdt.SelectedItem = null;
            }
            
        }

        private void Btn_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            
            
            //on verifie que tout les champs sont remplis
            if (Input_Desc.Text != "" && Input_Prix.Text != "" && Input_Titre.Text != "" && Input_Type.Text != "" && Input_Url.Text != "" && qt.Count()>0)
            {
                //On ajoute la recette dans la bdd:
                try
                {
                    Input_Prix.Text = Input_Prix.Text.Replace(".", ",");
                    double p = Convert.ToDouble(Input_Prix.Text);
                    if(p<10 || p > 40)
                    {
                        throw new Exception("Le prix doit être compris entre 10 et 40 Cook ! ");
                    }
                    Input_Prix.Text = Input_Prix.Text.Replace(",", ".");

                    MySqlConnection c = Tools.GetConnexion();
                    string req1 = "select idCDR from cdr where Client_idClient=" + MainWindow.sessionCourante.Id + ";";
                    List<List<object>> res1 = Tools.Selection(req1, c);
                    if (!Tools.Commande(req1, c))
                    {
                        MessageBox.Show("CDR courrant non trouvé ");
                    }





                    string req2 = "insert into recette(Nom,Description,Prix,url,Type,CDR_idCDR) values('" + Input_Titre.Text + "','" + Input_Desc.Text + "'," + Input_Prix.Text + ",'" + Input_Url.Text + "','" + Input_Type.Text + "', " + res1[0][0] + " );";
                    Tools.Commande(req2, c);
                    //On récupére l'id de la recette précédemment insérée
                    string req3 = "select idRecette from recette where Nom='" + Input_Titre.Text + "';";
                    List<List<object>> res3 = Tools.Selection(req3, c);
                    int idRecette = Convert.ToInt32(res3[0][0]);

                    for (int k = 0; k < prdts.Count(); k++)
                    {
                        string req4 = "select idProduit from produit where Nom='" + prdts[k] + "';";
                        List<List<object>> res4 = Tools.Selection(req4, c);
                        int idProduit = Convert.ToInt32(res4[0][0]);
                        string req5 = "insert into recette_has_produit values (" + idRecette + "," + idProduit + "," + qt[k] + ");";
                        Tools.Commande(req5, c);


                    }


                    c.Close();

                    //On actualise la page :
                    NewRct.PageNewRct = null;
                    Rechercher.PageRechercher = null;
                    (Application.Current.MainWindow.DataContext as Accueil).DataContext = new NewRct();

                }
                catch(Exception ex) {
                    MessageBox.Show(ex+"\n Veuillez réessayer");
                    
                    }
                

                

            }


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MySqlConnection c = Tools.GetConnexion();
            string req = "select Nom from produit";
            List<List<Object>> res = Tools.Selection(req, c);
            List<string> Prdts = new List<string>();

            foreach(List<object> l in res)
            {
                Prdts.Add(l[0].ToString());
            }
            ListePrdt.ItemsSource = Prdts;
        }
    }
}
