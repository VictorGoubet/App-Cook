using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cook.View
{
    class Tools
    {


        public static MySqlConnection GetConnexion()
        {


            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=Cook;" +
                                         "UID=root;PASSWORD=Pluton740@!!";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                return maConnexion;
            }
            catch 
            {
                return null;
            }

            
        }
    }
}
