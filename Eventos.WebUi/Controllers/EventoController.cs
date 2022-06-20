using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.Enums;
using Eventos.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.WebUi.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        public async Task<IActionResult> Index(CategoriaEnum categoria)
            => View(await _eventoService.BuscarTodos(categoria));

        public IActionResult AdicionarEvento()
            =>View();

        //Eventos
        [HttpPost]
        public async Task<IActionResult> Adicionar(AdicionarEventoInputModel model)
        {
            await _eventoService.AdicionarEvento(model);
            return RedirectToAction("Index");
        }
    }
}
