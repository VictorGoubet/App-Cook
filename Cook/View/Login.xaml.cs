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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        static Dictionary<string, string> Gestionnaires=new Dictionary<string, string>{ {"root","123"}
        };

        public Login()
        {
            InitializeComponent();
        }

        private void DisplayChoice(object sender, RoutedEventArgs e)
        {
            ///On retourne en arrière en affichant la page des choix Login/Register
            Application.Current.MainWindow.DataContext = Choice.vChoice;
        }



        private void Btn_GoLogin_Click(object sender, RoutedEventArgs e)
        {
            /// On verifie que tout les champs sont remplis
            if(IdTxtBx.Text!="" && MdpTxtBx.Password!="")
            { 
            
                //On vérifie qu'on n'essaie pas de se connecter en mode gestionnaire
               if(Gestionnaires.ContainsKey(IdTxtBx.Text) && Gestionnaires[IdTxtBx.Text] == MdpTxtBx.Password)
                {
                    Application.Current.MainWindow.DataContext = new AccueilGestionnaire();
                }
                else
                {
                    //On vérifie si l'id et le mdp son correcte :
                    //THOMAS

                    //On affiche le bon contenue en fonction du type d'utilisateur:

                    ///En réalité ici il faut comparer le type d'utilisateur et non pas les id:
                    //THOMAS

                    if (IdTxtBx.Text == "cdr")
                    {
                        Application.Current.MainWindow.DataContext = new Accueil(1);
                    }
                    else
                    {
                        Application.Current.MainWindow.DataContext = new Accueil(0);
                    }

                }

                

                
                

            }
            
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            //Permet de valider en faisant entrer
            if (e.Key == Key.Enter)
            {
                Btn_GoLogin_Click(sender, e);
            }

        }
    }
}
