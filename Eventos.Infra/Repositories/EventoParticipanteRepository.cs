using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Infra.Context;
using Eventos.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Infra.Repositories
{
    public class EventoParticipanteRepository : BaseRepository<EventoParticipanteEntity, int>, IEventoParticipanteRepository
    {
        public EventoParticipanteRepository(EventoContext context) : base(context)
        {

        }

        public async Task<List<int>> BuscarEventosIdUsuario(int? idUsuario)
            => await _dataSet
            .Where(x => x.IdUsuario == idUsuario)
            .Select(x => x.IdEvento)
            .ToListAsync();
    }
}
