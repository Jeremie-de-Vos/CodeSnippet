using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.Database.Internal
{
    public class DbCodeLanguage
    {
        //Get all Programming Languages in Database
        public static List<string> GetallLanguages()
        {
            //Setup a temp list
            List<string> Temp = new List<string>();

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `Name` FROM `proglanguage`";

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //if match is found
            while (reader.Read())
                Temp.Add(reader["Name"].ToString());

            //Return The temp list
            return Temp;
        }
        //Convert a Language Name To a ID from Database
        public static int ToID(string LanguageName)
        {

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`, `Name` FROM `proglanguage` WHERE `Name` = @Name";
            cmd.Parameters.AddWithValue("@Name", LanguageName);

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //if match is found
            if (reader.Read())
                return int.Parse(reader["TagName"].ToString());
            else
                return 0;
        }
        //Convert a Language ID To a Programming Language from Database
        public static string ToString(int ID)
        {

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`, `Name` FROM `proglanguage` WHERE `ID` = @ID";
            cmd.Parameters.AddWithValue("@ID", ID);

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //if match is found
            if (reader.Read())
                return reader["TagName"].ToString();
            else
                return "";
        }
    }
}
