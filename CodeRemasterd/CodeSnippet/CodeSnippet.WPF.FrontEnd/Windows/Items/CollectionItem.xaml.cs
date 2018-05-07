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
    public partial class CollectionItem : UserControl
    {
        SnippetsPage Page;
        CollectionCompleteInfo Info;
        NavBarSnippet Nav;

        public CollectionItem(CollectionCompleteInfo info, SnippetsPage page, NavBarSnippet nav)
        {
            InitializeComponent();
            Info = info;
            Page = page;
            Nav = nav;

            //Set expand button
            Container.Visibility = Visibility.Collapsed;
            Expand.Content = "Expand";

            //Set default collection info
            Name.Content = Info.collectioninfo.Name;
            CreateDate.Content = Info.collectioninfo.CreateDate;

            //Set All Snippet Items
            Container.Children.Clear();
            foreach (SnippetInfo i in Info.snippets)
            {
                SnippetItem item = new SnippetItem(i, Page, Nav)
                {
                    Width = Container.Width
                };
                Container.Children.Add(item);
            }
        }

        private void Expand_Click(object sender, RoutedEventArgs e)
        {
            if (Container.Visibility == Visibility.Collapsed)
            {
                Container.Visibility = Visibility.Visible;
                Expand.Content = "Collaps";
            }
            else
            {
                Container.Visibility = Visibility.Collapsed;
                Expand.Content = "Expand";
            }
        }
    }
}
