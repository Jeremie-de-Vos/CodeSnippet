using CodeSnippet.Data;
using CodeSnippet.Data.Converter;
using CodeSnippet.Data.Database.External;
using CodeSnippet.Data.Database.Internal;
using CodeSnippet.WPF.FrontEnd.Windows.CRUD;
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
        //-------------------------Main------------------------------
        //Prefending startup errors
        bool startup = false;
        //Main
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            UserInfo.SetUserInfo(1);

            SetUI.DatesToCombobox(MySnipped_Date_Cmb);
            SetUI.CodeLanguageToCombobox(MySnipped_Languages_Cmb);
            SetUI.TypeToCombobox(MySnipped_Type_Cmb);

            MySnipped_Date_Cmb.SelectedIndex = 0;
            MySnipped_Type_Cmb.SelectedIndex = 0;
            MySnipped_Languages_Cmb.SelectedIndex = 0;

            startup = true;
        }

        //-------------------------Test------------------------------
        //TestButton Clicked
        private void Test_btn_Click(object sender, RoutedEventArgs e)
        {
            Field.Document.Blocks.Clear();
        }
        //SearchBox if Enter is pressed
        private void SearchBox_Mysnipped_txb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                FilterCodeSnippeds();
        }

        //-------------------------Filters------------------------------
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
            //Give all filter values and recieve a list with Items
            List<SnippetInfo> snippets = DbSnippets.GetFilteredSnippeds(
            SearchBox_Mysnipped_txb.Text,
            MySnipped_Languages_Cmb.SelectedItem.ToString(),
            Converter.StringToDateFilter(MySnipped_Date_Cmb.SelectedItem.ToString()),
            Converter.StringToTypefilter(MySnipped_Type_Cmb.SelectedItem.ToString())
            );
            //Clear RichTextBox
            Results.Document.Blocks.Clear();


            List<SnippetUI> items = new List<SnippetUI>();
            for (int i = 0; i < snippets.Count; i++)
                items.Add(new SnippetUI(snippets[i]._Name, DbCodeLanguage.ToString(snippets[i]._LanguageID)));
            
            CodeSnippetsCintainer.ItemsSource = items;
            //Results.AppendText(Environment.NewLine + "- " + snippets[i]._Name + " " + DbCodeLanguage.ToString(snippets[i]._LanguageID) + " " + snippets[i]._CreateDate);

        }



        DatabaseInfo dbDummy = new DatabaseInfo(0, "TestDummy", "TestDummy", "TestDummy", "TestDummy");
        TagInfo TagDummy = new TagInfo(0, "TestDummy");
        CodeLanguageInfo LanguageDummy = new CodeLanguageInfo(0, "TestDummy");



        //-------------------------External-Database------------------------------
        private void DbAdd_Click(object sender, RoutedEventArgs e)
        {
            //ExternalDatabase wd = new ExternalDatabase(CRUDFunctionalitie.Add, null);
            //Tag wd = new Tag(CRUDFunctionalitie.Add, null);
            CodeLanguage wd = new CodeLanguage(CRUDFunctionalitie.Add, null);
        }
        private void DbUpdate_Click(object sender, RoutedEventArgs e)
        {
            //ExternalDatabase wd = new ExternalDatabase(CRUDFunctionalitie.Update, dbDummy);
            //Tag wd = new Tag(CRUDFunctionalitie.Update, TagDummy);
            CodeLanguage wd = new CodeLanguage(CRUDFunctionalitie.Update, LanguageDummy);
        }
        private void DbDelete_Click(object sender, RoutedEventArgs e)
        {
            //ExternalDatabase wd = new ExternalDatabase(CRUDFunctionalitie.Delete, dbDummy);
            //Tag wd = new Tag(CRUDFunctionalitie.Delete, TagDummy);
            CodeLanguage wd = new CodeLanguage(CRUDFunctionalitie.Delete, LanguageDummy);
        }

        private void SearchBox_Mysnipped_txb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }






        //foreach (string i in Converter.GetAllDateFilterToStringArray())
        //Field.AppendText(Environment.NewLine+"- " + System.DateTime.Now.ToString());
    }
}
public class SnippetUI
{
    public string Name;
    public string Language;

    public SnippetUI(string _Name, string _Language)
    {
        Name = _Name;
        Language = _Language;
    }
}