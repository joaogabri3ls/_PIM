using Microsoft.AspNetCore.Mvc;

namespace _PIM.Controllers
{
    public class Admincontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            return View("~/Views/Produto/Index.cshtml");

        }
    }
}