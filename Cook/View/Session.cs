using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cook.View
{
    public class Session
    {

        string id;
        string nom;
        string prenom;
        string adresse;
        string adresseMail;
        string pseudo;
        string mdp;
        bool cdr;
        string sexe;
        string numerTel;

        public string Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string AdresseMail { get => adresseMail; set => adresseMail = value; }
        public string Pseudo { get => pseudo; set => pseudo = value; }
        public string Mdp { get => mdp; set => mdp = value; }
        public bool Cdr { get => cdr; set => cdr = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string NumerTel { get => numerTel; set => numerTel = value; }



        public Session(string pseudo,bool cdr)
        {
            this.Pseudo = pseudo;
            this.Cdr = cdr;
            InitSession();
        }

        private void InitSession()
        {
            //On va récupérer le nom prenom etc correspondant à l'id de la session :
            MySqlConnection c = Tools.GetConnexion();
            List<List<object>> res = Tools.Selection("select * from client where Pseudo='"+this.pseudo+"';", c);
            List<object> user = res[0];

            this.Id= user[0] as string;
            this.NumerTel = user[1] as string;
            this.Nom = user[2] as string;
            this.Prenom = user[3] as string;
            this.Adresse = user[4] as string;
            this.Mdp = user[5] as string;
            this.AdresseMail = user[7] as string;
            this.Sexe =  user[8] as string;

        }

        
    }
}
