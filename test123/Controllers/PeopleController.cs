using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test123.Models;

namespace test123.Controllers
{
    public class PeopleController : Controller
    {
        private static List<Person> plist = new List<Person>();
        private static Person[] people = new Person[0];
        private static int nextId = 1;

        static PeopleController()
        {
            //plist.Clear();
            plist.Add(new Person { Id = 999, Name = "testperson" });
            plist.Add(new Person { Id = 999, Name = "testperson" });
            plist.Add(new Person { Id = 999, Name = "testperson" });
            plist.Add(new Person { Id = 999, Name = "testperson" });
            System.Diagnostics.Debug.WriteLine("Aktuelle Anzahl im Array: " + people.Length);
            System.Diagnostics.Debug.WriteLine("Aktuelle Anzahl im Array: " + plist.Count);
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
        public JsonResult Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Json(new { error = "Name darf nicht leer sein." });
            }

            Person newPerson = new Person 
            { 
                Id = nextId++, Name = name 
            };

            nextId++;
           
                var newArray = new Person[people.Length + 1];

            for (int i = 0; i < people.Length; i++)
            {
                newArray[i] = people[i];
            }
                newArray[newArray.Length - 1] = newPerson;
                people = newArray;

                System.Diagnostics.Debug.WriteLine("Neuer eintrag hinzugefügt: " + newPerson.Name);
                System.Diagnostics.Debug.WriteLine("Gesamtanzahl: " + people.Length);

                return Json(newPerson);            
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