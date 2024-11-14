using _PIM.Data;
using _PIM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

[Authorize]
public class VendaController : Controller
{
    private readonly ApplicationDbContext _context;

    public VendaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult FinalizarCompra()
    {
        var itensCarrinho = ObterItensCarrinho();
        var totalVenda = itensCarrinho.Sum(item => item.PrecoUnitario * item.Quantidade);
        var venda = new Venda
        {
            ItensVenda = itensCarrinho,
            Total = totalVenda
        };
        return View(venda);
    }

    [HttpPost]
    public async Task<IActionResult> FinalizarCompra(Venda venda)
    {
        if (ModelState.IsValid)
        {
            venda.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            venda.DataVenda = DateTime.Now;

            foreach (var item in venda.ItensVenda)
            {
                var produto = _context.Produto.FirstOrDefault(p => p.Id == item.ProdutoId);
                if (produto != null)
                {
                    item.PrecoUnitario = produto.Preco;
                }
            }

            _context.Vendas.Add(venda);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Compra finalizada com sucesso!";

            return RedirectToAction("Detalhes", new { id = venda.VendaId });
        }

        return View(venda);
    }
    public async Task<IActionResult> Detalhes(int id)
    {
        var venda = await _context.Vendas
            .Include(v => v.User) // Incluindo os dados do usuário
            .Include(v => v.ItensVenda) // Incluindo os itens da venda
            .ThenInclude(iv => iv.Produto) // Incluindo os dados do produto relacionado a cada item
            .FirstOrDefaultAsync(v => v.VendaId == id);

        // Se a venda não for encontrada
        if (venda == null)
        {
            return NotFound();
        }

        // Exibindo a view com os detalhes da venda
        return View(venda);
    }

    // Ação para simular o envio da venda
    public async Task<IActionResult> SimularEnvio(int id)
    {
        var venda = await _context.Vendas.FindAsync(id);

        // Se a venda não for encontrada
        if (venda == null)
        {
            return NotFound();
        }

        // Verificando se o status já está como Enviado
        if (venda.StatusEnvio == StatusEnvio.Pendente)
        {
            venda.StatusEnvio = StatusEnvio.Enviado;
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();

            // Exibindo mensagem de sucesso
            TempData["SuccessMessage"] = "Venda marcada como enviada!";
        }
        else
        {
            // Exibindo mensagem caso o status já tenha sido alterado
            TempData["ErrorMessage"] = "Esta venda já foi enviada!";
        }

        // Redirecionando para a página de detalhes da venda
        return RedirectToAction("Detalhes", new { id = venda.VendaId });
    }
}
