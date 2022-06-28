using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository.Base;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface IEventoParticipanteRepository : IBaseRepostiry<EventoParticipanteEntity, int>
    {
    }
}
