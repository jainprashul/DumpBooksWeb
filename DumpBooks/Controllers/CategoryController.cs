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
        public IActionResult Create(Category category){
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

        // GET: Category/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if (category == null) {
                return NotFound();
            }
            
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            try
            {
                if (category.Name == category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("DisplayOrder", "Display Order must be different from Name");
                }
                if (ModelState.IsValid)
                {
                    _db.Categories.Update(category);
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

        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _db.Categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }




    }
}
