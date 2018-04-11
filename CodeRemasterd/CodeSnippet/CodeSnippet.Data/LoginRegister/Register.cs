using CodeSnippet.Data.Database.Internal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.LoginRegister
{
    public class Register
    {
        //Register a New User
        private void RegisterNow(RegisterInfo registerInfo)
        {
            using (MySqlConnection connection = DbInfo.Connection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "INSERT INTO `users`(`ID`, `Firstname`, `Middlename`, `Lastname`, `Email`, `Password`, `Pin`) " +
                        "VALUES (@ID,@Firstname,@Middlename,@Lastname,@Email,@Password,@Pin)";

                    cmd.Parameters.AddWithValue("@ID", "");
                    cmd.Parameters.AddWithValue("@Firstname", registerInfo.firstname);
                    cmd.Parameters.AddWithValue("@Middlename", registerInfo.middlename);
                    cmd.Parameters.AddWithValue("@Lastname", registerInfo.lastname);
                    cmd.Parameters.AddWithValue("@Email", registerInfo.email);
                    cmd.Parameters.AddWithValue("@Password", registerInfo.Password);
                    cmd.Parameters.AddWithValue("@Pin", int.Parse("0"));

                    try
                    {
                        //connection.Open();
                        int recordsAffected = cmd.ExecuteNonQuery();
                        //MessageBox.Show("person has added");
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
//------Enum-ClassInfo-------
public class RegisterInfo
{
    public string firstname;
    public string middlename;
    public string lastname;
    public string email;
    public string Password;

    public RegisterInfo(string _firstname, string _middlename, string _lastname, string _email, string _Password)
    {
        firstname = _firstname;
        middlename = _middlename;
        lastname = _lastname;
        email = _email;
        Password = _Password;
    }
}
