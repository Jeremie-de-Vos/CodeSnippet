using MyCodeSnipped.Resources.General;
using MyCodeSnipped.Resources.General.Database;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyCodeSnipped.Resources.Pages
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class Database : Page
    {
        public Database()
        {
            InitializeComponent();
        }

        //Selected Item changed
        private void DB_filterType_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DB_filterType_cmb.SelectedIndex == 1)
                DB_TableFilter_cmb.Visibility = Visibility.Visible;
            else
                DB_TableFilter_cmb.Visibility = Visibility.Collapsed;
        }
        //Databse comboBox changed
        private void DB_Databases_Filter_cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (DB_Databases_Filter_cmb.Items.Count > 0)
                //SetTables();
        }
        //Add new database
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddDatabase wd = new AddDatabase
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            wd.Show();
        }
        //Refresh the database ComboBox
        private void refresh_btn_Click(object sender, RoutedEventArgs e)
        {
            //SetupDatabases();
            DbGetinfo.SetDatabaseStatus(Db_status_container);
        }
    }
}
