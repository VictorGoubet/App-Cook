﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


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
    abstract class Tools
    {


        public static MySqlConnection GetConnexion()
        {


            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = "SERVER=localhost;PORT=3306;" +
                                         "DATABASE=Cook;" +
                                         "UID=root;PASSWORD=ks7879;";

                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                return maConnexion;
            }
            catch 
            {
                return null;
            }

            
        }


        public static bool Commande( string req, MySqlConnection c)
        {
            bool res = true;

            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = req;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
                res = false;
            }

            cmd.Dispose();
            return res;
        }


        public static List<List<object>> Selection(string req,MySqlConnection c)
        {
            MySqlCommand cmd = c.CreateCommand();
            cmd.CommandText = req;
            MySqlDataReader reader = cmd.ExecuteReader();

            List<List<object>> res = new List<List<object>>();

            while (reader.Read())
            {
                List<object> ligne = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    object value = reader.GetValue(i);
                    ligne.Add(value);
                }
                res.Add(ligne);
            }


            reader.Close();
            cmd.Dispose();

            return res;

          

        }

    }
}
