using Eventos.Application.Service;
using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eventos.WebUi.Controllers
{
    public class CompraController : Controller
    {
        private readonly IEventoService _eventoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IEventoParticipanteService _eventoParticipanteService;

        public CompraController(IEventoService eventoService,
            IUsuarioService suarioService,
            IEventoParticipanteService eventoParticipanteService)
        {
            _eventoService = eventoService;
            _usuarioService = suarioService;
            _eventoParticipanteService = eventoParticipanteService;
        }

        public async Task<IActionResult> DetalhesCompra(int id, string nome)
        {
            var evento = await _eventoService.BuscarPorId(id);

            var usuario = await _usuarioService.BuscarUsuarioAsync(nome);

            return View(new DetalhesVendaOutputModel(evento, usuario));
        }

        public IActionResult Pagamento(ComprarInputModel model)
            => View(model);
        public async Task<IActionResult> Confirmar(ComprarInputModel model)
        {
            var result = await _eventoParticipanteService.ConfirmarParticipacaoAsync(model);


            return RedirectToAction("Index","Evento");
        }
    }
}
