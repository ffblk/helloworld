using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class MyConnection
    {
        private static OleDbConnection conn;
        public static string siteDir = HttpContext.Current.Server.MapPath(@"\");
        public static OleDbConnection GetConnection()
        {
            if (conn == null)
            {
                string siteDir = HttpContext.Current.Server.MapPath(@"\");
                conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
       siteDir + @"App_Data\Jobs.mdb");
                conn.Open();
            }
            return conn;
        }
        public static OleDbConnection GetConnection(string nameDB)
        {
            if (conn == null)
            {
                string siteDir = HttpContext.Current.Server.MapPath(@"\");
                conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
       siteDir + @"App_Data\"+nameDB);
                conn.Open();
            }
            return conn;
        }
    }
}