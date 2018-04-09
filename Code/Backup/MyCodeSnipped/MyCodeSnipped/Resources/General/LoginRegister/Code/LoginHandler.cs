using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyCodeSnipped.Resources.

namespace MyCodeSnipped.Code.Login_Register
{
    class LoginHandler
    {
        private static List<LoginDB> DB_Info = new List<LoginDB>();
        internal static string loggedinName = string.Empty;
        internal static int loggedinID;

        internal static void LoginNow(string Username, string Password)
        {
            //Loading tables
            LoadTables();
            bool match = false;
            int MatchID = 0;

            for (int i = 0; i < DB_Info.Count; i++)
            {
                if (!match)
                {
                    //Build relations
                    List<DBrelation> Relations = new List<DBrelation>
                    {
                        new DBrelation(Username, DB_Info[i].UsernameField),
                        new DBrelation(Password, DB_Info[i].PasswordField)
                    };

                    //create connection and open it
                    MySqlConnection connection = DbInfo.Connection();

                    //try to connect to database
                    try
                    {
                        //Build Mysql command
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + (DB_Info[i].TableName) + " WHERE " + (WHERE_builder(Relations)), connection);

                        //Get ID 
                        MySqlCommand id_cmd = connection.CreateCommand();
                        id_cmd.CommandText =
                            "SELECT `" + DB_Info[i].IDfieldname +
                            "` FROM `" + DB_Info[i].TableName +
                            "` WHERE `" + DB_Info[i].UsernameField + "` = '" + Username +
                            "' AND `" + DB_Info[i].PasswordField + "` = '" + Password + "'";

                        MySqlDataReader reader = id_cmd.ExecuteReader();


                        //if match is found
                        if (reader.Read())
                        {
                            //Set match info
                            match = true;
                            MatchID = int.Parse(reader[DB_Info[i].IDfieldname].ToString());

                            MessageBox.Show("Table: " + DB_Info[i].TableName + "\n Id: " + MatchID);

                            DB_Info[i].MatchID = MatchID;
                            loggedinID = MatchID;
                            UserInfo.SetUserInfo(MatchID);
                            OpenForm(DB_Info[i]);
                            break;
                        }
                    }
                    //finally
                    finally
                    {
                        //check state and clone
                        if (connection.State == ConnectionState.Open)
                            connection.Clone();
                    }
                }
                else
                    MessageBox.Show("Table: " + DB_Info[i].TableName + "\n Id: " + MatchID);
            }
            //If there is no match found in any of the loaded tables
            if (!match)
                MessageBox.Show("There was no match found in the following tables: \n" + LoadedTables_ToString());
        }
        private static void LoadTables()
        {
            //clear list first
            DB_Info.Clear();

            //new table
            MainWindow mainwindows = new MainWindow();
            DB_Info.Add(new LoginDB("users", mainwindows, "ID", "Firstname", "Password"));

        }

        private static void OpenForm(LoginDB Info)
        {
            switch (Info.WinodowToOpen)
            {
                case MainWindow main:
                    MainWindow k = new MainWindow();
                    k.Show();
                    break;
            }
        }


        private static string WHERE_builder(List<DBrelation> list)
        {
            string sentence = "";

            for (int i = 0; i < list.Count; i++)
            {
                //Add fieldname
                sentence += "`" + list[i].fieldname + "` = ";
                sentence += "`" + list[i].variable + "`";

                //AND if not final item of the list
                if (i < list.Count)
                    sentence += " AND ";
            }
            return sentence;
        }
        private static string LoadedTables_ToString()
        {
            string sentence = string.Empty;
            for (int i = 0; i < DB_Info.Count; i++)
            {
                //Add Table names
                sentence += "- " + DB_Info[i].TableName;

                //Next Line
                if (i < DB_Info.Count)
                    sentence += "\n";
            }
            return sentence;
        }
    }
}
class LoginDB
{
    //Db Info
    internal string TableName;

    internal string IDfieldname;
    internal string UsernameField;
    internal string PasswordField;
    internal int MatchID;

    //Final Info
    internal Window WinodowToOpen;

    public LoginDB(string _TableName, Window _WindowToOpen, string _IDfieldname, string _UsernameField, string _PasswordField)
    {
        TableName = _TableName;
        WinodowToOpen = _WindowToOpen;

        IDfieldname = _IDfieldname;
        UsernameField = _UsernameField;
        PasswordField = _PasswordField;
    }
}
class DBrelation
{
    internal string variable;
    internal string fieldname;

    public DBrelation(string _variable, string _fieldname)
    {
        this.variable = _variable;
        this.fieldname = _fieldname;
    }
}
