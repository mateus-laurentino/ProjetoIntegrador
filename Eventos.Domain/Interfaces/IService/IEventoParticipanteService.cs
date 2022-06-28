using Eventos.Domain.DTOs.InputModel;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IService
{
    public interface IEventoParticipanteService
    {
        Task<bool> ConfirmarParticipacaoAsync(ComprarInputModel model);
    }
}
