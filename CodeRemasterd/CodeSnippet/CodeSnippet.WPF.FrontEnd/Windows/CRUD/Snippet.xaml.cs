using CodeSnippet.Data;
using CodeSnippet.Data.Converter;
using CodeSnippet.Data.Database.Internal;
using System;
using System.Windows;
using System.Windows.Documents;

namespace CodeSnippet.WPF.FrontEnd.Windows.CRUD
{
    public partial class Snippet : Window
    {
        //-------------------------Variable------------------------------
        SnippetInfo SnippetInfo;
        CRUDFunctionalitie Functionalitie;


        //-------------------------Functions------------------------------
        //Main Functon to Setup the UI
        public Snippet(CRUDFunctionalitie functionalitie, SnippetInfo snippetInfo)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SetUI.CodeLanguageToCombobox(Language);
            Language.Items.Remove("All");
            Language.SelectedIndex = 0;
            SnippetInfo = snippetInfo;
            Functionalitie = functionalitie;
            this.Show();

            switch (functionalitie)
            {
                case CRUDFunctionalitie.Add:
                    Submit_btn.Content = "Add";
                    break;
                case CRUDFunctionalitie.Update:
                    Submit_btn.Content = "Update";
                    if (SnippetInfo != null)
                    {
                        Name.Text = SnippetInfo._Name;
                        Language.SelectedItem = DbCodeLanguage.ToString(snippetInfo._ID);
                        Code.Document.Blocks.Add(new Paragraph(new Run(snippetInfo._Code)));
                        Usage.Document.Blocks.Add(new Paragraph(new Run(snippetInfo._UsageExample)));
                        Description.Document.Blocks.Add(new Paragraph(new Run(snippetInfo._Description)));
                    }
                    //Set all Values
                    else
                        this.Close();
                    break;
                case CRUDFunctionalitie.Delete:
                    Submit_btn.Content = "Delete";
                    if (SnippetInfo != null)
                    {
                        Name.Text = SnippetInfo._Name;
                        Language.SelectedItem = DbCodeLanguage.ToString(snippetInfo._ID);
                        Code.Document.Blocks.Add(new Paragraph(new Run(snippetInfo._Code)));
                        Usage.Document.Blocks.Add(new Paragraph(new Run(snippetInfo._UsageExample)));
                        Description.Document.Blocks.Add(new Paragraph(new Run(snippetInfo._Description)));
                    }
                    else
                        this.Close();
                    break;
            }
        }
        //Submit-Button-Click Handler
        private void Submit_btn_Click(object sender, RoutedEventArgs e)
        {
            switch (Functionalitie)
            {
                case CRUDFunctionalitie.Add:
                    SnippetInfo = new SnippetInfo(
                        0,
                        UserInfo.Userinformation.ID,
                        0,
                        Name.Text,
                        Converter.StringFromRichTextBox(Code),
                        DateTime.Now,
                        Converter.StringFromRichTextBox(Usage),
                        DateTime.Now,
                        Converter.StringFromRichTextBox(Description),
                        DateTime.Now,
                        DbCodeLanguage.ToID(Language.SelectedItem.ToString()),
                        DateTime.Now
                        );

                    DbSnippets.AddNewSnippet(SnippetInfo);
                    this.Close();
                    break;
                case CRUDFunctionalitie.Update:
                    if (SnippetInfo != null)
                    {
                        SnippetInfo = new SnippetInfo(
                        0,
                        0,
                        0,
                        Name.Text,
                        Converter.StringFromRichTextBox(Code),
                        DateTime.Now,
                        Converter.StringFromRichTextBox(Usage),
                        DateTime.Now,
                        Converter.StringFromRichTextBox(Description),
                        DateTime.Now,
                        DbCodeLanguage.ToID(Language.SelectedItem.ToString()),
                        DateTime.Now
                        );
                        DbSnippets.UpdateSnippet(SnippetInfo);
                        this.Close();
                    }
                    break;
                case CRUDFunctionalitie.Delete:
                    if (SnippetInfo != null)
                    {
                        DbSnippets.DeleteSnippet(SnippetInfo._ID);
                        this.Close();
                    }
                    break;
            }
        }
        //Back-Button-Click Handler
        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
