using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CodeSnippet.Data.Database.Internal
{
    public class DbSnippets
    {
        //-------------------------Filter------------------------------
        //Filter out all codesnippets
        public static List<SnippetInfo> GetFilteredSnippeds(string name, string CodeLanguage, DateFilter dateFilter, TypeFilter typeFilter)
        {
            //Create Temp List
            List<SnippetInfo> Temp = new List<SnippetInfo>();

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //The Default cmd String
            string cmdString = "SELECT `ID`, `UserID`, `TagCollectionID`, `Name`, `Code`, `CodeEditDate`, `UsageExample`, `UsageEditDate`, `Description`, `DescriptionEditDate`, `LanguageID`, `CreateDate` FROM `codesnippets` ";

            //If filter not is all add where string
            if (CodeLanguage != "All")
                cmdString += "WHERE `LanguageID` = @LanguageID";

            //Add the CommandText
            cmd.CommandText = cmdString;

            //Add Parameter
            cmd.Parameters.AddWithValue("@LanguageID", DbCodeLanguage.ToID(CodeLanguage));

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //While reading
            while (reader.Read())
            {
                //Save a new Temporary Snippet
                SnippetInfo TempSnippet = (new SnippetInfo(
                                    int.Parse(reader["ID"].ToString()),
                                    int.Parse(reader["UserID"].ToString()),
                                    int.Parse(reader["TagCollectionID"].ToString()),
                                    reader["Name"].ToString(),
                                    reader["Code"].ToString(),
                                    DateTime.Parse(reader["CodeEditDate"].ToString()),
                                    reader["UsageExample"].ToString(),
                                    DateTime.Parse(reader["UsageEditDate"].ToString()),
                                    reader["Description"].ToString(),
                                    DateTime.Parse(reader["DescriptionEditDate"].ToString()),
                                    int.Parse(reader["LanguageID"].ToString()),
                                    DateTime.Parse(reader["CreateDate"].ToString())
                                    ));

                //If User is owner of this CodeSnippet
                if (int.Parse(reader["UserID"].ToString()) == UserInfo.Userinformation.ID)
                {
                    //Add snipped Based on TypeFilter
                    switch (typeFilter)
                    {
                        case TypeFilter.SnippedName:
                            if (TempSnippet._Name.ToLower().Contains(name.ToLower()))
                                Temp.Add(TempSnippet);
                            break;
                        case TypeFilter.Code:
                            if (TempSnippet._Code.ToLower().Contains(name.ToLower()))
                                Temp.Add(TempSnippet);
                            break;
                        case TypeFilter.Description:
                            if (TempSnippet._Description.ToLower().Contains(name.ToLower()))
                                Temp.Add(TempSnippet);
                            break;
                        case TypeFilter.Usage:
                            if (TempSnippet._UsageExample.ToLower().Contains(name.ToLower()))
                                Temp.Add(TempSnippet);
                            break;
                    }
                    //Filter List Based on DateFilter
                    switch (dateFilter)
                    {
                        case DateFilter.Newest:
                             SortAscending(Temp);
                            break;
                        case DateFilter.Oldest:
                            SortDescending(Temp);
                            break;
                    }
                }
            }

            //Close Connection
            connection.Close();
            
            //Return Temp List
            return Temp;
        }
        //Sort Temp list on date
        private static List<SnippetInfo> SortAscending(List<SnippetInfo> list)
        {
            list.Sort((a, b) => a._CreateDate.CompareTo(b._CreateDate));
            return list;
        }
        //Sort Temp list on date
        private static List<SnippetInfo> SortDescending(List<SnippetInfo> list)
        {
            list.Sort((a, b) => b._CreateDate.CompareTo(a._CreateDate));
            return list;
        }


        //-------------------------Collections------------------------
        //Convert a SnippetCollection Name To a ID from Database
        public static int ToID(string SnippetCollectionName)
        {

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`, `Name` FROM `snippedcollection` WHERE `Name` = @Name";
            cmd.Parameters.AddWithValue("@Name", SnippetCollectionName);

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //if match is found
            if (reader.Read())
                return int.Parse(reader["ID"].ToString());
            else
                return 0;
        }
        //Convert a SnippetCollection ID To a Programming SnippetCollection from Database
        public static string ToString(int ID)
        {

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`, `Name` FROM `snippedcollection` WHERE `ID` = @ID";
            cmd.Parameters.AddWithValue("@ID", ID);

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //if match is found
            if (reader.Read())
                return reader["Name"].ToString();
            else
                return "";
        }

        //Get SnippetInfo from ID
        public static SnippetInfo GetSnippetInfoFromID(int ID)
        {
            //Create temp
            SnippetInfo Temp = null;
            
            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`, `UserID`, `TagCollectionID`, `Name`, `Code`, `CodeEditDate`, `UsageExample`, `UsageEditDate`, `Description`, `DescriptionEditDate`, `LanguageID`, `CreateDate` FROM `codesnippets` WHERE `ID` = @ID";
            cmd.Parameters.AddWithValue("@ID", ID);

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //if match is found
            if (reader.Read())
            {
                //Save a new Temporary Snippet
                return new SnippetInfo(
                                    int.Parse(reader["ID"].ToString()),
                                    int.Parse(reader["UserID"].ToString()),
                                    int.Parse(reader["TagCollectionID"].ToString()),
                                    reader["Name"].ToString(),
                                    reader["Code"].ToString(),
                                    DateTime.Parse(reader["CodeEditDate"].ToString()),
                                    reader["UsageExample"].ToString(),
                                    DateTime.Parse(reader["UsageEditDate"].ToString()),
                                    reader["Description"].ToString(),
                                    DateTime.Parse(reader["DescriptionEditDate"].ToString()),
                                    int.Parse(reader["LanguageID"].ToString()),
                                    DateTime.Parse(reader["CreateDate"].ToString())
                                    );
            }
            //Return value
            return Temp;
        }


        //-------------------------CRUD------------------------------
        //Add new Snippet
        public static void AddNewSnippet(SnippetInfo snippetInfo)
        {
            using (MySqlConnection connection = DbInfo.Connection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "INSERT INTO `codesnippets`(`ID`, `UserID`, `TagCollectionID`, `Name`, `Code`, `CodeEditDate`, `UsageExample`, `UsageEditDate`, `Description`, `DescriptionEditDate`, `LanguageID`, `CreateDate`) " +
                        "VALUES (@ID,@UserID,@TagCollectionID,@Name,@Code,@CodeEditDate,@UsageExample,@UsageEditDate,@Description,@DescriptionEditDate,@LanguageID,@CreateDate)";

                    cmd.Parameters.AddWithValue("@ID", "");
                    cmd.Parameters.AddWithValue("@UserID", UserInfo.Userinformation.ID);
                    cmd.Parameters.AddWithValue("@TagCollectionID", snippetInfo._TagCollectionID);
                    cmd.Parameters.AddWithValue("@Name", snippetInfo._Name);
                    cmd.Parameters.AddWithValue("@Code", snippetInfo._Code);
                    cmd.Parameters.AddWithValue("@CodeEditDate", snippetInfo._CodeEditDate.ToString());
                    cmd.Parameters.AddWithValue("@UsageExample", snippetInfo._UsageExample);
                    cmd.Parameters.AddWithValue("@UsageEditDate", snippetInfo._UsageEditDate.ToString());
                    cmd.Parameters.AddWithValue("@Description", snippetInfo._Description);
                    cmd.Parameters.AddWithValue("@DescriptionEditDate", snippetInfo._DescriptionEditDate.ToString());
                    cmd.Parameters.AddWithValue("@LanguageID", snippetInfo._LanguageID);
                    cmd.Parameters.AddWithValue("@CreateDate", snippetInfo._CreateDate.ToString());

                    try
                    {
                        int recordsAffected = cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        //Update new Snippet
        public static void UpdateSnippet(SnippetInfo snippetInfo)
        {
            using (MySqlConnection connection = DbInfo.Connection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "UPDATE `codesnippets` SET " +
                        "`TagCollectionID`= @TagCollectionID," +
                        "`Name`= @Name," +
                        "`Code`= @Code," +
                        "`CodeEditDate`= @CodeEditDate," +
                        "`UsageExample`= @UsageExample," +
                        "`UsageEditDate`= @UsageEditDate," +
                        "`Description`= @Description," +
                        "`DescriptionEditDate`= @DescriptionEditDate," +
                        "`LanguageID`= @LanguageID " +
                        "WHERE `ID`= @ID";

                    cmd.Parameters.AddWithValue("@ID", snippetInfo._ID);
                    cmd.Parameters.AddWithValue("@TagCollectionID", snippetInfo._TagCollectionID);
                    cmd.Parameters.AddWithValue("@Name", snippetInfo._Name);
                    cmd.Parameters.AddWithValue("@Code", snippetInfo._Code);
                    cmd.Parameters.AddWithValue("@CodeEditDate", snippetInfo._CodeEditDate.ToString());
                    cmd.Parameters.AddWithValue("@UsageExample", snippetInfo._UsageExample);
                    cmd.Parameters.AddWithValue("@UsageEditDate", snippetInfo._UsageEditDate.ToString());
                    cmd.Parameters.AddWithValue("@Description", snippetInfo._Description);
                    cmd.Parameters.AddWithValue("@DescriptionEditDate", snippetInfo._DescriptionEditDate.ToString());
                    cmd.Parameters.AddWithValue("@LanguageID", snippetInfo._LanguageID);

                    try
                    {
                        int recordsAffected = cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        //Delete new Snippet
        public static void DeleteSnippet(int ID)
        {
            //Create Connection
            using (MySqlConnection connection = DbInfo.Connection())
            {
                //Create Cmd
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    //Set CommandText
                    cmd.CommandText = "DELETE FROM `codesnippets` WHERE `ID` = @ID";

                    //Add Parameters
                    cmd.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        int recordsAffected = cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
//------Enum-ClassInfo-------
public class SnippetInfo
{
    public int _ID;
    public int _UserID;
    public int _TagCollectionID;
    public string _Name;
    public string _Code;
    public DateTime _CodeEditDate;
    public string _UsageExample;
    public DateTime _UsageEditDate;
    public string _Description;
    public DateTime _DescriptionEditDate;
    public int _LanguageID;
    public DateTime _CreateDate;

    public SnippetInfo(    
     int ID,
     int UserID,
     int TagCollectionID,
     string Name,
     string Code,
     DateTime CodeEditDate,
     string UsageExample,
     DateTime UsageEditDate,
     string Description,
     DateTime DescriptionEditDate,
     int LanguageId,
     DateTime CreateDate)
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
        _LanguageID = LanguageId;
        _CreateDate = CreateDate;
    }
}
public enum DateFilter
{
    Newest,
    Oldest
}
public enum TypeFilter
{
    SnippedName,
    Description,
    Usage,
    Code
}
