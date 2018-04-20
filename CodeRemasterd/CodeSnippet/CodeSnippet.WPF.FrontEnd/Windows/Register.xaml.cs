using CodeSnippet.Data.General;
using CodeSnippet.Data.LoginRegister;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            Login wd = new Login();
            wd.Show();
            this.Close();
        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            Control[] c = { FirstName_txt, MiddleName_txt, LastName_txt, Email_txt, Password_txt, PasswordSecond_txt};
            RegisterInfo info = new RegisterInfo(FirstName_txt.Text,MiddleName_txt.Text,LastName_txt.Text,Email_txt.Text,Password_txt.Text);

            if (ControlState.Execute(c, ControlStateVisuals.Colored))
               RegisterHandler.RegisterNow(info);
        }
    }
}
