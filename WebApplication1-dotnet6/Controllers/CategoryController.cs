using Microsoft.AspNetCore.Mvc;
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
                ModelState.AddModelError("name", "O Display Order não pode ser igual a 0");
            }                
                
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "O nome não pode ser igual ao Display Order");
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
