using CodeSnippet.Data.Database.Internal;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace CodeSnippet.Data.Database.External
{
    public class GetDbInfo
    {
        //Get table names | Using DB name
        public static List<string> GetTableNames(string DBName)
        {
            using (MySqlConnection conn = CreateDBConnection(DBName))
            {
                if (conn != null)
                    if (conn.State == ConnectionState.Open)
                        return conn.GetSchema("Tables").AsEnumerable().Select(s => s[2].ToString()).ToList();
            }
            //if all failed
            return new List<string>();
        }
        //Get all Databases | Using DB name
        public static List<string> GetAllDatabases()
        {
            //Temp list
            List<string> temp = new List<string>();

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Create command
            MySqlCommand id_cmd = connection.CreateCommand();
            id_cmd.CommandText =
                "SELECT `ID`, `Datasource`, `Username`, `Password`, `Databasename` FROM `databases`";

            //Create reader
            MySqlDataReader reader = id_cmd.ExecuteReader();

            //While reading
            while (reader.Read())
                temp.Add(reader["Databasename"].ToString());

            return temp;
        }

        //Get database Status
        public static DBStatus SetDatabaseStatus(string DBName)
        {
            if (CreateDBConnection(DBName) == null)
                return DBStatus.Error;
            else
                return DBStatus.Oke;
        }
        //Create Database Connection | Using DB name
        public static MySqlConnection CreateDBConnection(string DBName)
        {
            string constring = "";

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            MySqlCommand id_cmd = connection.CreateCommand();
            id_cmd.CommandText =
                "SELECT `ID`, `Datasource`, `Username`, `Password`, `Databasename` FROM `databases` WHERE Databasename = @Databasename";
            id_cmd.Parameters.AddWithValue("@Databasename", DBName);

            MySqlDataReader reader = id_cmd.ExecuteReader();


            //if match is found
            if (reader.Read())
            {
                constring = "datasource = " + reader["Datasource"] + "; username = " + reader["Username"] + "; password=" + reader["Password"] + "; database = " + reader["Databasename"].ToString();

                //Create mysqlconnection
                MySqlConnection newcon = new MySqlConnection(constring);
                newcon.Open();
                return newcon;
            }
            else
            {
                //Return connection
                MySqlConnection nl = null;
                return nl;
            }
        }
    }
    public enum DBStatus
    {
        Error,
        Oke
    }
}