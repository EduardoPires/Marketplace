using Marketplace.Aplicacao.Interfaces;
using Marketplace.Aplicacao;
using Marketplace.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Marketplace.UI.MVC.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IProdutoAppService produtoAppService) : Controller
    {
        private readonly IProdutoAppService _produtoAppService = produtoAppService;
        private readonly ILogger<HomeController> _logger = logger;

        public async Task<IActionResult> Index()
        {
            return View(await _produtoAppService.ObterTodos());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
