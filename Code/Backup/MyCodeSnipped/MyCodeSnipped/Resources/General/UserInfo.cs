using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeSnipped.Code;
using MySql.Data.MySqlClient;
using MyCodeSnipped.Code.Databse;


namespace MyCodeSnipped.Code
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
                MySqlCommand cmd = new MySqlCommand("SELECT `ID`, `Firstname`, `Middlename`, `Lastname`, `Email`, `Password`, `Pin` FROM `users` WHERE `ID`="+ID, connection);

                //Get Username 
                MySqlCommand id_cmd = connection.CreateCommand();
                id_cmd.CommandText =
                    "SELECT SELECT `ID`, `Firstname`, `Middlename`, `Lastname`, `Email`, `Password`, `Pin` FROM `users` WHERE `ID`=" + ID;

                MySqlDataReader reader = id_cmd.ExecuteReader();


                //if match is found
                if (reader.Read())
                {
                    userinf i = new userinf(ID,reader["Firstname"].ToString(), reader["Middlename"].ToString(), reader["Lastname"].ToString(), reader["Email"].ToString());
                    
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
