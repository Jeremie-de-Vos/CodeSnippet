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

namespace MyCodeSnipped
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Main
        public MainWindow()
        {
            InitializeComponent();

            //Set windows state so it fills the screen
            this.WindowState = WindowState.Maximized;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Collaps all Content in side menu
            Collaps(ProjectsContent);
            Collaps(MySnippedsContent);

            //Hide-Tab-Headers
            foreach (TabItem item in MainMenuTabControl.Items)
            {
                item.Visibility = Visibility.Collapsed;
            }
        }

        //Collapsed System
        private void Collaps(StackPanel Content)
        {
            if (Content.Visibility == Visibility.Collapsed)
                Content.Visibility = Visibility;
            else
                Content.Visibility = Visibility.Collapsed;
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
    }
}
