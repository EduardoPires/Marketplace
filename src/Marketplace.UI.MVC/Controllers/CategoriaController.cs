using Marketplace.Aplicacao.Interfaces;
using Marketplace.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.UI.MVC.Controllers
{
    [Route("categorias")]
    public class CategoriaController(ILogger<CategoriaController> logger, ICategoriaAppService categoriaAppService) : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService = categoriaAppService;
        private readonly ILogger<CategoriaController> _logger = logger;

        public async Task<IActionResult> Index()
        {
            return View(await _categoriaAppService.ObterTodos());
        }
        [Route("{id:guid}/detalhes")]
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _categoriaAppService.ObterPorId(id));
        }
        [Route("novo")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,Descricao")] Categoria categoria)
        {
            try
            {

                await _categoriaAppService.Adicionar(categoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar produto");
                return View(categoria);
            }

        }
        [Route("editar/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            ;
            return View(await _categoriaAppService.ObterPorId(id));
        }
        [HttpPost("editar/{id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Codigo,Nome,Descricao")] Categoria categoria)
        {
            try
            {
                await _categoriaAppService.Atualizar(categoria);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        [Route("excluir/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _categoriaAppService.ObterPorId(id));
        }
        [HttpPost("excluir/{id:guid}")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoria = await _categoriaAppService.ObterPorId(id);
            await _categoriaAppService.Excluir(categoria);
            return RedirectToAction(nameof(Index));
        }
    }
}
