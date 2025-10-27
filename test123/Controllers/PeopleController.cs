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




        private static Person[] people = new Person[0];
        private static int nextId = 1;

        public ActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("Aktuelle Anzahl im Array: " + people.Length);
            return View(people);
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            Person newPerson = null;
            if (!string.IsNullOrWhiteSpace(name))
            {
                newPerson = new Person
                {
                    Id = nextId,
                    Name = name
                };

                nextId++;

                var newArray = new Person[people.Length + 1];

                for (int i = 0; i < people.Length; i++)
                { 
                    newArray[i] = people[i];
                }

                newArray[people.Length] = newPerson;

                people = newArray;

            }
            System.Diagnostics.Debug.WriteLine("Neuer eintrag hinzugefügt: " + newPerson.Name);
            System.Diagnostics.Debug.WriteLine("Gesamtanzahl: " + people.Length);

            return RedirectToAction("Index");
        }
    }
}