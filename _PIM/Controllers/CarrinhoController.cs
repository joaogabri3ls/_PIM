using _PIM.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

public class CarrinhoController : Controller
{
    [HttpPost]
    public IActionResult Pagamento([FromBody] List<ItemCarrinho> carrinho)
    {
        if (carrinho == null || !carrinho.Any())
        {
            return RedirectToAction("Index", "Home");
        }

        TempData["Carrinho"] = JsonConvert.SerializeObject(carrinho);

        return RedirectToAction("Index", "Pagamento");
    }
}
