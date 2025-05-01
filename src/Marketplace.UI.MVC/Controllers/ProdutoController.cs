using Marketplace.Aplicacao.Interfaces;
using Marketplace.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Marketplace.UI.MVC.Controllers
{
    [Route("meus-produtos")]
    public class ProdutoController(ILogger<ProdutoController> logger, IProdutoAppService produtoAppService, ICategoriaAppService categoriaAppService) : Controller
    {
        private readonly IProdutoAppService _produtoAppService = produtoAppService;
        private readonly ICategoriaAppService _categoriaAppService = categoriaAppService;
        private readonly ILogger<ProdutoController> _logger = logger;

        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.ObterTodos());
        }

        [Route("novo")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = new SelectList(await _categoriaAppService.ObterTodos(), "Codigo", "Nome");
            return View();
        }

        [HttpPost("novo")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,Descricao,Preco,Estoque,CategoriaCodigo")] Produto produto, IFormFile Imagem)
        {
            try
            {
                if (Imagem != null && Imagem.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await Imagem.CopyToAsync(ms);
                        produto.Imagem = ms.ToArray();
                    }
                }
                await _produtoAppService.Adicionar(produto);
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar produto");
                return View(produto);
            }

        }
    }
}
