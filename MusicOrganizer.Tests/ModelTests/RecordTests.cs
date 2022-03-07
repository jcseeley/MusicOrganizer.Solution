using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using MySql.Data.MySqlClient;
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

    public RecordTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Record()
    {
      Record firstRecord = new Record("Mow the lawn");
      Record secondRecord = new Record("Mow the lawn");

      // Assert
      Assert.AreEqual(firstRecord, secondRecord);
    }
    
    [TestMethod]
    public void Save_SavesToDatabase_RecordList()
    {
      Record testRecord = new Record("Dark Side of the Moon");

      testRecord.Save();
      List<Record> result = Record.GetAll();
      List<Record> testList = new List<Record>{testRecord};

      CollectionAssert.AreEqual(testList, result);
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
    public void GetAll_ReturnsEmptyListFromDatabase_RecordList()
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
      newRecord.Save();
      Record newRecord2 = new Record(newAlbum2);
      newRecord2.Save();
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
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectRecordFromDatabase_Record()
    {
      Record newRecord = new Record("Soul");
      newRecord.Save();
      Record newRecord2 = new Record("Abby Road");
      newRecord2.Save();

      Record foundRecord = Record.Find(newRecord.Id);
    
      Assert.AreEqual(newRecord, foundRecord);
    }
  }
}