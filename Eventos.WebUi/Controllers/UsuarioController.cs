using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.WebUi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogadoService _logadoService;

        public UsuarioController(IUsuarioService usuarioService, 
            ILogadoService logadoService)
        {
            _usuarioService = usuarioService;
            _logadoService = logadoService;
        }

        public IActionResult Index()
            => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarUsuarioInputModel model)
        {
            await _usuarioService.CadastrarUsuario(model);

            await _logadoService.Logar(model.Usuario);

            return RedirectToAction("Index","Perfil", new { usuario = model.Usuario});
        }
    }
}
