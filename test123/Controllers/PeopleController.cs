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
            return View(plist);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(plist);
        }

        [HttpPost]
        public JsonResult Add(Person newPerson)
        {
            if (newPerson == null || string.IsNullOrWhiteSpace(newPerson.Name))
                return Json(new { error = "ungültige eingabe" });

            newPerson.Id = plist.Any() ? plist.Max(p => p.Id) + 1 : 1;
            plist.Add(newPerson);
            

            return Json(newPerson);
        }
    

        //[HttpPost]
        //public JsonResult Add(string name)
        //{
        //    if (string.IsNullOrWhiteSpace(name))
        //    {
        //        return Json(new { error = "Name darf nicht leer sein." });
        //    }

        //    Person newPerson = new Person 
        //    { 
        //        Id = nextId++, Name = name 
        //    };

        //    nextId++;

        //        var newArray = new Person[people.Length + 1];

        //    for (int i = 0; i < people.Length; i++)
        //    {
        //        newArray[i] = people[i];
        //    }
        //        newArray[newArray.Length - 1] = newPerson;
        //        people = newArray;

        //        System.Diagnostics.Debug.WriteLine("Neuer eintrag hinzugefügt: " + newPerson.Name);
        //        System.Diagnostics.Debug.WriteLine("Gesamtanzahl: " + people.Length);

        //        return Json(newPerson);            
        //}

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