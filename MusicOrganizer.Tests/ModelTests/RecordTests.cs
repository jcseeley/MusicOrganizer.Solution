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
      Class.ClearAll();
    }
    
    [TestMethod]
    public void ClassConstructor_CreatesInstanceOfClass_Object()
    {
      Class newObject = new Class("test");
      Assert.AreEqual(typeof(Class), newObject.GetType()); 
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      string result = newItem.Description;
      Assert.AreEqual(description, result); 
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      string updatedDescription = "Do the dishes.";
      newItem.Description = updatedDescription;
      string result = newItem.Description;
      Assert.AreEqual(updatedDescription, result); 
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_ItemList()
    {
      List<Item> newList = new List<Item> { };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);
      List<Item> newList = new List<Item> { newItem1, newItem2 };
      List<Item> result = Item.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);
      int result = newItem.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);
      Item result = Item.Find(2);
      Assert.AreEqual(newItem2, result);
    }
  }
}

// [TestMethod]
// public void NameOfMethodWeAreTesting_DescriptionOfBehavior_ExpectedReturnValue()
// {
//   // any necessary logic to prep for test; instantiating new classes, etc.
//   Assert.AreEqual(EXPECTED RESULT, CODE TO TEST);
// }