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
        public int ToID(string LanguageName)
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
    }
}
