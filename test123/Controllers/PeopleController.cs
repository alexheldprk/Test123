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




        private static List<Person> people = new List<Person>();
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

                people.Add(newPerson);

            }
            return RedirectToAction("Index");
        }
    }
}