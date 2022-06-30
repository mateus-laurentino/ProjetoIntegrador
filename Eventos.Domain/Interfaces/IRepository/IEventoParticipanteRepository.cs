using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface IEventoParticipanteRepository : IBaseRepostiry<EventoParticipanteEntity, int>
    {
        Task<List<int>> BuscarEventosIdUsuario(int? idUsuario);
        Task<bool> CancelarParticipacaoEventoAsync(int idUsuario, int idEvento);
        Task<List<EventoParticipanteEntity>> ProcurarPorIdEvento(int idEvento);
    }
}
