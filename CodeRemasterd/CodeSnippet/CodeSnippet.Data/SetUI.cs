using CodeSnippet.Data.Database.External;
using CodeSnippet.Data.Database.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeSnippet.Data.Converter;

namespace CodeSnippet.Data
{
    public class SetUI
    {
        //-------------------------Database------------------------------
        //Set Database Tables to CMB
        public void TablesToCombobox(ComboBox comboBox, string DbName)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("All Tables");

            foreach (string i in GetDbInfo.GetTableNames(DbName))
                comboBox.Items.Add(i);
            comboBox.SelectedIndex = 0;
        }
        //Set Databases to CMB
        public void DatabasesToCombobox(ComboBox comboBox)
        {
            //Clear cmb
            comboBox.Items.Clear();
            List<string> temp = GetDbInfo.GetAllDatabases();


            if (temp.Count > 0)
                temp.Insert(0, "All Databases");
            else
                temp.Add("No Db Found");

            //Add all items
            foreach (string i in temp)
                comboBox.Items.Add(i);

            //Set selected item
            comboBox.SelectedIndex = 0;
        }


        //-------------------------Filters------------------------------
        public static void DatesToCombobox(ComboBox comboBox)
        {
            foreach (string date in Converter.Converter.GetAllDateFilterToStringArray())
                comboBox.Items.Add(date);
        }
        public static void CodeLanguageToCombobox(ComboBox comboBox)
        {
            comboBox.Items.Add("All");
            foreach (CodeLanguageInfo type in DbCodeLanguage.GetallLanguages())
                comboBox.Items.Add(type.Name);

        }
        public static void TypeToCombobox(ComboBox comboBox)
        {
            foreach (string type in Converter.Converter.GetAllTypeFilterToStringArray())
                comboBox.Items.Add(type);
        }
    }
}
