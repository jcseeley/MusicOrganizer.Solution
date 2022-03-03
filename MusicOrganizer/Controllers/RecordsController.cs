using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {

    [HttpGet("/records")]
    public ActionResult Index()
    {
      List<Record> allRecords = Record.GetAll();
      return View(allRecords);
    }

    [HttpGet("/records/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/records")]
    public ActionResult Create(string record)
    {
      Record newRecord = new Record(record);
      return RedirectToAction("Index");
    }

    [HttpGet("/records/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Record recordToShow = Record.Find(id);
      return View(recordToShow);
    }

    [HttpPost("/records/delete")]
    public ActionResult Delete()
    {
      Record.ClearAll();
      return View();
    }
  }
}