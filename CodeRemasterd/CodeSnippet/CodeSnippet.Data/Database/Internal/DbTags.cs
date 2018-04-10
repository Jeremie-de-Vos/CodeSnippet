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
        public static List<TagInfo> GetAllTags()
        {
            //Create temp List
            List<TagInfo> Temp = new List<TagInfo>();

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`, `TagName` FROM `tags`";

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //While reading
            while (reader.Read())
                Temp.Add(new TagInfo(int.Parse(reader["ID"].ToString()), reader["TagName"].ToString()));

            return Temp;
        }

        //Get all tags related to snipped ID
    }
}
public class TagInfo
{
    public int ID;
    public string Name;
    public TagInfo(int _ID, string _Name)
    {
        ID = _ID;
        Name = _Name;
    }
}
