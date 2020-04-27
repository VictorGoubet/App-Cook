using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        double solde;
        string idCDR;

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
        public double Solde { get => solde; set => solde = value; }
        public string IdCDR { get => idCDR; set => idCDR = value; }

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

            this.Id = user[0].ToString();
            this.NumerTel = user[1].ToString();
            this.Nom = user[2].ToString();
            this.Prenom = user[3].ToString();
            this.Adresse = user[4].ToString();
            this.Mdp = user[5].ToString();
            this.AdresseMail = user[7].ToString();
            this.Sexe =  user[8].ToString();

            if (cdr)
            {
                List<List<object>> res10 = Tools.Selection("select solde,idCDR from cdr join client on cdr.Client_idClient=client.idClient where pseudo='" + this.pseudo + "';", c);
                this.Solde = Convert.ToDouble(res10[0][0]);
                this.idCDR= res10[0][1].ToString();
            }
            c.Close();

        }

        public bool UpdateBdd()
        {
            bool res;
            string req = "UPDATE client SET NumeroTel = '"+this.NumerTel+ "', Nom = '" + this.Nom+ "', Prenom = '" + this.Prenom+ "', Adresse='" + this.Adresse+ "',Mdp='" + this.Mdp+ "',Pseudo='" + this.Pseudo+ "',AdrMail='" + this.AdresseMail+ "',Sexe='" + this.Sexe+ "' WHERE idClient ='" + this.Id+"';";
            
            MySqlConnection c = Tools.GetConnexion();
            res=Tools.Commande(req, c);
            if (this.Cdr && res)
            {
                string req1="UPDATE cdr SET solde="+this.solde+ " where idCDR=" + this.IdCDR + ";";
                res = Tools.Commande(req1, c);
            }

            c.Close();
            return res;
        }

        
    }
}
