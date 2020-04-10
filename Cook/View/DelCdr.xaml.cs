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

            //On met les données sous cette forme :

            //Pour l'instant on reprend notre exemple des 3 recettes:
            List<string> List_prenom= new List<string> {"Jacque","Daniel","Baptiste"};
            List<string> List_nom=new List<string>{"DelaVigne","Gaumont","Praud"};          
            List<string> List_numTel=new List<string>{"0655845865","0785652536","0125252569"};
            List<string> List_IdUser=new List<string>{"FEGUEG543", "EFIEFG548" , "459FEG548" };
            List<string> List_IdCDR=new List<string>{ "855GUEFEF" ,"NYRY555F2" , "25GRE0ECV" };            
            List<string> List_Adresse=new List<string>{"34 rue Jules Verne 92300 Levallois-Perret","40 rue des colombes AVAL","56 boulevard du general masson NANTES"};;
            List<string> List_AdrMail=new List<string> {"jacquedelavigne@yahoo.com", "dadamont@orangefr", "praudo@gmailcom" };
            List<int>    List_nbRecette =new List<int> {4,5,26};

            Pannel_Del_Cdr.Children.Clear();
            //On créé les controle ModelCDR et on les affiche dans un scrollViewer
            for (int k = 0; k < List_prenom.Count(); k++)
            {
                ModelCDR item = new ModelCDR(List_prenom[k], List_nom[k], List_numTel[k], List_IdUser[k], List_IdCDR[k], List_Adresse[k], List_AdrMail[k], List_nbRecette[k]);
                item.Margin = new Thickness(0, 0, 0, 10);
                item.Width = 600;
                item.Height = 100;
                Pannel_Del_Cdr.Children.Add(item);
            }
        }
    }
}
