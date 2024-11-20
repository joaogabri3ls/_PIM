using Microsoft.AspNetCore.Mvc;

namespace SeuProjeto.Controllers
{
    public class PagamentoController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}