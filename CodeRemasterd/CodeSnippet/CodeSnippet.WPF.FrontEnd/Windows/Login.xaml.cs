using CodeSnippet.Data.General;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            Control[] c = {LoginName_txt,Password_txt};
            if (ControlState.Execute(c, ControlStateVisuals.Colored))
                LoginHandler.LoginNow(LoginName_txt.Text, Password_txt.Text, this);
        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            Register wd = new Register();
            wd.Show();
            this.Close();
        }
    }
}
