using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; set; }
    public int Id { get; set; }
    public List<Record> Records { get; set; }
    public Artist(string name)
    {
      Name = name;
      Records = new List<Record> {};
    }
    public Artist(string name, int id)
    {
      Name = name;
      Id = id;
    }
    public override bool Equals(System.Object otherArtist)
    {
      if (!(otherArtist is Artist))
      {
        return false;
      }
      else
      {
        Artist newArtist = (Artist)otherArtist;
        bool idEquality = (this.Id == newArtist.Id);
        bool descriptionEquality = (this.Name == newArtist.Name);
        return (idEquality && descriptionEquality);
      }
    }
    public void AddRecord(Record record)
    {
      Records.Add(record);
    }
    public static List<Artist> GetAll()
    {
      List<Artist> allArtists = new List<Artist> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM artists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int artistId = rdr.GetInt32(0);
        string artistDescription = rdr.GetString(1);
        Artist newArtist = new Artist(artistDescription, artistId);
        allArtists.Add(newArtist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allArtists;
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO Artists (name) VALUES (@Name);";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@Name";
      param.Value = this.Name;
      cmd.Parameters.Add(param);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static Artist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM Artists WHERE id = @ThisId;";

      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;
      cmd.Parameters.Add(param);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int ArtistId = 0;
      string ArtistDescription = "";
      while (rdr.Read())
      {
        ArtistId = rdr.GetInt32(0);
        ArtistDescription = rdr.GetString(1);
      }
      Artist foundArtist = new Artist(ArtistDescription, ArtistId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundArtist;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM artists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}