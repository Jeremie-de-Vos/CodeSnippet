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
            DetailsContainer.Height = this.Height;
            MainContainer.MaxHeight = this.Height;
            MainContainer.MinHeight = this.Height;
        }
    }
}
