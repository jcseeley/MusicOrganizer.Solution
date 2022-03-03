using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System;
using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  [TestClass]
  public class ArtistTests
  {
    [TestMethod]
    public void ArtistConstructor_CreatesArtistObject_Object()
    {
      Artist newArtist = new Artist();
      Assert.AreEqual(typeof(Artist),newArtist.GetType());
    }
  }
}

// [TestMethod]
// public void NameOfMethodWeAreTesting_DescriptionOfBehavior_ExpectedReturnValue()
// {
//   // any necessary logic to prep for test; instantiating new classes, etc.
//   Assert.AreEqual(EXPECTED RESULT, CODE TO TEST);
// }
