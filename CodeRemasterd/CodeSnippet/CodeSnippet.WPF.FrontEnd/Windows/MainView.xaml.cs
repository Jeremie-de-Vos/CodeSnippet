using CodeSnippet.WPF.FrontEnd.Windows.NavigationBars;
using CodeSnippet.WPF.FrontEnd.Windows.Pages;
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

namespace CodeSnippet.WPF.FrontEnd.Windows
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        private void NavSnippet_Click(object sender, RoutedEventArgs e)
        {
            SnippetsPage snip = new SnippetsPage();
            Contentt.Children.Add(snip);
            snip.Width = Contentt.Width;
            snip.Height = Contentt.Height;

            NavBarSnippet nav = new NavBarSnippet(snip);
            NavigationBar.Children.Add(nav);
        }


        //Set User name information Example: Name, Email
    }
}
