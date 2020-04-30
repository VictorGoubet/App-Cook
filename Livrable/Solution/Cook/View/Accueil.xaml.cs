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
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : UserControl
    {
        int n;

        public Accueil(int n)
        {
            //Il faut reset le dataContext car de base il herite du dataContext de la fenetre mére (on tourne alors en rond)
            this.DataContext = null;
            this.n = n;

            InitializeComponent();
        }

        private void PageArriver_Loaded(object sender, RoutedEventArgs e)
        {
            //on regarde le type de compte et on affiche ou non les deux onglets supplémentaire
            if (n == 0)
            {
                this.BtnListe.IsEnabled = false;
                this.BtnNvRct.IsEnabled = false;
                this.BtnNvRct.Visibility = Visibility.Hidden;
                this.BtnListe.Visibility = Visibility.Hidden;
            }
            else
            {
                this.BtnListe.IsEnabled = true;
                this.BtnNvRct.IsEnabled = true;
                this.BtnNvRct.Visibility = Visibility.Visible;
                this.BtnListe.Visibility = Visibility.Visible;
            }
            //On affiche de base la page de recherche
            BtnRechercher_Click(sender, e);

        }

        private void DisplayChoice(object sender, RoutedEventArgs e)
        {
             

            //On efface son panier:
            if (Panier.PagePanier != null)
            {
                Panier.PagePanier.Btn_DelPanier_Click(sender, e);
            }

            //On déconnecte l'utilisateur :
            MainWindow.sessionCourante = null;
            Rechercher.PageRechercher = null;

            ///On retourne en arrière en affichant la page des choix Login/Register
            Application.Current.MainWindow.DataContext = Choice.vChoice;
        }

        private void BtnRechercher_Click(object sender, RoutedEventArgs e)
        {
            //affiche le controle rechercher dans le controle Accueil
            if (!(Rechercher.PageRechercher is null))
            {
                this.DataContext = Rechercher.PageRechercher;
            }
            else
            {
                this.DataContext = new Rechercher();
            }
            //Change la couleure du logo de la page en question
            ChangeColor(5);
        }

        private void BtnProfil_Click(object sender, RoutedEventArgs e)
        {
            //Charge la page Profil
            this.DataContext = new Profil();
            //Change la couleure du logo de la page en question
            ChangeColor(4);
        }

        private void BtnListe_Click(object sender, RoutedEventArgs e)
        {
            //Charge la page Liste
            this.DataContext = new ListeRct();
            //Change la couleure du logo de la page en question
            ChangeColor(2);
        }

        private void BtnPanier_Click(object sender, RoutedEventArgs e)
        {
            //Charge la page Panier
            if (!(Panier.PagePanier is null))
            {
                this.DataContext = Panier.PagePanier;
            }
            else
            {
                this.DataContext = new Panier();
            }
            //Change la couleure du logo de la page en question
            ChangeColor(3);
        }

        private void BtnNvRct_Click(object sender, RoutedEventArgs e)
        {
            //Charge la page nouvelle Recette
            if (!(NewRct.PageNewRct is null))
            {
                this.DataContext = NewRct.PageNewRct;
            }
            else
            {
                this.DataContext = new NewRct();
            }
            //Change la couleure du logo de la page en question
            ChangeColor(1);
        }

        

        public void ChangeColor(int n)
        {
            //Gere le changement de couleure des different icones
            switch (n)
            {
                case 1:
                    IconSearch.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE0DAF8"));
                    IconProfil.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF2E2F6"));
                    IconPanier.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconListe.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconNvRct.Foreground = new SolidColorBrush(Colors.Black);
                    break;
                case 2:
                    IconSearch.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE0DAF8"));
                    IconProfil.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF2E2F6"));
                    IconPanier.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconListe.Foreground = new SolidColorBrush(Colors.Black);
                    IconNvRct.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    break;
                case 3:
                    IconSearch.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE0DAF8"));
                    IconProfil.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF2E2F6"));
                    IconPanier.Foreground = new SolidColorBrush(Colors.Black);
                    IconListe.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconNvRct.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    break;
                case 4:
                    IconSearch.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE0DAF8")); 
                    IconProfil.Foreground = new SolidColorBrush(Colors.Black);
                    IconPanier.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconListe.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconNvRct.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    break;
                case 5:                 
                    IconSearch.Foreground = new SolidColorBrush(Colors.Black);
                    IconProfil.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF2E2F6"));
                    IconPanier.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconListe.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconNvRct.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    break;

            }

        }
    }
}
