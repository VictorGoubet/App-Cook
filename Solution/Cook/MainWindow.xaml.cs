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
using Cook.View;

namespace Cook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //On va stocker ici la session:
        public static Session sessionCourante;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            //On ferme la fenetre
            Application.Current.Shutdown();
            
        }

        private void Btn_Reduce_Click(object sender, RoutedEventArgs e)
        {
            //On reduit la fenetre
            this.WindowState = WindowState.Minimized;
        }

        private void DisplayChoice(object sender, RoutedEventArgs e)
        {
            //On affiche le controle permettant de faire le choix entre login et register:


            Choice page = Choice.vChoice;
            if (page == null)
            {
                page = new Choice();
            }
            this.DataContext = page;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Permet de drag la fenetre avec la souris
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }

        }
    }
}
