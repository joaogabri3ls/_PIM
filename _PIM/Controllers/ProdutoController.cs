using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _PIM.Data;
using _PIM.Models;
using System.Threading.Tasks;

namespace _PIM.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produto.ToListAsync();
            return View(produtos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Produto não encontrado.";
                return RedirectToAction(nameof(Index));
            }

            var produtoModel = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoModel == null)
            {
                TempData["ErrorMessage"] = "Produto não encontrado.";
                return RedirectToAction(nameof(Index));
            }

            return View(produtoModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,Quantidade")] ProdutoModel produtoModel, IFormFile Imagem)
        {
            if (ModelState.IsValid)
            {

                if (Imagem != null && Imagem.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid()}_{Imagem.FileName}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Imagem.CopyToAsync(stream);
                    }

                    // Define o caminho da imagem no produto
                    produtoModel.UrlImagem = $"/images/{fileName}";
                }

                _context.Produto.Add(produtoModel);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Produto criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            if (!ModelState.IsValid)
            {
                // Temporário para debug: imprime erros no ModelState
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }

            return View(produtoModel);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Produto não encontrado.";
                return RedirectToAction(nameof(Index));
            }

            var produtoModel = await _context.Produto.FindAsync(id);
            if (produtoModel == null)
            {
                TempData["ErrorMessage"] = "Produto não encontrado.";
                return RedirectToAction(nameof(Index));
            }
            return View(produtoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Quantidade,UrlImagem")] ProdutoModel produtoModel)
        {
            if (id != produtoModel.Id)
            {
                TempData["ErrorMessage"] = "Produto não encontrado.";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoModel);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Produto atualizado com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoModelExists(produtoModel.Id))
                    {
                        TempData["ErrorMessage"] = "Erro ao atualizar: Produto não encontrado.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produtoModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "Produto não encontrado.";
                return RedirectToAction(nameof(Index));
            }

            var produtoModel = await _context.Produto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoModel == null)
            {
                TempData["ErrorMessage"] = "Produto não encontrado.";
                return RedirectToAction(nameof(Index));
            }

            return View(produtoModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoModel = await _context.Produto.FindAsync(id);
            if (produtoModel != null)
            {
                _context.Produto.Remove(produtoModel);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Produto excluído com sucesso!";
            }
            else
            {
                TempData["ErrorMessage"] = "Erro ao excluir: Produto não encontrado.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoModelExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
    }
}
