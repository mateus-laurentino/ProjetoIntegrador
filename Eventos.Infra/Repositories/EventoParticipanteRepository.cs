using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Infra.Context;
using Eventos.Infra.Repositories.Base;

namespace Eventos.Infra.Repositories
{
    public class EventoParticipanteRepository : BaseRepository<EventoParticipanteEntity, int>, IEventoParticipanteRepository
    {
        public EventoParticipanteRepository(EventoContext context) : base(context)
        {

        }
    }
}
