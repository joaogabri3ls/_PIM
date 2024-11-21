using _PIM.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SeuProjeto.Controllers
{
    public class PagamentoController : Controller
    {
        public IActionResult Index()
        {
            var carrinhoJson = TempData["Carrinho"] as string;
            var carrinho = string.IsNullOrEmpty(carrinhoJson)
                ? new List<ItemCarrinho>()
                : JsonConvert.DeserializeObject<List<ItemCarrinho>>(carrinhoJson);

            return View(carrinho);
        }
    }
}