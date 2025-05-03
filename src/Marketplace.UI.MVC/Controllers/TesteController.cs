using Marketplace.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.UI.MVC.Controllers
{
    public class TesteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(IFormFile Imagem)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}
