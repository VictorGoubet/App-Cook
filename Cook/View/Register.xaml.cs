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
    /// Logique d'interaction pour Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void DisplayChoice(object sender, RoutedEventArgs e)
        {
            ///On retourne en arrière en affichant la page des choix Login/Register
            Application.Current.MainWindow.DataContext = Choice.vChoice;
        }





        private void Btn_SubRegis_Click(object sender, RoutedEventArgs e)
        {
            /// On verifie que tout les champs sont remplis
            if (NomTxtBx.Text != "" && PrenomTxtBx.Text != "" && AdrMailTxtBx.Text != "" && NumTelTxtBx.Text != "" && PswrdTxtBx.Password!="" && AdrTxtBx.Text!="" && IdTxtBx.Text!="")
            {
                char s = 'F';
                if(RadioM.IsChecked == true)
                {
                    s = 'M';
                }


                //On ajoute la personne comme utilisateur :
                MySqlConnection c = Tools.GetConnexion();
                if (c != null)
                {
                    //On l'ajoute comme client : 

                    #region Insertion CLIENT
                    string insertTableCLIENT = "insert into client(NumeroTel,Nom,Prenom,Adresse,Mdp,Pseudo,AdrMail,Sexe) values('" + NumTelTxtBx.Text+"','"+NomTxtBx.Text+"','"+PrenomTxtBx.Text+"','"+AdrTxtBx.Text+"','"+PswrdTxtBx.Password+"','"+IdTxtBx.Text+"','"+AdrMailTxtBx.Text+"','"+s+"');";
                    MySqlCommand commandCLIENT = c.CreateCommand();
                    commandCLIENT.CommandText = insertTableCLIENT;
                    try
                    {
                        commandCLIENT.ExecuteNonQuery();
                    }
                    catch(MySqlException ex)
                    {
                        MessageBox.Show("Erreure lors de l'insertion :\n"+ex);
                        return;
                    }

                    commandCLIENT.Dispose();
                    #endregion


                    if (CdrY.IsChecked == true)
                    {
                        //Si c'est un CDR on l'ajoute également comme CDR

                        //on commence par récupérer l'id du client que l'on vient d'ajouter :
                        #region Selection ID
                        string requete = "select idClient from client where NumeroTel='"+NumTelTxtBx.Text+"';";
                        MySqlCommand commandID = c.CreateCommand();
                        commandID.CommandText = requete;
                        MySqlDataReader reader = commandID.ExecuteReader();

                        List<List<string>> res = new List<List<string>>();

                        while (reader.Read())
                        {
                            List<string> ligne = new List<string>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string value = reader.GetValue(i).ToString();
                                ligne.Add(value);
                            }
                            res.Add(ligne);
                        }

                       
                        reader.Close();
                        commandID.Dispose();

                        string idClient = res[0][0];
                        #endregion

                        #region Insertion CDR
                        string insertTableCDR = "insert into cdr (Client_idClient) values("+idClient+");";
                        MySqlCommand commandCDR = c.CreateCommand();
                        commandCDR.CommandText = insertTableCDR;
                        try
                        {
                            commandCDR.ExecuteNonQuery();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Erreure lors de l'insertion :\n" + ex);
                            return;
                        }

                        commandCDR.Dispose();
                        #endregion


                    }

                    //On referme la connexion
                    c.Close();

                    ///Une fois enregistré on l'envoie sur la page de login :

                    Application.Current.MainWindow.DataContext = new Login();

                }
                else
                {
                    MessageBox.Show("Erreure de connexion à la base de donnée");
                }
                

            }

        }


        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            //Permet de valider le register par la simple touche entrée
            if (e.Key == Key.Enter)
            {
                Btn_SubRegis_Click(sender, e);
            }
        }
    }
}
