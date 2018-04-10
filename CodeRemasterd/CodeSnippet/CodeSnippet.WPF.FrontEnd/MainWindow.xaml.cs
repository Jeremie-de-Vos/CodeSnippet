using CodeSnippet.Data.Converter;
using CodeSnippet.Data.Database.External;
using CodeSnippet.Data.Database.Internal;
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

namespace CodeSnippet.WPF.FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Prefending startup errors
        bool startup = false;

        //Main
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            UserInfo.SetUserInfo(1);

            //You can use SetUI.Functionname <------------------------
            MySnipped_Languages_Cmb.Items.Add("All");
            foreach(string date in Converter.GetAllDateFilterToStringArray())
                MySnipped_Date_Cmb.Items.Add(date);
            foreach (string type in Converter.GetAllTypeFilterToStringArray())
                MySnipped_Type_Cmb.Items.Add(type);
            foreach (string type in DbCodeLanguage.GetallLanguages())
                MySnipped_Languages_Cmb.Items.Add(type);

            MySnipped_Date_Cmb.SelectedIndex = 0;
            MySnipped_Type_Cmb.SelectedIndex = 0;
            MySnipped_Languages_Cmb.SelectedIndex = 0;

            startup = true;
        }

        //TestButton Clicked
        private void Test_btn_Click(object sender, RoutedEventArgs e)
        {
            Field.Document.Blocks.Clear();
            //foreach (string i in Converter.GetAllDateFilterToStringArray())
            //Field.AppendText(Environment.NewLine+"- " + System.DateTime.Now.ToString());
        }
        //SearchBox if Enter is pressed
        private void SearchBox_Mysnipped_txb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                FilterCodeSnippeds();
        }

        //Cmb Selection changed
        private void MySnipped_Date_Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(startup)
                FilterCodeSnippeds();
        }
        private void MySnipped_Languages_Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startup)
                FilterCodeSnippeds();
        }
        private void MySnipped_Type_Cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (startup)
                FilterCodeSnippeds();
        }

        //Filter all the CodeSnippeds by the asigned Values
        private void FilterCodeSnippeds()
        {
            //Give all filter values
            List<SnippetInfo> snippets = DbSnippets.GetFilteredSnippeds(
            SearchBox_Mysnipped_txb.Text,
            MySnipped_Languages_Cmb.SelectedItem.ToString(),
            Converter.StringToDateFilter(MySnipped_Date_Cmb.SelectedItem.ToString()),
            Converter.StringToTypefilter(MySnipped_Type_Cmb.SelectedItem.ToString())
            );
            //Clear RichTextBox
            Results.Document.Blocks.Clear();
            //Forieach item show it in RichTextBox
            for (int i = 0; i < snippets.Count; i++)
                Results.AppendText(Environment.NewLine + "- " + snippets[i]._Name + " " + DbCodeLanguage.ToString(snippets[i]._LanguageID) + " " + snippets[i]._CreateDate);

        }
    }
}
