using CodeSnippet.Data;
using CodeSnippet.Data.Database.Internal;
using CodeSnippet.Data.General;
using CodeSnippet.WPF.FrontEnd.Windows.NavigationBars;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace CodeSnippet.WPF.FrontEnd.Windows.Pages
{
    public partial class SnippetsPage : UserControl
    {
        public Control[] c;
        public SnippetInfo currentsnippet;
        public NavBarSnippet Nav;

        public SnippetsPage()
        {
            InitializeComponent();
            MainContainer.Height = this.Height;
            Control[] con = { Name, Language };
            c = con;
            ViewMode = false;
            Clear();
        }

        private bool _ViewMode;
        public bool ViewMode
        {
            get { return _ViewMode; }
            set
            {
                _ViewMode = value;
                if (_ViewMode)
                {
                    New.Visibility = Visibility.Visible;
                    New.Content = "Create New";
                    Action.Content = "Export";
                    Delete.Visibility = Visibility.Visible;
                    Save.Content = "Save";
                }
                else
                {
                    New.Visibility = Visibility.Collapsed;
                    Action.Content = "Clear";
                    Delete.Visibility = Visibility.Collapsed;
                    Save.Content = "Save as New";
                }
                ControlState.Execute(c, ControlStateVisuals.Background);
            }
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            if (ViewMode)
                Export();
            else
                Clear();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ViewMode)
                DeleteNow();
            else
            {

            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ViewMode)
                SaveNow();
            else
                SaveAsNew();
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (ViewMode)
            {
                Clear();
                ViewMode = false;
            }
            else
            {

            }
        }


        private void SaveAsNew()
        {
            if (ControlState.Execute(c, ControlStateVisuals.Colored))
            {
                TextRange Coderange = new TextRange(Code.Document.ContentStart, Code.Document.ContentEnd);
                TextRange Usagerange = new TextRange(Usage.Document.ContentStart, Usage.Document.ContentEnd);
                TextRange Descriptionrange = new TextRange(Description.Document.ContentStart, Description.Document.ContentEnd);


                SnippetInfo info = new SnippetInfo(
                    0,
                    UserInfo.Userinformation.ID,
                    0,
                    Name.Text,
                    Coderange.Text,
                    DateTime.Now,
                    Usagerange.Text,
                    DateTime.Now,
                    Descriptionrange.Text,
                    DateTime.Now,
                    DbCodeLanguage.ToID(Language.SelectedItem.ToString()),
                    DateTime.Now
                    );

                DbSnippets.AddNewSnippet(info);
                if(Nav != null)
                    Nav.FilterCodeSnippeds();
                ControlState.Execute(c, ControlStateVisuals.Background);
                Clear();
            }
        }
        private void DeleteNow()
        {
            DbSnippets.DeleteSnippet(currentsnippet._ID);
            Nav.FilterCodeSnippeds();
            ControlState.Execute(c, ControlStateVisuals.Background);
            Clear();
        }
        private void SaveNow()
        {
            currentsnippet._Name = Name.Text;
            currentsnippet._LanguageID = DbCodeLanguage.ToID(Language.SelectedItem.ToString());

            TextRange range = new TextRange(Usage.Document.ContentStart, Usage.Document.ContentEnd);
            currentsnippet._UsageExample = range.Text;

            TextRange range1 = new TextRange(Description.Document.ContentStart, Description.Document.ContentEnd);
            currentsnippet._UsageExample = range1.Text;

            TextRange range2 = new TextRange(Code.Document.ContentStart, Code.Document.ContentEnd);
            currentsnippet._UsageExample = range2.Text;

            DbSnippets.UpdateSnippet(currentsnippet);
            Nav.FilterCodeSnippeds();
            ControlState.Execute(c, ControlStateVisuals.Background);
            Clear();
        }
        private void Export()
        {

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = currentsnippet._Name; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                StreamWriter writer = new StreamWriter(dlg.OpenFile());

                writer.Write(currentsnippet._Code);

                writer.Dispose();
                writer.Close();

                string filename = dlg.FileName;
            }
            ControlState.Execute(c, ControlStateVisuals.Background);
        }
        private void Clear()
        {
            Name.Text = string.Empty;

            Language.Items.Clear();
            SetUI.CodeLanguageToCombobox(Language);
            Language.Items.Remove("All");
            Language.SelectedIndex = 0;

            Usage.Document.Blocks.Clear();
            Description.Document.Blocks.Clear();
            Code.Document.Blocks.Clear();

            ControlState.Execute(c, ControlStateVisuals.Background);
        }
    }
}
