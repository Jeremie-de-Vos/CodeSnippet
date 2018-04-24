using CodeSnippet.Data;
using CodeSnippet.Data.Database.Internal;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeSnippet.WPF.FrontEnd.Windows.Items
{
    /// <summary>
    /// Interaction logic for SnippetItem.xaml
    /// </summary>
    public partial class SnippetItem : UserControl
    {
        SnippetInfo Info;
        SnippetsPage Page;
        NavBarSnippet Navbar;

        //Main
        public SnippetItem(SnippetInfo info, SnippetsPage page, NavBarSnippet navbar)
        {
            InitializeComponent();

            Info = info;
            Page = page;

            Name.Content = info._Name;
            Language.Content = DbCodeLanguage.ToString(info._LanguageID);
            CreateDate.Content = info._CreateDate;
            Navbar = navbar;
        }
        //View-Button-Click
        private void View_Click(object sender, RoutedEventArgs e)
        {
            //Set Code,Usage,Name,Description enz....
            Page.Code.Document.Blocks.Clear();
            Page.Code.Document.Blocks.Add(new Paragraph(new Run(Info._Code)));

            Page.Description.Document.Blocks.Clear();
            Page.Description.Document.Blocks.Add(new Paragraph(new Run(Info._Description)));

            Page.Usage.Document.Blocks.Clear();
            Page.Usage.Document.Blocks.Add(new Paragraph(new Run(Info._UsageExample)));

            Page.Name.Text = Info._Name;
            Page.Language.Items.Clear();
            SetUI.CodeLanguageToCombobox(Page.Language);
            Page.Language.SelectedItem = DbCodeLanguage.ToString(Info._LanguageID);
                
            Page.ViewMode = true;
            Page.currentsnippet = Info;
            Page.Nav = Navbar;
        }
    }
}
