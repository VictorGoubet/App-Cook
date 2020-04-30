using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Windows;

namespace Cook.View
{
    class SerializationXML
    {

        List<List<object>> ProduitsXML;
        Dictionary<string, string> FournisseursXML;

        public SerializationXML(List<List<object>> ProduitsXML, Dictionary<string, string> FournisseursXML)
        {
            this.ProduitsXML = ProduitsXML;
            this.FournisseursXML= FournisseursXML;
        }



        public void generateXML()
        {
            if (FournisseursXML.Count > 0)
            {

                MySqlConnection c2;
                string req2;
                List<List<object>> FournisseurActuel;


                //Creation du fichier xml et initialisation
                XmlDocument commandexml = new XmlDocument();
                XmlElement racine = commandexml.CreateElement("Commande");
                commandexml.AppendChild(racine);
                XmlDeclaration xmldecl = commandexml.CreateXmlDeclaration("1.0", "UTF-8", "no");
                commandexml.InsertBefore(xmldecl, racine);

                //Creation des élements
                XmlElement baliseFournisseur;
                XmlElement baliseNom;
                XmlElement baliseNumero;
                XmlElement baliseProduit;
                XmlElement baliseNomProd;
                XmlElement baliseQuantite;



                //Ajout des données
                MySqlConnection c = Tools.GetConnexion();

                foreach (KeyValuePair<string,string> fournisseur in FournisseursXML)
                {
                    baliseFournisseur = commandexml.CreateElement("fournisseur");                                           //Balise Fournisseur
                    racine.AppendChild(baliseFournisseur);


                    baliseNom = commandexml.CreateElement("Nom");                                                           //Balise nom
                    baliseNom.InnerText = fournisseur.Key;
                    baliseFournisseur.AppendChild(baliseNom);


                    baliseNumero = commandexml.CreateElement("Numero");                                                     //Balise NUmero
                    baliseNumero.InnerText = fournisseur.Value;
                    baliseFournisseur.AppendChild(baliseNumero);

                    foreach (List<object> produit in ProduitsXML)
                    {

                        c2 = Tools.GetConnexion();
                        req2 = "select Nom from fournisseur where idFournisseur=" + produit[7] + ";";

                        FournisseurActuel = Tools.Selection(req2, c);
                        c2.Close();

                        if (fournisseur.Key == FournisseurActuel[0][0].ToString())
                        {
                            baliseProduit = commandexml.CreateElement("Produit");                                               //Balise Produit
                            baliseFournisseur.AppendChild(baliseProduit);

                            baliseNomProd = commandexml.CreateElement("Nom");                                                   //Balise Nom du produit
                            baliseNomProd.InnerText = produit[1].ToString();
                            baliseProduit.AppendChild(baliseNomProd);

                            baliseQuantite = commandexml.CreateElement("Quantite");                                             //Balise Quantite
                            baliseQuantite.InnerText = (Convert.ToInt32(produit[5]) - Convert.ToInt32(produit[6])).ToString();   //QuantiteMax-QuantiteActuelle
                            baliseQuantite.SetAttribute("Unite", produit[3].ToString());                                        //On ajoute un attribut Unite a la balise Quantite
                            baliseProduit.AppendChild(baliseQuantite);

                        }

                    }
                    


                }
                c.Close();

                commandexml.Save("Commande_"+DateTime.Now.ToString("ddmmyyyy") +DateTime.Now.Hour.ToString()+ ".xml");

            }
            else
            {
                MessageBox.Show("Il n'y a aucun produit à commander");
            }
           



        }
    }
}
