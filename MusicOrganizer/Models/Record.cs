using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string AlbumTitle { get; set; }
    public int Id { get; set; }
    public Record(string albumTitle)
    {
      AlbumTitle = albumTitle;
    }

    public Record(string albumTitle, int id)
    {
      AlbumTitle = albumTitle;
      Id = id;
    }

    public override bool Equals(System.Object otherRecord)
    {
      if (!(otherRecord is Record))
      {
        return false;
      }
      else
      {
        Record newRecord = (Record)otherRecord;
        bool idEquality = (this.Id == newRecord.Id);
        bool descriptionEquality = (this.AlbumTitle == newRecord.AlbumTitle);
        return (idEquality && descriptionEquality);
      }
    }

    public static List<Record> GetAll()
    {
      List<Record> allRecords = new List<Record> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM records;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int recordId = rdr.GetInt32(0);
        string recordDescription = rdr.GetString(1);
        Record newRecord = new Record(recordDescription, recordId);
        allRecords.Add(newRecord);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRecords;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO Records (albumTitle) VALUES (@AlbumTitle);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@AlbumTitle";
      param.Value = this.AlbumTitle;
      cmd.Parameters.Add(param);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM records;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Record Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM Records WHERE id = @ThisId;";

      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;
      cmd.Parameters.Add(param);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int RecordId = 0;
      string RecordDescription = "";
      while (rdr.Read())
      {
        RecordId = rdr.GetInt32(0);
        RecordDescription = rdr.GetString(1);
      }
      Record foundRecord = new Record(RecordDescription, RecordId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundRecord;
    }
  }
}