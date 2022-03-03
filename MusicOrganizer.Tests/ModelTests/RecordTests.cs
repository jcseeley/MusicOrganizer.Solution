using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; 
using System.Collections.Generic;
using MusicOrganizer.Models;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests
  {
    
    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Object()
    {
      Record newRecord = new Record();
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    public void GetAlbumTitle_ReturnsAlbumTitle_String()
    {
      string newAlbum = "Test";
      Record newRecord = new Record(newAlbum);
      string result = newRecord.AlbumTitle;
      Assert.AreEqual(newAlbum, result);
    }
  }
}

// [TestMethod]
// public void NameOfMethodWeAreTesting_DescriptionOfBehavior_ExpectedReturnValue()
// {
//   // any necessary logic to prep for test; instantiating new classes, etc.
//   Assert.AreEqual(EXPECTED RESULT, CODE TO TEST);
// }