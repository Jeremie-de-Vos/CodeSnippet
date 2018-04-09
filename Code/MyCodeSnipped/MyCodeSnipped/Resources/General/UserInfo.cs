using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MyCodeSnipped.Resources.General.Database;
using System.Windows;

namespace MyCodeSnipped.Resources.General
{
    class UserInfo
    {
        internal static userinf Userinformation;
        internal static void SetUserInfo(int ID)
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
                    Userinformation = new userinf(ID,reader["Firstname"].ToString(), reader["Middlename"].ToString(), reader["Lastname"].ToString(), reader["Email"].ToString());            
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
    }
}
class userinf
{
    internal int ID;
    internal string firstname;
    internal string middlename;
    internal string lastname;
    internal string email;

    public userinf(int _ID,string _firstname,string _middlename,string _lastname,string _email)
    {
        ID = _ID;
        firstname = _firstname;
        middlename = _middlename;
        lastname = _lastname;
        email = _email;
    }
}
