using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System; 
using System.Collections.Generic;

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

    [TestMethod]
    public void GetId_RecordsInstantiateWithIdAndGetterReturns_Int()
    {
      string albumTitle = "test";
      Record newRecord = new Record(albumTitle);
      int result = newRecord.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void FindId_ReturnsCorrectRecord_Record()
    {
      string album = "test";
      string album2 = "test2";
      Record newRecord = new Record(album);
      Record newRecord2 = new Record(album2);
      Record result = Record.Find(2);
      Assert.AreEqual(newRecord2, result);
    }
  }
}