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
    /// Logique d'interaction pour AccueilGestionnaire.xaml
    /// </summary>
    public partial class AccueilGestionnaire : UserControl
    {
        public AccueilGestionnaire()
        {
            this.DataContext = null;
            InitializeComponent();
        }

        private void DisplayChoice(object sender, RoutedEventArgs e)
        {
            //On déconnecte l'utilisateur :
            //THOMAS (jsp si il faut faire quelque chose de special)

            ///On retourne en arrière en affichant la page des choix Login/Register
            Application.Current.MainWindow.DataContext = Choice.vChoice;
        }

        private void BtnBoard_Click(object sender, RoutedEventArgs e)
        {
            //On charge le board
            this.DataContext = new Board();
            //Change la couleure du logo de la page en question
            ChangeColor(1);

        }

        private void BtnCmd_Click(object sender, RoutedEventArgs e)
        {
            //On charge la page de commande
            if (Commande.PageCommande != null)
            {
                this.DataContext = Commande.PageCommande;
            }
            else
            {
                this.DataContext = new Commande();
            }
            //Change la couleure du logo de la page en question
            ChangeColor(2);

        }

        private void BtnDelCuis_Click(object sender, RoutedEventArgs e)
        {
            //On cahrge la page de suppresion des cdr
            this.DataContext = new DelCdr();
            //Change la couleure du logo de la page en question
            ChangeColor(3);
        }

        private void BtnDelRct_Click(object sender, RoutedEventArgs e)
        {
            //on charge la page de suppresion des recettes
            this.DataContext = new DelRct();
            //Change la couleure du logo de la page en question
            ChangeColor(4);
        }

        private void ChangeColor(int n)
        {
            //gére le changement des couleures des icones
            switch (n)
            {

                case 1:
                    IconBoard.Foreground = new SolidColorBrush(Colors.Black);
                    IconCmd.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF2E2F6"));
                    IconDelCdr.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconDelRct.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    break;
                case 2:
                    IconBoard.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE0DAF8"));
                    IconCmd.Foreground = new SolidColorBrush(Colors.Black);
                    IconDelCdr.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconDelRct.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    break;
                case 3:
                    IconBoard.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE0DAF8"));
                    IconCmd.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF2E2F6"));
                    IconDelCdr.Foreground = new SolidColorBrush(Colors.Black);
                    IconDelRct.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    break;
                case 4:
                    IconBoard.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE0DAF8"));
                    IconCmd.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF2E2F6"));
                    IconDelCdr.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD1D3FA"));
                    IconDelRct.Foreground = new SolidColorBrush(Colors.Black);
                    break;


            }
        }

    }
}
