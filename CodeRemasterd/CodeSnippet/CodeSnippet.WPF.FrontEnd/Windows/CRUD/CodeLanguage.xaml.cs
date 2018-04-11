using CodeSnippet.Data.Database.Internal;
using System.Windows;

namespace CodeSnippet.WPF.FrontEnd.Windows.CRUD
{
    public partial class CodeLanguage : Window
    {
        //-------------------------Variable------------------------------
        CodeLanguageInfo Info;
        CRUDFunctionalitie Functionalitie;


        //-------------------------Functions------------------------------
        //Main Functon to Setup the UI
        public CodeLanguage(CRUDFunctionalitie functionalitie, CodeLanguageInfo info)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Info = info;
            Functionalitie = functionalitie;
            this.Show();

            switch (functionalitie)
            {
                case CRUDFunctionalitie.Add:
                    Submit_btn.Content = "Add";
                    break;
                case CRUDFunctionalitie.Update:
                    Submit_btn.Content = "Update";
                    if (Info != null)
                        Language_txt.Text = Info.Name;
                    else
                        this.Close();
                    break;
                case CRUDFunctionalitie.Delete:
                    Submit_btn.Content = "Delete";
                    if (Info != null)
                        Language_txt.Text = Info.Name;
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
                    Info = new CodeLanguageInfo(0, Language_txt.Text);
                    DbCodeLanguage.AddNewCodeLanguage(Info);
                    this.Close();
                    break;
                case CRUDFunctionalitie.Update:
                    if (Info != null)
                    {
                        Info = new CodeLanguageInfo(0, Language_txt.Text);
                        DbCodeLanguage.UpdateCodeLanguage(Info);
                        this.Close();
                    }
                    break;
                case CRUDFunctionalitie.Delete:
                    if (Info != null)
                    {
                        DbCodeLanguage.DeleteCodeLanguage(Info.ID);
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
