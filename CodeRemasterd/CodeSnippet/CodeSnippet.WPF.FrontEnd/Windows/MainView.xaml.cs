using CodeSnippet.WPF.FrontEnd.Windows.NavigationBars;
using CodeSnippet.WPF.FrontEnd.Windows.Pages;
using System.Windows;


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
            Contentt.Children.Clear();
            NavigationBar.Children.Clear();

            SnippetsPage snip = new SnippetsPage();
            Contentt.Children.Add(snip);
            snip.Width = Contentt.Width;
            snip.Height = Contentt.Height;

            NavBarSnippet nav = new NavBarSnippet(snip);
            NavigationBar.Children.Add(nav);
        }

        private void NavProjects_Click(object sender, RoutedEventArgs e)
        {
            Contentt.Children.Clear();
            NavigationBar.Children.Clear();

            ProjectsPage page = new ProjectsPage();
            Contentt.Children.Add(page);
            page.Width = Contentt.Width;
            page.Height = Contentt.Height;
        }


        //Set User name information Example: Name, Email
    }
}
