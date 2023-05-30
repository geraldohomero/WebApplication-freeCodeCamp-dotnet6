﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1_dotnet6.Data;
using WebApplication1_dotnet6.Models;

namespace WebApplication1_dotnet6.Controllers
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
           IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.DisplayOrder == 0)
            {         
                ModelState.AddModelError("DisplayOrder", "The Display Order cannot be 0");
            }                
                
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "The Display Order cannot exactly match the Name");
                ModelState.AddModelError("name", "The Name cannot exactly match the Display Order");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
   

//GET
    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
    
        if(categoryFromDb == null)
        {
            return NotFound();
        }
    
        return View(categoryFromDb);
}
    
    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if (obj.DisplayOrder == 0)
        {
            ModelState.AddModelError("DisplayOrder", "The Display Order cannot be 0");
        }
    
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("DisplayOrder", "The Display Order cannot exactly match the Name");
            ModelState.AddModelError("name", "The Name cannot exactly match the Display Order");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }
        }

}


