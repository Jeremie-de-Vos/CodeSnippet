using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.Database.Internal
{
    public class DbExamples
    {
        //Create 2 examples foreach CodeLanguage from Database
        public static void CodeSnippedExampleForeachCodeLanguageInDatabase()
        {
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
                        DbCodeLanguage.ToID(DbCodeLanguage.GetallLanguages()[l]),//<-------------
                        DateTime.Now
                        );
                    System.Threading.Thread.Sleep(1000);

                    DbSnippets.AddNewSnippet(snippetInfo);
                }
            }
        }
    }
}
