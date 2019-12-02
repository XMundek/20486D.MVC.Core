using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Model;
using CRM.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class PersonController : Controller
    {
        ICrmRepository _repository;
        public PersonController(ICrmRepository repository)
        {
            _repository = repository;
        }
        // GET: Person
        public ActionResult Index(PersonIndexModel model)
        {
            if (model == null) model = new PersonIndexModel();
            if (model.LastName == null) model.LastName = string.Empty;
                
            model.People = _repository.GetPersonList(model.LastName);
            return View(model);
        }
        public ActionResult _List(string LastName)
        {
            if (LastName == null) LastName = string.Empty;

            var model = _repository.GetPersonList(LastName);
            return PartialView(model);
        }
        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return GetViewById(id);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person p)
        {
            return Save(p);
        }
        private ActionResult Save(Person p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    _repository.SavePerson(p);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("A", "ala ma kota");
                return View(p);
            }
            catch
            {
                return View();
            }
        }


        private ActionResult GetViewById(int id)
        {
            return View(_repository.GetPerson(id));
        }
        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return GetViewById(id);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person p)
        {            
            return Save(p);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.DeletePerson(id);
            return RedirectToAction(nameof(Index));
        }

    }
}