using System;
using System.Collections.Generic;
using System.Data;
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
using MyCodeSnipped.Resources.General;
using MyCodeSnipped.Resources.General.Database;
using MyCodeSnipped.Resources.Pages;
using MySql.Data.MySqlClient;

namespace MyCodeSnipped
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tags> tags = new List<Tags>();

        //Main
        public MainWindow()
        {
            InitializeComponent();

            //Set windows state so it fills the screen
            this.WindowState = WindowState.Maximized;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TagContainer.Visibility = Visibility.Collapsed;

            //Collaps all Content in side menu
            Collaps(ProjectsContent);
            Collaps(MySnippedsContent);
            Collaps(MyDataContent);

            //Hide-Tab-Headers
            //foreach (TabItem item in MainMenuTabControl.Items)
                //item.Visibility = Visibility.Collapsed;

            //Set up UI Examples
            SetUIExamples();

            myProjects_container.Width = ProjectOverviewGrid.Width;
            ProjectOverview.Width = ProjectOverviewGrid.Width;
            ProjectOverview.Height = 300;
            

            MyprojectItem(myProjects_container);
            MessageBox.Show(this.Width + "  " + this.Height);
        }

        //Setup Userinfo
        internal void SetUserInfo()
        {
            userinf userinf = UserInfo.Userinformation;
            FullName_Lbl.Content = userinf.firstname + " " + userinf.middlename + " " + userinf.lastname.ToString();
            Adress_Lbl.Content = userinf.email;

            SetupDatabases();
        }
        //Setup UI Examples
        private void SetUIExamples()
        {
            //Add Some languages examples
            MySnipped_Languages_Cmb.Items.Add("All");
            MySnipped_Languages_Cmb.Items.Add("C#");
            MySnipped_Languages_Cmb.Items.Add("C++");
            MySnipped_Languages_Cmb.Items.Add("Phyton");
            MySnipped_Languages_Cmb.Items.Add("Html");
            MySnipped_Languages_Cmb.Items.Add("Css");
            MySnipped_Languages_Cmb.Items.Add("PHP");
            MySnipped_Languages_Cmb.SelectedIndex = 0;
            //Add Some Date examples
            MySnipped_Date_Cmb.Items.Add("New/Old");
            MySnipped_Date_Cmb.Items.Add("Old/New");
            MySnipped_Date_Cmb.SelectedIndex = 0;
            //Add Some Databasefilter Type examples
            DB_filterType_cmb.Items.Add("All");
            DB_filterType_cmb.Items.Add("Tables");
            DB_filterType_cmb.Items.Add("Fields");
            DB_filterType_cmb.Items.Add("Records");
            DB_filterType_cmb.SelectedIndex = 0;
            //Add Some Databasefilter Type examples
            DB_Databases_Filter_cmb.Items.Add("All");

            //Set some tag examples
            for (int i = 0; i < 100; i++)
            {
                tags.Add(new Tags(i, "Example[" + i + "]"));
            }
            TagLineAmount(8);
        }

        //Collaps Stackpanel System
        private void Collaps(StackPanel Content)
        {
            if (Content.Visibility == Visibility.Collapsed)
                Content.Visibility = Visibility;
            else
                Content.Visibility = Visibility.Collapsed;
        }
        //Create MyProjectItem
        private void MyprojectItem(StackPanel Container)
        {
            var bc = new BrushConverter();
            double labelwidth = Double.NaN;//auto
            int font = 14;
            int buttonwidth = 130;

            DockPanel d = new DockPanel();
            Container.Children.Add(d);
            d.Height = 40;
            d.Background = (System.Windows.Media.Brush)bc.ConvertFrom("#FF323232");
            d.Margin = new Thickness(1, 1, 1, 1);

            //Subject
            Label _name = new Label();
            d.Children.Add(_name);
            _name.FontSize = font;
            _name.Height = d.Height;
            _name.Width = labelwidth;
            _name.Content = "Project Name:";
            DockPanel.SetDock(_name, Dock.Left);
            _name.FontStyle = FontStyles.Italic;
            _name.FontWeight = FontWeights.Bold;
            _name.VerticalAlignment = VerticalAlignment.Center;
            _name.HorizontalAlignment = HorizontalAlignment.Left;
            _name.VerticalContentAlignment = VerticalAlignment.Center;
            _name.HorizontalContentAlignment = HorizontalAlignment.Center;
            _name.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FFF7F1F1");
            //Response
            Label name = new Label();
            d.Children.Add(name);
            name.FontSize = font;
            name.Height = d.Height;
            name.Width = labelwidth;
            name.Content = "example";
            DockPanel.SetDock(name, Dock.Left);
            name.VerticalAlignment = VerticalAlignment.Center;
            name.HorizontalAlignment = HorizontalAlignment.Left;
            name.VerticalContentAlignment = VerticalAlignment.Center;
            name.HorizontalContentAlignment = HorizontalAlignment.Center;
            name.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FFF7F1F1");

            //Subject
            Label _Create = new Label();
            d.Children.Add(_Create);
            _Create.FontSize = font;
            _Create.Height = d.Height;
            _Create.Width = labelwidth;
            _Create.Content = "Create:";
            DockPanel.SetDock(_Create, Dock.Left);
            _Create.FontStyle = FontStyles.Italic;
            _Create.FontWeight = FontWeights.Bold;
            _Create.VerticalAlignment = VerticalAlignment.Center;
            _Create.HorizontalAlignment = HorizontalAlignment.Left;
            _Create.VerticalContentAlignment = VerticalAlignment.Center;
            _Create.HorizontalContentAlignment = HorizontalAlignment.Center;
            _Create.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FFF7F1F1");
            //Response
            Label Create = new Label();
            d.Children.Add(Create);
            Create.FontSize = font;
            Create.Height = d.Height;
            Create.Width = labelwidth;
            Create.Content = "example";
            DockPanel.SetDock(Create, Dock.Left);
            Create.VerticalAlignment = VerticalAlignment.Center;
            Create.HorizontalAlignment = HorizontalAlignment.Left;
            Create.VerticalContentAlignment = VerticalAlignment.Center;
            Create.HorizontalContentAlignment = HorizontalAlignment.Center;
            Create.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FFF7F1F1");

            //Subject
            Label _LastEdit = new Label();
            d.Children.Add(_LastEdit);
            _LastEdit.FontSize = font;
            _LastEdit.Height = d.Height;
            _LastEdit.Width = labelwidth;
            _LastEdit.Content = "Project Name:";
            DockPanel.SetDock(_LastEdit, Dock.Left);
            _LastEdit.FontStyle = FontStyles.Italic;
            _LastEdit.FontWeight = FontWeights.Bold;
            _LastEdit.VerticalAlignment = VerticalAlignment.Center;
            _LastEdit.HorizontalAlignment = HorizontalAlignment.Left;
            _LastEdit.VerticalContentAlignment = VerticalAlignment.Center;
            _LastEdit.HorizontalContentAlignment = HorizontalAlignment.Center;
            _LastEdit.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FFF7F1F1");
            //Response
            Label LastEdit = new Label();
            d.Children.Add(LastEdit);
            LastEdit.FontSize = font;
            LastEdit.Height = d.Height;
            LastEdit.Width = labelwidth;
            LastEdit.Content = "example";
            DockPanel.SetDock(LastEdit, Dock.Left);
            LastEdit.VerticalAlignment = VerticalAlignment.Center;
            LastEdit.HorizontalAlignment = HorizontalAlignment.Left;
            LastEdit.VerticalContentAlignment = VerticalAlignment.Center;
            LastEdit.HorizontalContentAlignment = HorizontalAlignment.Center;
            LastEdit.Foreground = (System.Windows.Media.Brush)bc.ConvertFrom("#FFF7F1F1");


            //Open_btn
            Button Open_btn = new Button();
            d.Children.Add(Open_btn);
            Open_btn.Content = "Open";
            Open_btn.Width = buttonwidth;
            Open_btn.Background = (System.Windows.Media.Brush)bc.ConvertFrom("#FF222121");

        }

        //Main Subject Handlers
        private void Projects_btn_Click(object sender, RoutedEventArgs e)
        {
            Collaps(ProjectsContent);
        }
        private void MySnippeds_btn_Click(object sender, RoutedEventArgs e)
        {
            Collaps(MySnippedsContent);
        }
        private void MyData_Btn_Click(object sender, RoutedEventArgs e)
        {
            Collaps(MyDataContent);
        }

        //Change-tabs
        private void EditProfile_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuTabControl.SelectedIndex = 0;
        }
        private void Settings_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuTabControl.SelectedIndex = 1;
        }
        private void OverviewProjects_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuTabControl.SelectedIndex = 3;
        }
        private void OverviewMySnippeds_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuTabControl.SelectedIndex = 4;
        }
        private void Files_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuTabControl.SelectedIndex = 5;
        }
        private void Database_btn_Click(object sender, RoutedEventArgs e)
        {
            //MainMenuTabControl.SelectedIndex = 6;
            Database page = new Database();
            Content.Content = new Database();
        }


        //Create new-Tag UI
        private void createNewTagItem(string name)
        {
            int Tagheight = 30;
            var bc = new BrushConverter();

            //Create canvas
            Canvas c = new Canvas();
            TagContainer.Children.Add(c);
            c.Background = (Brush)bc.ConvertFrom("#FF323232");
            c.Margin = new Thickness(1, 1, 1, 1);
            c.Width = 100;
            c.Height = Tagheight;

            //Create Label
            Label l = new Label();
            c.Children.Add(l);
            l.HorizontalContentAlignment = HorizontalAlignment.Center;
            l.VerticalContentAlignment = VerticalAlignment.Center;
            l.HorizontalAlignment = HorizontalAlignment.Left;
            l.VerticalAlignment = VerticalAlignment.Top;
            l.Foreground = (Brush)bc.ConvertFrom("#FFF7F1F1");
            l.Content = "#" + name;
            l.FontSize = 11;
            l.Width = 80;
            l.Height = Tagheight;

            //Create Button
            Button b = new Button();
            c.Children.Add(b);
            b.Content = "+";
            b.Width = 20;
            b.Height = Tagheight;
            b.FontSize = 14;
            b.Foreground = (Brush)bc.ConvertFrom("#FFF7F1F1");
            b.BorderBrush = (Brush)bc.ConvertFrom("#FF707070");
            b.SetValue(Canvas.LeftProperty, 80.0);
            b.BorderThickness = new Thickness(0, 0, 0, 0);
            b.Background = (Brush)bc.ConvertFrom("#FF323232");
        }
        //Filter all the Tags
        private void TagFilter_txt_KeyUp(object sender, KeyEventArgs e)
        {
            TagContainer.Children.Clear();
            if (TagFilter_txt.Text != "")
            {
                TagContainer.Visibility = Visibility.Visible;
                for (int i = 0; i < tags.Count; i++)
                    if (tags[i].Name.ToLower().Contains(TagFilter_txt.Text.ToLower()))
                        createNewTagItem(tags[i].Name);
            }
            else
                TagContainer.Visibility = Visibility.Collapsed;
        }
        //Set Line Amount From Tags
        private void TagLineAmount(int amount)
        {
            TagContainer.MinWidth = ((100 + 2) * amount);
            TagContainer.Width = ((100 + 2) * amount);
            TagContainer.MaxWidth = ((100 + 2) * amount);
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
            if (DB_Databases_Filter_cmb.Items.Count > 0)
                SetTables();
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
            SetupDatabases();
            DbGetinfo.SetDatabaseStatus(Db_status_container);
        }


        //Set Database Tables to CMB
        private void SetTables()
        {
            DB_TableFilter_cmb.Items.Clear();
            DB_TableFilter_cmb.Items.Add("All Tables");

            foreach (string i in DbGetinfo.GetTableNames(DB_Databases_Filter_cmb.SelectedItem.ToString()))
                DB_TableFilter_cmb.Items.Add(i);
            DB_TableFilter_cmb.SelectedIndex = 0;
        }
        //Set Databases to CMB
        private void SetupDatabases()
        { 
            //Clear cmb
            DB_Databases_Filter_cmb.Items.Clear();
            List<string> temp = DbGetinfo.GetAllDatabases();


            if (temp.Count > 0)
                temp.Insert(0, "All Databases");
            else
                temp.Add("No Db Found");

            //Add all items
            foreach (string i in temp)
                DB_Databases_Filter_cmb.Items.Add(i);

            //Set selected item
            DB_Databases_Filter_cmb.SelectedIndex = 0;
        }
    }
}
class Tags
{
    internal int ID;
    internal string Name;

    public Tags(int id, string name)
    {
        ID = id;
        Name = name;
    }
}
