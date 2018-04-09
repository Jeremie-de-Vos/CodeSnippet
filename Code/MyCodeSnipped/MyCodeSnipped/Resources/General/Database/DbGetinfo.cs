using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;


namespace MyCodeSnipped.Resources.General.Database
{
    class DbGetinfo
    {
        //Get table names | Using DB name
        internal static List<string> GetTableNames(string DBName)
        {
            using (MySqlConnection conn = CreateDBConnection(DBName))
            {
                if (conn != null)
                    if (conn.State == ConnectionState.Open)
                        return conn.GetSchema("Tables").AsEnumerable().Select(s => s[2].ToString()).ToList();
                    else
                        MessageBox.Show("There is no vallid Connection string");
            }
            //if all failed
            return new List<string>();
        }
        //Get all Databases | Using DB name
        internal static List<string> GetAllDatabases()
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
        internal static void SetDatabaseStatus(StackPanel container)
        {
            container.Children.Clear();
            foreach (string i in GetAllDatabases())
                if (CreateDBConnection(i) == null)
                    DB_statusUI(i,"error",container);
            else
                    DB_statusUI(i,"Oke",container);
        }

        //Create UI To show status
        internal static void DB_statusUI(string dbName, string status, StackPanel container)
        {
            var bc = new BrushConverter();

            Canvas c = new Canvas();
            container.Children.Add(c);
            c.Height = 30;
            c.Margin = new Thickness(1, 1, 1, 1);
            c.Background = (System.Windows.Media.Brush)bc.ConvertFrom("#FF323232");

            Label l1 = new Label();
            c.Children.Add(l1);
            l1.HorizontalContentAlignment = HorizontalAlignment.Center;
            l1.VerticalContentAlignment = VerticalAlignment.Center;
            l1.HorizontalAlignment = HorizontalAlignment.Left;
            l1.VerticalAlignment = VerticalAlignment.Top;
            l1.Foreground = System.Windows.Media.Brushes.White;
            l1.Content = dbName;
            l1.FontSize = 11;
            l1.Width = 118;
            l1.Height = c.Height;

            Label statusl = new Label();
            c.Children.Add(statusl);
            statusl.HorizontalContentAlignment = HorizontalAlignment.Center;
            statusl.VerticalContentAlignment = VerticalAlignment.Center;
            statusl.HorizontalAlignment = HorizontalAlignment.Left;
            statusl.VerticalAlignment = VerticalAlignment.Top;
            statusl.SetValue(Canvas.LeftProperty, 118.0);
            statusl.Foreground = System.Windows.Media.Brushes.White;
            statusl.Content = status;
            statusl.FontSize = 11;
            statusl.Width = 80;
            statusl.Height = c.Height;
        }
        //Create Database Connection | Using DB name
        internal static MySqlConnection CreateDBConnection(string DBName)
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
}
