using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_1.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Person()
        {
            ViewBag.NewPerson = "This is a new person.";
            ViewBag.PersonName = "His name is Skylar.";
            ViewBag.PersonJob = "He works as a trainer at the local gym";
            return View();
        }
    }
}