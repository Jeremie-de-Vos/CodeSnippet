using CodeSnippet.Data.Database.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CodeSnippet.Data
{
    public class SetUI
    {
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
    }
}
