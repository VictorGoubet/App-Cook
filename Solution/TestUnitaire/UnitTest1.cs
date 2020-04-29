using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Cook.View
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConnexionBDD()
        {

            MySqlConnection res = Tools.GetConnexion();
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void TestSelectionBDD()
        {
            MySqlConnection c = Tools.GetConnexion();
            string req = "select * from client;";
            List<List<object>> res = Tools.Selection(req,c);
            Assert.IsNotNull(res);
        }
    }
}
