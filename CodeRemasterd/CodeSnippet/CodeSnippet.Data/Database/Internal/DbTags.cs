using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.Database.Internal
{
    public class DbTags
    {
        //Returns a list with all Tags in Database
        public List<string> GetAllTags()
        {
            //Create temp List
            List<string> Temp = new List<string>();

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `TagName` FROM `tags`";

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //While reading
            while (reader.Read())
                Temp.Add(reader["TagName"].ToString());

            return Temp;
        }

        //Get all tags related to snipped ID
    }
}
