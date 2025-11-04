using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using test123.Models;

namespace test123.Controllers
{
    public class PeopleController : Controller
    {
        private static List<Person> plist = new List<Person>();
        //private static Person[] people = new Person[0];
        //private static int nextId = 1;

        static PeopleController()
        {
            if (!plist.Any())
            {
                //plist.Clear();
                plist.Add(new Person { Id = 1, Name = "testperson1" });
                plist.Add(new Person { Id = 2, Name = "testperson2" });
                plist.Add(new Person { Id = 3, Name = "testperson3" });
                plist.Add(new Person { Id = 4, Name = "testperson4" });
                //System.Diagnostics.Debug.WriteLine("Aktuelle Anzahl im Array: " + people.Length);
                System.Diagnostics.Debug.WriteLine("Aktuelle Anzahl der Liste: " + plist.Count);
            }
        }

        [HttpGet]
        public ActionResult Index()
        { 
            //Daten von EF lesen und in plist speichern.


            return View(plist);
        }

        [HttpPost]
        public JsonResult GetAll()
        {
            return Json(plist);
        }

        // ---Neu Hinzufügen---

        [HttpPost]
        public JsonResult Add(Person newPerson)
        {
            if (newPerson == null || string.IsNullOrWhiteSpace(newPerson.Name))
                return Json(new { error = "ungültige eingabe" });

            newPerson.Id = plist.Any() ? plist.Max(p => p.Id) + 1 : 1;
            plist.Add(newPerson);


            return Json(newPerson);
        }

        // ---Bearbeiten---

        [HttpPost]
        public JsonResult Edit(int Id, string Name)
        {
            var person = plist.FirstOrDefault(p => p.Id == Id);
            if (person == null)
                return Json(new { error = "Person wurde nicht gefunden" });

            person.Name = Name;

            return Json(person);
        }
    




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}