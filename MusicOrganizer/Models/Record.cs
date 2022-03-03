using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string AlbumTitle { get; }
    public int Id { get; }
    private static List<Record> _instances = new List<Record> {};
    public Record(string albumTitle)
    {
      AlbumTitle = albumTitle;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Record> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}