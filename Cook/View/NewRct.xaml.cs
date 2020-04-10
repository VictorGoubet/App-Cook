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
        List<double> qt;


        public static NewRct PageNewRct =null;
        public NewRct()
        {
            InitializeComponent();
            PageNewRct = this;
            prdts = new List<string>();
            qt = new List<double>();
        }



        private void Btn_Add_Prdt_Click(object sender, RoutedEventArgs e)
        {

            //On verifie que tout les champs sont remplis
            if(Qt.Text!="Qt" && nom_prdt.Text != "Produit")
            {
                //On ajoute le produit et sa quantité à la liste afin de le stocker jusqu'à la finalisation
                this.prdts.Add(nom_prdt.Text);
                this.qt.Add(Convert.ToDouble(Qt.Text));
            }
            
        }

        private void Btn_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            
            
            //on verifie que tout les champs sont remplis
            if (Input_Desc.Text != "" && Input_Prix.Text != "" && Input_Titre.Text != "" && Input_Type.Text != "" && Input_Url.Text != "" && qt.Count()>0)
            {
                //On ajoute la recette dans la bdd:
                //THOMAS

                //On actualise la page :
                NewRct.PageNewRct = null;
                (Application.Current.MainWindow.DataContext as Accueil).DataContext = new NewRct();

            }


        }
    }
}
