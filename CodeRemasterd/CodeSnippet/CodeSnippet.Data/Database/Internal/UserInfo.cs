using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.Database.Internal
{
    public class UserInfo
    {
        //UserInformation that can be used for getting data
        public static UserInfoClass Userinformation;

        //Set all Userinformation with Id that is given by the LoginHandler Script
        public static void SetUserInfo(int ID)
        {
            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //try to connect to database
            try
            {
                //Build Mysql command
                MySqlCommand cmd = connection.CreateCommand();

                cmd.CommandText =
                    "SELECT `ID`, `Firstname`, `Middlename`, `Lastname`, `Email`, `Password`, `Pin` FROM `users` WHERE `ID`=" + ID;
                MySqlDataReader reader = cmd.ExecuteReader();


                //if match is found
                if (reader.Read())
                {
                    //MessageBox.Show(reader["Firstname"] + " "+ reader["Middlename"].ToString());
                    Userinformation = new UserInfoClass(ID, reader["Firstname"].ToString(), reader["Middlename"].ToString(), reader["Lastname"].ToString(), reader["Email"].ToString());
                }
            }
            //finally
            finally
            {
                connection.Close();
            }
        }
    }
}
public class UserInfoClass
{
    public int ID;
    public string firstname;
    public string middlename;
    public string lastname;
    public string email;

    public UserInfoClass(int _ID, string _firstname, string _middlename, string _lastname, string _email)
    {
        ID = _ID;
        firstname = _firstname;
        middlename = _middlename;
        lastname = _lastname;
        email = _email;
    }
}
