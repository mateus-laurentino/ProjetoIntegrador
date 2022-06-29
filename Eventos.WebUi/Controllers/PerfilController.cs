using Eventos.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.WebUi.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilService _perfilService;

        public PerfilController(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        public async Task<IActionResult> Index(string usuario)
        {
            var result = await _perfilService.BuscarInformacoesUsuarioAsync(usuario);

            return View(result);
        }
    }
}
