using CodeSnippet.Data.Database.External;
using System.Windows;

namespace CodeSnippet.WPF.FrontEnd.Windows.CRUD
{
    public partial class ExternalDatabase : Window
    {
        //-------------------------Variable------------------------------
        DatabaseInfo DatabaseInfo;
        CRUDFunctionalitie Functionalitie;


        //-------------------------Functions------------------------------
        //Main Functon to Setup the UI
        public ExternalDatabase(CRUDFunctionalitie functionalitie, DatabaseInfo databaseInfo)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DatabaseInfo = databaseInfo;
            Functionalitie = functionalitie;
            this.Show();

            switch (functionalitie)
            {
                case CRUDFunctionalitie.Add:
                    Submit_btn.Content = "Add";
                    break;
                case CRUDFunctionalitie.Update:
                    Submit_btn.Content = "Update";
                    if (DatabaseInfo != null)
                    {
                        DataSource_txt.Text = DatabaseInfo.DataSource;
                        Username_txt.Text = DatabaseInfo.Username;
                        Password_txt.Text = DatabaseInfo.Password;
                        DatabasName_txt.Text = DatabaseInfo.DatabaseName;
                    }
                    else
                        this.Close();
                    break;
                case CRUDFunctionalitie.Delete:
                    Submit_btn.Content = "Delete";
                    if (DatabaseInfo != null)
                    {
                        DataSource_txt.Text = DatabaseInfo.DataSource;
                        Username_txt.Text = DatabaseInfo.Username;
                        Password_txt.Text = DatabaseInfo.Password;
                        DatabasName_txt.Text = DatabaseInfo.DatabaseName;
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
                    DatabaseInfo = new DatabaseInfo(0, DataSource_txt.Text, Username_txt.Text, Password_txt.Text, DatabasName_txt.Text);
                    GetDbInfo.AddNewDatabase(DatabaseInfo);
                    this.Close();
                    break;
                case CRUDFunctionalitie.Update:
                    if(DatabaseInfo != null)
                    {
                        DatabaseInfo = new DatabaseInfo(0, DataSource_txt.Text, Username_txt.Text, Password_txt.Text, DatabasName_txt.Text);
                        GetDbInfo.UpdateDatabase(DatabaseInfo);
                        this.Close();
                    }
                    break;
                case CRUDFunctionalitie.Delete:
                    if (DatabaseInfo != null)
                    {
                        GetDbInfo.DeleteDatabase(DatabaseInfo.ID);
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
