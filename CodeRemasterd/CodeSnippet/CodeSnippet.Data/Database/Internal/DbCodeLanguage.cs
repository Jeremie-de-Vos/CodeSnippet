using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.Database.Internal
{
    public class DbCodeLanguage
    {
        //Get all Programming Languages in Database
        public static List<CodeLaguageInfo> GetallLanguages()
        {
            //Setup a temp list
            List<CodeLaguageInfo> Temp = new List<CodeLaguageInfo>();

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`,`Name` FROM `proglanguage`";

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //if match is found
            while (reader.Read())
                Temp.Add(new CodeLaguageInfo(int.Parse(reader["Name"].ToString()),reader["Name"].ToString()));

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
                return int.Parse(reader["ID"].ToString());
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
                return reader["Name"].ToString();
            else
                return "";
        }


        //-------------------------CRUD------------------------------
        //Add new CodeLanguage
        public static void AddNewCodeLanguage(CodeLaguageInfo Languageinfo)
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
                    cmd.CommandText = "INSERT INTO `proglanguage`(`ID`, `Name`) VALUES (@ID, @Name)";

                    //Set Parameters
                    cmd.Parameters.AddWithValue("@ID", "");
                    cmd.Parameters.AddWithValue("@Name", Languageinfo.Name);

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
        //Update new CodeLanguage
        public static void UpdateCodeLanguage(CodeLaguageInfo Languageinfo)
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
                    cmd.CommandText = "UPDATE `proglanguage` SET `Name`=@Name WHERE `ID`=@ID,";

                    //Set Parameters
                    cmd.Parameters.AddWithValue("@ID", Languageinfo.ID);
                    cmd.Parameters.AddWithValue("@Name", Languageinfo.Name);

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
        //Delete new CodeLanguage
        public static void DeleteCodeLanguage(int ID)
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
                    cmd.CommandText = "DELETE FROM `proglanguage` WHERE `ID` = @ID";

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
public class CodeLaguageInfo
{
    public int ID;
    public string Name;
    public CodeLaguageInfo(int _ID, string _Name)
    {
        ID = _ID;
        Name = _Name;
    }
}
