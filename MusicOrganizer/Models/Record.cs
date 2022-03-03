using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string AlbumTitle { get; }
    public Record(string albumTitle)
    {
      AlbumTitle = albumTitle;
    }
  }
}