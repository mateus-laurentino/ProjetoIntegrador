using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Infra.Context;
using Eventos.Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Infra.Repositories
{
    public class EventoParticipanteRepository : BaseRepository<EventoParticipanteEntity, int>, IEventoParticipanteRepository
    {
        public EventoParticipanteRepository(EventoContext context) : base(context)
        {

        }
    }
}
