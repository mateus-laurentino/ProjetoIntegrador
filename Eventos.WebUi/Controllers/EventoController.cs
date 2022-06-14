using Eventos.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.WebUi.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        public IActionResult Index()
            => View( _eventoService.BuscarTodos());
    }
}
