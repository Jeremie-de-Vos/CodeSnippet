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

namespace CodeSnippet.WPF.FrontEnd.Windows.Pages
{
    /// <summary>
    /// Interaction logic for SnippetsPage.xaml
    /// </summary>
    public partial class SnippetsPage : UserControl
    {

        public SnippetsPage()
        {
            InitializeComponent();
            MainContainer.Height = this.Height;
            ViewMode = false;
        }

        private bool _ViewMode;
        public bool ViewMode
        {
            get { return _ViewMode; }
            set
            {
                _ViewMode = value;
                if (_ViewMode)
                {
                    New.Visibility = Visibility.Visible;
                    New.Content = "Create New";
                    Action.Content = "Apply";
                    Delete.Visibility = Visibility.Visible;
                    Save.Content = "Save";
                }
                else
                {
                    New.Visibility = Visibility.Collapsed;
                    Action.Content = "Clear";
                    Delete.Visibility = Visibility.Collapsed;
                    Save.Content = "Save as New";
                }
            }
        }
    }
}
