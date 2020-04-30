using MySql.Data.MySqlClient;
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
    /// Logique d'interaction pour DelCdr.xaml
    /// </summary>
    public partial class DelCdr : UserControl
    {
        public DelCdr()
        {
            InitializeComponent();
        }

        public void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //On récupére la liste des chefs :
            //THOMAS

            MySqlConnection c = Tools.GetConnexion();
            string req1 = "select * from client cl, cdr cr where cl.idCLient=cr.Client_idClient;";
            List<List<object>> res = Tools.Selection(req1, c);
            
            

            //On met les données sous cette forme :

            List<string> List_prenom= new List<string> ();
            List<string> List_nom=new List<string>();          
            List<string> List_numTel=new List<string>();
            List<string> List_IdUser=new List<string>();
            List<string> List_IdCDR=new List<string>();            
            List<string> List_Adresse=new List<string>();;
            List<string> List_AdrMail=new List<string> ();

            foreach (List<object> ligne in res)
            {
                List_prenom.Add(ligne[3].ToString());
                List_nom.Add(ligne[2].ToString());
                List_numTel.Add(ligne[1].ToString());
                List_IdUser.Add(ligne[6].ToString());
                List_IdCDR.Add(ligne[9].ToString());
                List_Adresse.Add(ligne[4].ToString());
                List_AdrMail.Add(ligne[7].ToString());
                
            }




            Pannel_Del_Cdr.Children.Clear();
            //On créé les controle ModelCDR et on les affiche dans un scrollViewer

            
            for (int k = 0; k < List_prenom.Count(); k++)
            {
                string req2 = "Select count(*) from recette where CDR_idCDR="+ List_IdCDR[k] + ";";
                int nRecette = Convert.ToInt32(Tools.Selection(req2, c)[0][0]);

                ModelCDR item = new ModelCDR(List_prenom[k], List_nom[k], List_numTel[k], List_IdUser[k], List_IdCDR[k], List_Adresse[k], List_AdrMail[k], nRecette);
                item.Margin = new Thickness(0, 0, 0, 10);
                item.Width = 600;
                item.Height = 100;
                Pannel_Del_Cdr.Children.Add(item);
            }
            c.Close();
        }
    }
}
