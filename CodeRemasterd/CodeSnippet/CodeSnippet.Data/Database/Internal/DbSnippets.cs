using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.Database.Internal
{
    public class DbSnippets
    {
        public List<SnippetInfo> GetFilteredSnippeds(string name, string CodeLanguage, DateFilter dateFilter)
        {
            //Create Temp List
            List<SnippetInfo> Temp = new List<SnippetInfo>();

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`, `UserID`, `TagCollectionID`, `Name`, `Code`, `CodeEditDate`, `UsageExample`, `UsageEditDate`, `Description`, `DescriptionEditDate`, `LanguageID` FROM `codesnippets` " +
                "WHERE 1";

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //While reading
            //while (reader.Read())
                //Temp.Add(reader["TagName"].ToString());

            //Return Temp List
            return Temp;
        }
    }
}
public class SnippetInfo
{
    public int _ID;
    public int _UserID;
    public int _TagCollectionID;
    public string _Name;
    public string _Code;
    public string _CodeEditDate;
    public string _UsageExample;
    public string _UsageEditDate;
    public string _Description;
    public string _DescriptionEditDate;
    public int _LanguageId;

    public SnippetInfo(    
     int ID,
     int UserID,
     int TagCollectionID,
     string Name,
     string Code,
     string CodeEditDate,
     string UsageExample,
     string UsageEditDate,
     string Description,
     string DescriptionEditDate,
     int LanguageId)
    {
        _ID = ID;
        _UserID = UserID;
        _TagCollectionID = TagCollectionID;
        _Name = Name;
        _Code = Code;
        _CodeEditDate = CodeEditDate;
        _UsageExample = UsageExample;
        _UsageEditDate = UsageEditDate;
        _Description = Description;
        _DescriptionEditDate = DescriptionEditDate;
        _LanguageId = LanguageId;
    }
}
public enum DateFilter
{
    Newest,
    Oldest
}
