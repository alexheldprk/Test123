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
            return View(people);
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var newPerson = new Person
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
            return RedirectToAction("Index");
        }
    }
}