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
    }
}
