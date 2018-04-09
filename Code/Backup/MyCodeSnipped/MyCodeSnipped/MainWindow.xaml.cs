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
using MyCodeSnipped.Code;

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

            userinf userinf = UserInfo.Userinformation;
            //FullName_Lbl.Content = userinf.firstname + " " + userinf.middlename + " " + userinf.lastname;
            //Adress_Lbl.Content = userinf.email;

            //Set windows state so it fills the screen
            this.WindowState = WindowState.Maximized;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TagContainer.Visibility = Visibility.Collapsed;
            //TagContainer.SetZIndex(TagContainer, 999);

            //Collaps all Content in side menu
            Collaps(ProjectsContent);
            Collaps(MySnippedsContent);

            //Hide-Tab-Headers
            foreach (TabItem item in MainMenuTabControl.Items)
            {
                item.Visibility = Visibility.Collapsed;
            }

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

            //Set some tag examples
            for (int i = 0; i < 100; i++)
            {
                tags.Add(new Tags(i, "Example["+i+"]"));
            }
            TagLineAmount(8);
        }

        //Collapsed System
        private void Collaps(StackPanel Content)
        {
            if (Content.Visibility == Visibility.Collapsed)
                Content.Visibility = Visibility;
            else
                Content.Visibility = Visibility.Collapsed;
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
            b.BorderThickness = new Thickness(0,0,0,0);
            b.Background = (Brush)bc.ConvertFrom("#FF323232");
        }

        //Event handler
        private void Projects_btn_Click(object sender, RoutedEventArgs e)
        {
            Collaps(ProjectsContent);
        }
        private void MySnippeds_btn_Click(object sender, RoutedEventArgs e)
        {
            Collaps(MySnippedsContent);
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
        private void MyData_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuTabControl.SelectedIndex = 2;
        }
        private void OverviewProjects_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuTabControl.SelectedIndex = 3;
        }
        private void OverviewMySnippeds_btn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuTabControl.SelectedIndex = 4;
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
