using MySql.Data.MySqlClient;
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
using MyCodeSnipped.Resources.General.Database;
using System.Data;
using System.Data.SqlClient;

namespace MyCodeSnipped.Resources.General
{
    /// <summary>
    /// Interaction logic for AddDatabase.xaml
    /// </summary>
    public partial class AddDatabase : Window
    {
        //Main
        public AddDatabase()
        {
            InitializeComponent();
        }

        //Close window to go back
        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Add to db
        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            WriteToDB();
        }

        //Write to database
        private void WriteToDB()
        {
            //All Contorls
            List<Control_> controls = new List<Control_>
            {
                new Control_(DatabasName_txt, Visuals.Colored),
                new Control_(DataSource_txt, Visuals.Colored),
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
                            "INSERT INTO `databases`(`ID`, `Datasource`, `Username`, `Password`, `Databasename`) " +
                            "VALUES (@ID,@DataSource,@Username,@Password,@DatabasName)";

                        command.Parameters.AddWithValue("@ID", "");
                        command.Parameters.AddWithValue("@DatabasName", DatabasName_txt.Text);
                        command.Parameters.AddWithValue("@DataSource", DataSource_txt.Text);
                        command.Parameters.AddWithValue("@Username", Username_txt.Text);
                        command.Parameters.AddWithValue("@Password", Password_txt.Text);

                        try
                        {
                            //connection.Open();
                            int recordsAffected = command.ExecuteNonQuery();
                            MessageBox.Show("Database has been added!");
                            this.Close();
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

    }
}
