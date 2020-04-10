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
    /// Logique d'interaction pour MdlRecap.xaml
    /// </summary>
    public partial class MdlRecap : UserControl
    {
        string titre;
        double prix;
        int qt;
        string urlimg;

        public MdlRecap(string titre,double prix,int qt,string urlimg)
        {
            this.titre = titre;
            this.prix = prix;
            this.qt = qt;
            this.urlimg = urlimg;
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On remplis le control avec les données rentrées en parametre
            this.Titre.Text = this.titre;
            this.Qt.Text = this.qt.ToString();
            this.Prix.Text = (this.prix*this.qt).ToString() + " Ck ";
            this.Image.ImageSource= new BitmapImage(new Uri(this.urlimg));
        }
    }
}
