using Microsoft.AspNetCore.Mvc;

namespace DumpBooks.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
