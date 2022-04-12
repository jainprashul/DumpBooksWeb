using DumpBooks.Data;
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
            var categories = _db.Categories.ToList();
            return View(categories);
        }
    }
}
