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
    /// Logique d'interaction pour Choice.xaml
    /// </summary>
    

    public partial class Choice : UserControl
    {
        public static Choice vChoice = null;
        public Choice()
        {
            InitializeComponent();
            vChoice = this;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //On charge le controle de login
            Application.Current.MainWindow.DataContext = new Login();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            //On charge le controle d'inscription
            Application.Current.MainWindow.DataContext = new Register();
        }

        private void Btn_Test_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
