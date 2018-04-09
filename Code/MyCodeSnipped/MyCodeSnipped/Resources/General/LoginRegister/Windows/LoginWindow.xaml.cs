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
using MyCodeSnipped.Resources.General.LoginRegister.Code;
using MyCodeSnipped.Resources.General.LoginRegister.Windows;

namespace MyCodeSnipped.Resources.General.LoginRegister.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            //All Contorls
            List<Control_> controls = new List<Control_>
            {
                new Control_(LoginName_txt, Visuals.Colored),
                new Control_(Password_txt, Visuals.Colored)
            };

            //If all fields are filled in
            if (ControlState.Execute(controls, Visuals.Colored))
            {
                LoginHandler.LoginNow(LoginName_txt.Text, Password_txt.Text, this);
                this.Close();
            }
        }

        private void Register_btn_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow wd = new RegisterWindow();
            wd.Show();
            this.Close();
        }
    }
}