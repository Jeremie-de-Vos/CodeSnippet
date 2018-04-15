using CodeSnippet.Data;
using CodeSnippet.Data.Converter;
using CodeSnippet.Data.Database.Internal;
using CodeSnippet.WPF.FrontEnd.Windows.Items;
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

namespace CodeSnippet.WPF.FrontEnd.Windows.NavigationBars
{
    /// <summary>
    /// Interaction logic for NavBarSnippet.xaml
    /// </summary>
    public partial class NavBarSnippet : UserControl
    {
        bool startup = false;
        SnippetsPage Page;

        public NavBarSnippet(SnippetsPage page)
        {
            InitializeComponent();
            Page = page;

            SetUI.DatesToCombobox(DateType);
            SetUI.CodeLanguageToCombobox(Language);
            SetUI.TypeToCombobox(SearchType);

            DateType.SelectedIndex = 0;
            SearchType.SelectedIndex = 0;
            Language.SelectedIndex = 0;
            startup = true;
        }

        //-------------------------Filters------------------------------
        //Cmb Selection changed
        private void DataeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startup)
                FilterCodeSnippeds();
        }
        private void Languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startup)
                FilterCodeSnippeds();
        }
        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startup)
                FilterCodeSnippeds();
        }
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                FilterCodeSnippeds();
        }

        //Filter all the CodeSnippeds by the asigned Values
        private void FilterCodeSnippeds()
        {
            var bc = new BrushConverter();

            //Give all filter values and recieve a list with Items
            List<SnippetInfo> snippets = DbSnippets.GetFilteredSnippeds(
            SearchBox.Text,
            Language.SelectedItem.ToString(),
            Converter.StringToDateFilter(DateType.SelectedItem.ToString()),
            Converter.StringToTypefilter(SearchType.SelectedItem.ToString())
            );

            List<SnippetUI> items = new List<SnippetUI>();
            for (int i = 0; i < snippets.Count; i++)
                items.Add(new SnippetUI(snippets[i]._Name, DbCodeLanguage.ToString(snippets[i]._LanguageID)));

            Page.Containerr.Children.Clear();
            foreach (SnippetInfo i in snippets)
            {
                SnippetItem item = new SnippetItem(i, Page);
                item.Width = Page.Containerr.Width;
                Page.Containerr.Children.Add(item);
            }
        }
    }
}
