using Eventos.Domain.DTOs.OutputModel;
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

        public async Task<List<EventoOutputModel>> BuscarTodos()
            => await _eventoRepository.BuscarTodos();
    }
}
