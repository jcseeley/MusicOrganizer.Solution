using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; 
using System.Collections.Generic;
using MusicOrganizer.Models;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {
    public void Dispose()
    {
      Record.ClearAll();
    }
    
    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Object()
    {
      Record newRecord = new Record("test");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetAlbumTitle_ReturnsAlbumTitle_String()
    {
      string newAlbum = "Test";
      Record newRecord = new Record(newAlbum);
      string result = newRecord.AlbumTitle;
      Assert.AreEqual(newAlbum, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_RecordList()
    {
      List<Record> newList = new List<Record> { };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    
    [TestMethod]
    public void GetAll_ReturnsAllRecords_RecordList()
    {
      string newAlbum = "Test";
      string newAlbum2 = "Test2";
      Record newRecord = new Record(newAlbum);
      Record newRecord2 = new Record(newAlbum2);
      List<Record> newList = new List<Record> { newRecord, newRecord2 };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
  }
}

// [TestMethod]
// public void NameOfMethodWeAreTesting_DescriptionOfBehavior_ExpectedReturnValue()
// {
//   // any necessary logic to prep for test; instantiating new classes, etc.
//   Assert.AreEqual(EXPECTED RESULT, CODE TO TEST);
// }