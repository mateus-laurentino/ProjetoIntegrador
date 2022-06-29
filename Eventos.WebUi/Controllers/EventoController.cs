using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Enums;
using Eventos.Domain.Interfaces.IService;
using Eventos.WebUi.Resoucer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.WebUi.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoService _eventoService;
        private readonly ILogadoService _logadoService;
        private readonly IUsuarioService _usuarioService;

        public EventoController(IEventoService eventoService,
            ILogadoService logadoService,
            IUsuarioService usuarioService)
        {
            _eventoService = eventoService;
            _logadoService = logadoService;
            _usuarioService = usuarioService;
        }

        //Telas
        public async Task<IActionResult> Index(CategoriaEnum? categoria)
        {
            var retorno = await _logadoService.VerificarSeLogadoAsync();

            var usuario = await _usuarioService.BuscarUsuarioAsync(retorno);

            if (usuario == null)
                usuario = new UsuarioOutputModel { Id = null };

            ViewData["Usuario"] = retorno;

            return View(await _eventoService.BuscarTodos(categoria, usuario.Id));
        }

        public IActionResult Login()
            => View();

        public IActionResult AdicionarEvento(int? idUsuario)
            => View(new AdicionarEventoInputModel { IdUsuarioOrganizador = idUsuario ?? 10 });

        //Ações
        [HttpPost]
        public async Task<IActionResult> CadastrarEvento(AdicionarEventoInputModel model)
        {
            await _eventoService.AdicionarEvento(model);
            var usuario = await _usuarioService.BuscarUsuarioPorIdAsync(model.IdUsuarioOrganizador);
            return RedirectToAction("Index","Perfil", new { usuario = usuario.Usuario });
        }

        //Login
        public async Task<IActionResult> Logout()
        {
            var retorno = await _logadoService.DeslogarAsync();

            ViewData["Usuario"] = retorno;

            return View("Index", await _eventoService.BuscarTodos(null, null));
        }

        [HttpPost]
        public async Task<IActionResult> Logar(LoginInputModel model)
        {
            var usuario = await _eventoService.LoginValidoAsync(model);

            if (usuario == null)
            {
                ViewData["Error"] = ServiceResources.UsuarioSenhaInvalidos;

                return View("Login");
            }

            await _logadoService.Logar(usuario.Usuario);

            ViewData["Usuario"] = usuario.Usuario;

            return View("Index", await _eventoService.BuscarTodos(null, usuario.Id));
        }
    }
}
