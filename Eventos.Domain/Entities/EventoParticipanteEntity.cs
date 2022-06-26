using Eventos.Domain.Entities.Base;

namespace Eventos.Domain.Entities
{
    public class EventoParticipanteEntity : BaseEntity<int>
    {
        public int IdEvento { get; private set; }
        public int IdUsuario { get; private set; }
    }
}
