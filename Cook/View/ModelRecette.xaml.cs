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
    /// Logique d'interaction pour ModelRecette.xaml
    /// </summary>
    public partial class ModelRecette : UserControl
    {
        string title;
        string url;
        string description;
        double prixRct;

        public ModelRecette(string url, string description, string title,double prixRct)
        {
            this.description = description;
            this.url = url;
            this.title = title;
            this.prixRct = prixRct;

            InitializeComponent();
            

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On remplis le controle  avec les données fournies:
            try
            {
                UrlSource.ImageSource = new BitmapImage(new Uri(this.url));
            }
            catch
            {
                UrlSource.ImageSource = new BitmapImage(new Uri("https://www.labaleine.fr/sites/default/files/image-not-found.jpg"));
            
            }
           
            Title_Rct.Text = this.title;
            Description_Rct.Text = this.description;
            Prix.Text = this.prixRct.ToString() + " Ck";

        }

        private void Btn_PLus_Click(object sender, RoutedEventArgs e)
        {
            //On augmente le compteur de 1
            compteur.Text = Convert.ToString(Convert.ToInt32(compteur.Text) + 1);
        }

        private void Btn_Moins_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(compteur.Text) > 0)
            {
                //On diminue le compteur de 1 (seulement si le compteur actuelle est superieur à 0 )
                compteur.Text = Convert.ToString(Convert.ToInt32(compteur.Text) - 1);
            }
        }

        private void Btn_Commander_Click(object sender, RoutedEventArgs e)
        {
            //Il faut récupérer le montant du compteur
            int n = Convert.ToInt32(compteur.Text);

            //On envoie la commande
            if (n > 0)
            {
                Rechercher.PageRechercher.titres.Add(this.title);
                Rechercher.PageRechercher.qts.Add(n);
                Rechercher.PageRechercher.prixs.Add(this.prixRct);
                Rechercher.PageRechercher.urls.Add(this.url);

                //On reinitialise le compteur:
                //compteur.Text = "0";
                Btn_Moins.IsEnabled = false;
                Btn_Plus.IsEnabled = false;
                Btn_Commander.IsEnabled = false;

            }

            
        }

        
    }
}
