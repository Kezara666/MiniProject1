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
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post-create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id==0||id==null)
            {
                return NotFound();
               

            }
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();

            }
            
       
            return View(obj);
        }

        //POST-EDIT

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category obj)
        {
            if (ModelState.IsValid)
            {            
                _db.Category.Update(obj);
                _db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View();
        }


        //GET-DELETE

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();


            }
            var obj = _db.Category.Find(id);         
            if (obj == null)
            {
                return NotFound();

            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


            return View(obj);
        }







    }
}
