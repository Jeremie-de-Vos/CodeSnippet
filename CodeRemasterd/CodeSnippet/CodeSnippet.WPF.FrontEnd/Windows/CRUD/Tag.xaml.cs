using CodeSnippet.Data.Database.Internal;
using System.Windows;

namespace CodeSnippet.WPF.FrontEnd.Windows.CRUD
{
    public partial class Tag : Window
    {
        //-------------------------Variable------------------------------
        TagInfo TagInfo;
        CRUDFunctionalitie Functionalitie;


        //-------------------------Functions------------------------------
        //Main Functon to Setup the UI
        public Tag(CRUDFunctionalitie functionalitie, TagInfo tagInfo)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            TagInfo = tagInfo;
            Functionalitie = functionalitie;
            this.Show();

            switch (functionalitie)
            {
                case CRUDFunctionalitie.Add:
                    Submit_btn.Content = "Add";
                    break;
                case CRUDFunctionalitie.Update:
                    Submit_btn.Content = "Update";
                    if (tagInfo != null)
                        Tagname_txt.Text = tagInfo.Name;
                    else
                        this.Close();
                    break;
                case CRUDFunctionalitie.Delete:
                    Submit_btn.Content = "Delete";
                    if (tagInfo != null)
                        Tagname_txt.Text = tagInfo.Name;
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
                    TagInfo = new TagInfo(0, Tagname_txt.Text);
                    DbTags.AddNewTag(TagInfo);
                    this.Close();
                    break;
                case CRUDFunctionalitie.Update:
                    if (TagInfo != null)
                    {
                        TagInfo = new TagInfo(0, Tagname_txt.Text);
                        DbTags.UpdateTag(TagInfo);
                        this.Close();
                    }
                    break;
                case CRUDFunctionalitie.Delete:
                    if (TagInfo != null)
                    {
                        DbTags.DeleteTag(TagInfo.ID);
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
