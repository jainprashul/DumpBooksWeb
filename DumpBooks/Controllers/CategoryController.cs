using DumpBooks.Data;
using DumpBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace DumpBooks.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBContext _db;

        public CategoryController(AppDBContext appDB)
        {
            _db = appDB;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories;
            return View(categories);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                if(category.Name == category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("DisplayOrder", "Display Order must be different from Name");
                }
                
                if (ModelState.IsValid)
                {
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }
    }
}
