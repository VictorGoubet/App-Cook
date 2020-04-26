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
    /// Logique d'interaction pour DetailRecette.xaml
    /// </summary>
    public partial class DetailRecette : UserControl
    {
        string UrlRct;
        string DescRct;
        string TitleRct;
        string TypeRct;
        List<string> PrdtListeRct;
        List<double> QtListeRct;
        List<string> UnListeRct;
        double PrixRct;
        bool mode;


        public DetailRecette(bool mode,string UrlRct,string DescRct, string TitleRct, string TypeRct, List<string> PrdtListeRct, List<double> QtListeRct, List<string> UnListeRct,double PrixRct)
        {
            InitializeComponent();
            //On stock les données recu en parametre :
            this.UrlRct = UrlRct;
            this.DescRct = DescRct;
            this.TitleRct = TitleRct;
            this.TypeRct = TypeRct;
            this.PrdtListeRct = PrdtListeRct;
            this.QtListeRct = QtListeRct;
            this.UnListeRct = UnListeRct;
            this.PrixRct = PrixRct;
            this.mode = mode;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On le met en mode supression ou affichage (ajoute du bouton corbeille ou non utile pour la page DelCdr):
            if (mode)
            {
                //Ici on désactive le bouton de supression
                del.IsEnabled = false;
                del.Visibility = Visibility.Hidden;
            }


            //On va remplir le control avec les données passé en paramétre:
            try
            {
                ImgRct.ImageSource = new BitmapImage(new Uri(this.UrlRct));
            }
            catch
            {
                ImgRct.ImageSource = new BitmapImage(new Uri("https://www.redactio.fr/wp-content/uploads/2018/10/erreur-404.png"));
            }

            for (int i= 0;i < QtListeRct.Count();i++)
            {
                TextBlock q = new TextBlock();
                q.Text = "- "+QtListeRct[i].ToString()+" "+UnListeRct[i];
                this.Qt_Prdt.Children.Add(q);

                TextBlock p = new TextBlock();
                p.Text = PrdtListeRct[i].ToString();
                this.Prdt.Children.Add(p);
            }
            Titre.Text = this.TitleRct;
            this.Description.Text = this.DescRct;

            Type_Rct.Text = "Type : "+TypeRct;
            Prix.Text = "Prix : " +this.PrixRct.ToString() + " Ck";


        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            //On supprime la recette de la bdd
            //THOMAS

            //On actualise l'affichage de la page DelRct:
            ((Application.Current.MainWindow.DataContext as AccueilGestionnaire).DataContext as DelRct).UserControl_Loaded(sender, e);
        }
    }
}
