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
using MySql.Data.MySqlClient;

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
                    //On se connecte à la bdd :
                    MySqlConnection c = Tools.GetConnexion();
                    //On vérifie si l'id et le mdp son correcte :
                    List<List<object>> res = Tools.Selection("select * from client where pseudo = '"+IdTxtBx.Text+"' and Mdp = '"+MdpTxtBx.Password+"';", c);

                    if (res.Count >0)
                    {
                        //Le membre existe, 
                        Session s;

                        //on regarde si il est cdr ou non :
                        List<List<object>> cdr = Tools.Selection("select * from cdr join client on cdr.Client_idClient=client.idClient where pseudo='"+IdTxtBx.Text+"';", c);
                        if (cdr.Count>0)
                        {
                            //On créé une session:
                            s = new Session(IdTxtBx.Text,true);
                            
                            Application.Current.MainWindow.DataContext = new Accueil(1);
                        }
                        else
                        {
                            s = new Session(IdTxtBx.Text, false);
                            Application.Current.MainWindow.DataContext = new Accueil(0);
                        }
                        MainWindow.sessionCourante = s;
                    }
                    else
                    {
                        error.Visibility = Visibility.Visible;
                    }


                  

                    c.Close();
                    

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
