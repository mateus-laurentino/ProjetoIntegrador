using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Enums;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Application.Service
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<List<EventoOutputModel>> BuscarTodos(CategoriaEnum categoria)
            =>await _eventoRepository.BuscarTodos(categoria);

        public async Task<bool> AdicionarEvento(AdicionarEventoInputModel model)
            => await _eventoRepository.AdicionarEvento(model);
    }
}
