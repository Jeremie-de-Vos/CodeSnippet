using CodeSnippet.Data.Database.Internal;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;
using CodeSnippet.WPF.FrontEnd.Windows;

namespace CodeSnippet.WPF.FrontEnd
{
    public class LoginHandler
    {
        //Variable
        private static List<LoginDB> DB_Info = new List<LoginDB>();

        //-------------------------Main-Executer-------------------------
        //Login-Executer
        public static void LoginNow(string Username, string Password, Window loginform)
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
                    MySqlConnection connection = Data.Database.Internal.DbInfo.Connection();

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

                            //MessageBox.Show("Table: " + DB_Info[i].TableName + "\n Id: " + MatchID);

                            DB_Info[i].MatchID = MatchID;

                            //set userinfo
                            UserInfo.SetUserInfo(MatchID);
                            //open form
                            OpenForm(DB_Info[i]);
                            break;
                        }
                    }
                    //finally
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                    MessageBox.Show("Table: " + DB_Info[i].TableName + "\n Id: " + MatchID);
            }
            //If there is no match found in any of the loaded tables
            if (!match)
                MessageBox.Show("There was no match found in the following tables: \n" + LoadedTables_ToString());
        }

        
        //-------------------------LoadingData------------------------------
        //Add new table for rolplay based system
        private static void LoadTables()
        {
            //clear list first
            DB_Info.Clear();

            //new table
            MainView mainwindows = new MainView();
            DB_Info.Add(new LoginDB("users", mainwindows, "ID", "Firstname", "Password"));

        }
        //Add the Form Related to a Table For rolplay based
        private static void OpenForm(LoginDB Info)
        {
            switch (Info.WinodowToOpen)
            {
                case MainView main:
                    MainView k = new MainView();
                    k.Show();
                    break;
            }
        }


        //-------------------------Builders------------------------------
        //Where Builder Builds a where string related to the table that is being checked
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
        //Get all Loaded Tables if there was no table found
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
//------Enum-ClassInfo-------
public class LoginDB
{
    //Db Info
    public string TableName;

    public string IDfieldname;
    public string UsernameField;
    public string PasswordField;
    public int MatchID;

    //Final Info
    public Window WinodowToOpen;

    public LoginDB(string _TableName, Window _WindowToOpen, string _IDfieldname, string _UsernameField, string _PasswordField)
    {
        TableName = _TableName;
        WinodowToOpen = _WindowToOpen;

        IDfieldname = _IDfieldname;
        UsernameField = _UsernameField;
        PasswordField = _PasswordField;
    }
}
public class DBrelation
{
    public string variable;
    public string fieldname;

    public DBrelation(string _variable, string _fieldname)
    {
        this.variable = _variable;
        this.fieldname = _fieldname;
    }
}