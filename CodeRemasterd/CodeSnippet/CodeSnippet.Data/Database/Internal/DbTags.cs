using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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



        //-------------------------CRUD------------------------------
        //Add new Tag
        public static void AddNewTag(TagInfo taginfo)
        {
            //Create Connection
            using (MySqlConnection connection = DbInfo.Connection())
            {
                //Create cmd
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    
                    //Create CommandText
                    cmd.CommandText = "INSERT INTO `tags`(`ID`, `TagName`) VALUES (@ID, @Name)";

                    //Set Parameters
                    cmd.Parameters.AddWithValue("@ID", "");
                    cmd.Parameters.AddWithValue("@Name", taginfo.Name);

                    try
                    {
                        int recordsAffected = cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        //Update new Tag
        public static void UpdateTag(TagInfo taginfo)
        {
            //Create Connection
            using (MySqlConnection connection = DbInfo.Connection())
            {
                //Create Cmd
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    //Create CommandText
                    cmd.CommandText = "UPDATE `tags` SET `TagName`=@Name WHERE `ID`=@ID";

                    //Set Parameters
                    cmd.Parameters.AddWithValue("@ID", taginfo.ID);
                    cmd.Parameters.AddWithValue("@Name", taginfo.Name);

                    try
                    {
                        int recordsAffected = cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        //Delete new Tag
        public static void DeleteTag(int ID)
        {
            //Create Connection
            using (MySqlConnection connection = DbInfo.Connection())
            {
                //Create Cmd
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    //Set CommandText
                    cmd.CommandText = "DELETE FROM `tags` WHERE `ID` = @ID";

                    //Add Parameters
                    cmd.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        int recordsAffected = cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
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
