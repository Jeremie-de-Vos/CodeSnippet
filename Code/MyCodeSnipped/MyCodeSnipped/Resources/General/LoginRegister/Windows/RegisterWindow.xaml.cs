using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyCodeSnipped.Resources.General.LoginRegister.Windows;
using MyCodeSnipped.Resources.General.Database;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using MyCodeSnipped.Resources.General;

namespace MyCodeSnipped.Resources.General.LoginRegister.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        //Main
        public RegisterWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        //Write to database
        private void RegisterNow()
        {
            //All Contorls
            List<Control_> controls = new List<Control_>
            {
                new Control_(FirstName_txt, Visuals.Colored),
                new Control_(MiddleName_txt, Visuals.Colored),
                new Control_(LastName_txt, Visuals.Colored),
                new Control_(Email_txt, Visuals.Colored),
                new Control_(Password_txt, Visuals.Colored),
                new Control_(PasswordSecond_txt, Visuals.Colored)
            };
            //If all fields are filled in
            if (ControlState.Execute(controls, Visuals.Colored))
            {
                using (MySqlConnection connection = DbInfo.Connection())
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText =
                            "INSERT INTO `users`(`ID`, `Firstname`, `Middlename`, `Lastname`, `Email`, `Password`, `Pin`) " +
                            "VALUES (@ID,@Firstname,@Middlename,@Lastname,@Email,@Password,@Pin)";

                        command.Parameters.AddWithValue("@ID", "");
                        command.Parameters.AddWithValue("@Firstname", FirstName_txt.Text);
                        command.Parameters.AddWithValue("@Middlename", MiddleName_txt.Text);
                        command.Parameters.AddWithValue("@Lastname", LastName_txt.Text);
                        command.Parameters.AddWithValue("@Email", Email_txt.Text);
                        command.Parameters.AddWithValue("@Password", Password_txt.Text);
                        command.Parameters.AddWithValue("@Pin", int.Parse("0"));

                        try
                        {
                            //connection.Open();
                            int recordsAffected = command.ExecuteNonQuery();
                            MessageBox.Show("person has added");
                        }
                        catch (SqlException)
                        {
                            throw;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }

        //Back to login
        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow wd = new LoginWindow();
            wd.Show();
            this.Close();
        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            RegisterNow();
        }
    }
}
