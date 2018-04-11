using CodeSnippet.Data.Database.Internal;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace CodeSnippet.Data.Database.External
{
    public class GetDbInfo
    {
        //-------------------------Get-------------------------------
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


        //-------------------------Status------------------------------
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


        //-------------------------CRUD--------------------------------
        //Add new Database
        public static void AddNewDatabase(DatabaseInfo Databaseinfo)
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
                    cmd.CommandText = "INSERT INTO `databases`(`ID`, `Datasource`, `Username`, `Password`, `Databasename`) " +
                        "VALUES (@ID,@Datasource,@Username,@Password,@Databasename)";

                    //Set Parameters
                    cmd.Parameters.AddWithValue("@ID", "");
                    cmd.Parameters.AddWithValue("@Datasource", Databaseinfo.DataSource);
                    cmd.Parameters.AddWithValue("@Username", Databaseinfo.Username);
                    cmd.Parameters.AddWithValue("@Password", Databaseinfo.Password);
                    cmd.Parameters.AddWithValue("@Databasename", Databaseinfo.DatabaseName);

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
        //Update new Database
        public static void UpdateDatabase(DatabaseInfo Databaseinfo)
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
                    cmd.CommandText = "UPDATE `databases` SET " +
                        "`Datasource`=[value-2]," +
                        "`Username`=[value-3]," +
                        "`Password`=[value-4]," +
                        "`Databasename`=[value-5]" +
                        " WHERE `ID`=@ID";

                    //Set Parameters
                    cmd.Parameters.AddWithValue("@ID", Databaseinfo.ID);
                    cmd.Parameters.AddWithValue("@Datasource", Databaseinfo.DataSource);
                    cmd.Parameters.AddWithValue("@Username", Databaseinfo.Username);
                    cmd.Parameters.AddWithValue("@Password", Databaseinfo.Password);
                    cmd.Parameters.AddWithValue("@Databasename", Databaseinfo.DatabaseName);

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
        //Delete new Database
        public static void DeleteDatabase(int ID)
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
                    cmd.CommandText = "DELETE FROM `databases` WHERE `ID` = @ID";

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
    //------Enum-ClassInfo-------
    public enum DBStatus
    {
        Error,
        Oke
    }
    public class DatabaseInfo
    {
        public int ID;
        public string DataSource;
        public string Username;
        public string Password;
        public string DatabaseName;

        public DatabaseInfo(int _ID, string _DataSource, string _Username, string _Password, string _DatabaseName)
        {
            ID = _ID;
            DataSource = _DataSource;
            Username = _Username;
            Password = _Password;
            DatabaseName = _DatabaseName;
        }
    }
}