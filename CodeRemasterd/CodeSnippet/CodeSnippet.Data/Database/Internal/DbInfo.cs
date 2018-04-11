using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.Database.Internal
{
    public class DbInfo
    {
        //-------------------------DatabaseInfo------------------------------
        //Database-Variable
        private static string datasource = "localhost";
        private static string username = "root";
        private static string password = "";
        private static string database = "mycodesnippet";
        private static string ConString = "datasource = " + datasource + "; username = " + username + "; password=" + password + "; database = " + database;


        //-------------------------Connection------------------------------
        //Create a new connection for this database
        public static MySqlConnection Connection()
        {
            MySqlConnection connection = new MySqlConnection(ConString);
            connection.Open();

            return connection;
        }

        //Get fullname From ID
        public static string FullName(int id)
        {
            //create connection and open it
            MySqlConnection connection = new MySqlConnection(ConString);
            connection.Open();

            //try to connect to database
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT `voornaam`, `tussenvoegsel`, `achternaam` FROM `klanten` WHERE `klant_id`=" + id + "";
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    return reader["voornaam"] + " " + reader["tussenvoegsel"] + " " + reader["achternaam"].ToString();
                else
                    return "no match";
            }
            //catch exceptions
            catch (Exception)
            {
                throw;
            }
        }
    }
}
