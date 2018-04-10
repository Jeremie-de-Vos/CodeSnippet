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
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Test_btn_Click(object sender, RoutedEventArgs e)
        {
            UserInfo.SetUserInfo(1);
            Field.Document.Blocks.Clear();
            //foreach (string i in Converter.GetAllDateFilterToStringArray())
            //Field.AppendText(Environment.NewLine+"- " + System.DateTime.Now.ToString());

            int ExamplePerLanguage = 2;
            for (int l = 0; l < DbCodeLanguage.GetallLanguages().Count; l++)
            {
                for (int examples = 0; examples < ExamplePerLanguage; examples++)
                {
                    SnippetInfo snippetInfo = new SnippetInfo(
                        9999,
                        UserInfo.Userinformation.ID,
                        9999,
                        "Name" + examples,
                        "Code" + examples,
                        DateTime.Now,
                        "Usage" + examples,
                        DateTime.Now,
                        "Description" + examples,
                        DateTime.Now,
                        DbCodeLanguage.ToID(DbCodeLanguage.GetallLanguages()[l]),
                        DateTime.Now
                        );
                    System.Threading.Thread.Sleep(1000);

                    if(DbSnippets.AddNewSnippet(snippetInfo))
                        Field.AppendText(Environment.NewLine + "- " + snippetInfo._Name + " in " + DbCodeLanguage.ToString(snippetInfo._LanguageID));
                }
            }
        }
    }
}
