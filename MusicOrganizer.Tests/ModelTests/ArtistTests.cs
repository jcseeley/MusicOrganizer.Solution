// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using MusicOrganizer.Models;
// using System;
// using System.Collections.Generic;

// namespace MusicOrganizer.Models
// {
//   [TestClass]
//   public class ArtistTests : IDisposable
//   {
//     public void Dispose()
//     {
//       Artist.ClearAll();
//     }
//     public ArtistTests()
//     {
//       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer_test;";
//     }

//     [TestMethod]
//     public void ArtistConstructor_CreatesArtistObject_Object()
//     {
//       Artist newArtist = new Artist("Artist");
//       Assert.AreEqual(typeof(Artist),newArtist.GetType());
//     }

//     [TestMethod]
//     public void Save_SavesToDatabase_RecordList()
//     {
//       Artist testArtist = new Artist("The Beatles");

//       testArtist.Save();
//       List<Artist> result = Artist.GetAll();
//       List<Artist> testList = new List<Artist>{testArtist};

//       CollectionAssert.AreEqual(testList, result);
//     }

//     [TestMethod]
//     public void GetName_ReturnsName_String()
//     {
//       string name = "Artist";
//       Artist newArtist = new Artist(name);
//       string result = newArtist.Name;
//       Assert.AreEqual(name, result);
//     }

//     [TestMethod]
//     public void GetId_ReturnsArtistId_Int()
//     {
//       string name = "Artist";
//       Artist newArtist = new Artist(name);
//       int result = newArtist.Id;
//       Assert.AreEqual(1, result);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsAllArtistObjects_ArtistList()
//     {
//       string name = "Artist";
//       string name1 = "Artist1";
//       Artist newArtist = new Artist(name);
//       newArtist.Save();
//       Artist newArtist2 = new Artist(name1);
//       newArtist2.Save();
//       List<Artist> newList = new List<Artist> { newArtist, newArtist2 };
//       List<Artist> result = Artist.GetAll();
//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void Find_ReturnsCorrectArtistFromDatabase_Artist()
//     {
//       string name = "Artist";
//       string name1 = "Artist1";
//       Artist newArtist = new Artist(name);
//       newArtist.Save();
//       Artist newArtist2 = new Artist(name1);
//       newArtist2.Save();
      
//       Artist foundArtist = Artist.Find(newArtist2.Id);

//       Assert.AreEqual(newArtist2, foundArtist);
//     }

//     [TestMethod]
//     public void AddRecord_AssociatesRecordWithArtist_RecordList()
//     {
//       string albumTitle = "Album";
//       Record newRecord = new Record(albumTitle);
//       List<Record> newList = new List<Record> { newRecord };
//       string name = "Artist";
//       Artist newArtist = new Artist(name);
//       newArtist.AddRecord(newRecord);
//       List<Record> result = newArtist.Records;
//       CollectionAssert.AreEqual(newList, result);
//     }
//   }
// }

// [TestMethod]
// public void NameOfMethodWeAreTesting_DescriptionOfBehavior_ExpectedReturnValue()
// {
//   // any necessary logic to prep for test; instantiating new classes, etc.
//   Assert.AreEqual(EXPECTED RESULT, CODE TO TEST);
// }