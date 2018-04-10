﻿using MySql.Data.MySqlClient;
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
        public static List<SnippetInfo> GetFilteredSnippeds(string name, string CodeLanguage, DateFilter dateFilter, TypeFilter typeFilter)
        {
            //Create Temp List
            List<SnippetInfo> Temp = new List<SnippetInfo>();

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Create and add Commandtext
            cmd.CommandText = "SELECT `ID`, `UserID`, `TagCollectionID`, `Name`, `Code`, `CodeEditDate`, `UsageExample`, `UsageEditDate`, `Description`, `DescriptionEditDate`, `LanguageID`, `CreateDate` FROM `codesnippets` " +
                "WHERE `LanguageID` = @LanguageID";

            //Add parameters
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
                            Temp.Sort((x, y) => DateTime.Compare(x._CreateDate, y._CreateDate));
                            break;
                        case DateFilter.Oldest:
                            Temp.Sort((x, y) => DateTime.Compare(x._CreateDate, y._CreateDate));
                            break;
                    }

                }
                //Tag filter
            }

            //Return Temp List
            return Temp;

            //Before adding the item to the temp list filter it on date
            //By setting up a local variable
           // DateTime.Parse(_CreateDate)
        }
        public static bool AddNewSnippet(SnippetInfo snippetInfo)
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
                        return true;
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
