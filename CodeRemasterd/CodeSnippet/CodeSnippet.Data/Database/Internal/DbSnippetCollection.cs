using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.Data.Database.Internal
{
    public class DbSnippetCollection
    {
        //-------------------------GetCollection------------------------------
        //Get all Collections
        public static List<CollectionCompleteInfo> GetAllCollections()
        {
            //Create Temp
            List<CollectionCompleteInfo> Temp = null;

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Add the CommandText
            cmd.CommandText = "SELECT `ID`, `UserID`, `Name`, `CreateDate` FROM `snippedcollection`";


            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //While reading
            while (reader.Read())
            {
                int ID = int.Parse(reader["ID"].ToString());
                Temp.Add(new CollectionCompleteInfo(GetSnippetCollectionInfo(ID), GetSnippetsRelatedToCollection(ID)));
            }
            //Return Value
            return Temp;
        }
        //Get Collections with related Snippets by id
        public static CollectionCompleteInfo GetCollectionByID(int CollectionID)
        {
            CollectionCompleteInfo info = new CollectionCompleteInfo(GetSnippetCollectionInfo(CollectionID), GetSnippetsRelatedToCollection(CollectionID));
            return info;
        }


        //Get all snippetsinfo related to CollectionID
        private static List<SnippetInfo> GetSnippetsRelatedToCollection(int CollectionID)
        {
            /*
             * if code snippetcollectionID = ID 
             * Get Snippet ID
             * Get SnippetInfo from ID and add to list
             */

            //Create Temp
            List<SnippetInfo> Temp = null;

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Add the CommandText
            cmd.CommandText = "SELECT `ID`, `CodeSnippetsID`, `SnippetCollectionID` FROM `snipped_codecollection` WHERE `SnippetCollectionID` = @CollectionID";

            //Add Parameter
            cmd.Parameters.AddWithValue("@CollectionID", CollectionID);

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //While reading
            while (reader.Read())
            {
                Temp.Add(DbSnippets.GetSnippetInfoFromID(int.Parse(reader["CodeSnippetsID"].ToString())));
            }
            //Return Value
            return Temp;
        }
        //Get SnippetCollectionInfo related to CollectionID
        private static SnippetCollectionInfo GetSnippetCollectionInfo(int CollectionID)
        {
            //Create Temp
            SnippetCollectionInfo info = null;

            //create connection and open it
            MySqlConnection connection = DbInfo.Connection();

            //Build Mysql command
            MySqlCommand cmd = connection.CreateCommand();

            //Add the CommandText
            cmd.CommandText = "SELECT `ID`, `UserID`, `Name`, `CreateDate` FROM `snippedcollection` WHERE `ID` = @CollectionID";

            //Add Parameter
            cmd.Parameters.AddWithValue("@CollectionID", CollectionID);

            //Create reader
            MySqlDataReader reader = cmd.ExecuteReader();

            //While reading
            if (reader.Read())
            {
                info = new SnippetCollectionInfo(
                    int.Parse(reader["ID"].ToString()),
                    int.Parse(reader["UserID"].ToString()),
                    reader["Name"].ToString(),
                    DateTime.Parse(reader["CreateDate"].ToString())
                    );
            }
            //Return Value
            return info;
        }


        //-------------------------Converters------------------------------
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


        //-------------------------CRUD------------------------------
        //Add new Collection
        public static void AddNewSnippetCollection(SnippetCollectionInfo SnippetCollectionInfo)
        {
            //Create Connection
            using (MySqlConnection connection = DbInfo.Connection())
            {
                //Create cmd
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    //Create CommandText
                    cmd.CommandText = "INSERT INTO `snippedcollection`(`ID`, `Name`) VALUES (@ID, @Name)";

                    //Set Parameters
                    cmd.Parameters.AddWithValue("@ID", "");
                    cmd.Parameters.AddWithValue("@Name", SnippetCollectionInfo.Name);

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
        //Update new Collection
        public static void UpdateSnippetCollection(SnippetCollectionInfo SnippetCollectionInfo)
        {
            //Create Connection
            using (MySqlConnection connection = DbInfo.Connection())
            {
                //Create Cmd
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;

                    //Create CommandText
                    cmd.CommandText = "UPDATE `snippedcollection` SET `Name`=@Name WHERE `ID`=@ID";

                    //Set Parameters
                    cmd.Parameters.AddWithValue("@ID", SnippetCollectionInfo.ID);
                    cmd.Parameters.AddWithValue("@Name", SnippetCollectionInfo.Name);

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
        //Delete new Collection
        public static void DeleteSnippetCollection(int ID)
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
                    cmd.CommandText = "DELETE FROM `snippedcollection` WHERE `ID` = @ID";

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
public class SnippetCollectionInfo{
    public int ID;
    public int UserID;
    public string Name;
    public DateTime CreateDate;

    public SnippetCollectionInfo(int _ID, int _UserID, string _Name, DateTime _CreateDate)
    {
        ID = _ID;
        UserID = _UserID;
        Name = _Name;
        CreateDate = _CreateDate;
    }
}
public class CollectionCompleteInfo
{
    public SnippetCollectionInfo collectioninfo;
    public List<SnippetInfo> snippets;

    public CollectionCompleteInfo(SnippetCollectionInfo _collectioninfo, List<SnippetInfo> _snippets)
    {
        collectioninfo = _collectioninfo;
        snippets = _snippets;
    }
}
class CollectionBinderinfo
{
    public int ID;
    public int CodeSnippetID;

    public CollectionBinderinfo(int _ID, int _CodeSnippetID)
    {
        ID = _ID;
        CodeSnippetID = _CodeSnippetID;
    }
}

