using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApllicationType;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post-create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApllicationType.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        //Edit - GET

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();


            }
            var obj = _db.ApllicationType.Find(id);
            if (obj == null)
            {
                return NotFound();

            }


            return View(obj);
        }

        //Edit POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApllicationType.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




        //GET Delete

        public IActionResult Delete(int ?id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ApllicationType.Find(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.ApllicationType.Remove(obj);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

    }






}
