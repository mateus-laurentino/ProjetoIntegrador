using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.WebUi.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilService _perfilService;
        private readonly IUsuarioService _usuarioService;

        public PerfilController(IPerfilService perfilService, IUsuarioService usuarioService)
        {
            _perfilService = perfilService;
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index(string usuario, int? idUsuario)
        {
            var usuarioPorId = new UsuarioOutputModel();

            if (idUsuario != null && string.IsNullOrWhiteSpace(usuario))
            {
                usuarioPorId = await _usuarioService.BuscarUsuarioPorIdAsync(idUsuario ?? 0);
                usuario = usuarioPorId.Usuario;
            }

            var result = await _perfilService.BuscarInformacoesUsuarioAsync(usuario);

            return View(result);
        }
    }
}
