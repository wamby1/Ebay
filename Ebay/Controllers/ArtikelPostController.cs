using Microsoft.AspNetCore.Mvc;

namespace Ebay.Controllers
{
    public class ArtikelPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateArtikel()
        {
            return View();
        }
        public IActionResult CreateEditArtikel(int id)
        {
            return View();
        }
    }
}
