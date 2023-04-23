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
    }
}
