// using System.Collections.Generic;
// using System;
// using Microsoft.AspNetCore.Mvc;
// using MusicOrganizer.Models;

// namespace MusicOrganizer.Controllers
// {
//   public class RecordController : Controller
//   {

//     [HttpGet("/objectClass")]
//     public ActionResult Index()
//     {
//       List<Class> allClassObjects = Class.GetAll();
//       return View(allClassObjects);
//     }

//     [HttpGet("/objectClass/new")]
//     public ActionResult New()
//     {
//       return View();
//     }

//     [HttpPost("/objectClass")]
//     public ActionResult Create(string classObjectName)
//     {
//       Class newClass = new Class(classObjectName);
//       return RedirectToAction("Index");
//     }

//     [HttpGet("/objectClass/{id}")]
//     public ActionResult Show(int id)
//     {
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       Class classObjectToShow = Class.Find(id);
//       return View(classObjectToShow);
//     }

//     [HttpPost("/objectClass/{id}/edit")]
//     public ActionResult Edit(int id)
//     {

//       return View();
//     }

//     [HttpPost("/classObjects/delete")]
//     public ActionResult Delete()
//     {
//       Class.ClearAll();
//       return View();
//     }
//   }
// }