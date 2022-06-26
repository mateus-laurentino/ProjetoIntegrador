using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Enums;
using Eventos.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.WebUi.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoService _eventoService;
        private readonly ILogadoService _logadoService;

        public EventoController(IEventoService eventoService,
            ILogadoService logadoService)
        {
            _eventoService = eventoService;
            _logadoService = logadoService;
        }

        //Telas
        public async Task<IActionResult> Index(CategoriaEnum? categoria)
        {
            var retorno = await _logadoService.VerificarSeLogadoAsync();

            var usuario = await _logadoService.BuscarUsuarioAsync(retorno);

            if (usuario == null)
                usuario = new UsuarioOutputModel { Id = null};

            ViewData["Usuario"] = retorno;

            return View(await _eventoService.BuscarTodos(categoria, usuario.Id));
        }

        public IActionResult Login()
            => View();

        public IActionResult Perfil()
            => View();

        public IActionResult AdicionarEvento()
            => View();

        public async Task<IActionResult> Comprar(int id, string nome)
        {
            var evento = await _eventoService.BuscarPorId(id);

            var usuario = await _logadoService.BuscarUsuarioAsync(nome);

            return View(new DetalhesVendaOutputModel(evento, usuario));
        }
        //Buscas

        //Ações
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
                return View("Login");

            await _logadoService.Logar(usuario.Usuario);

            ViewData["Usuario"] = usuario.Usuario;

            return View("Index", await _eventoService.BuscarTodos(null, usuario.Id));
        }
    }
}
