using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Enums;
using Eventos.Domain.Interfaces.IRepository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface IEventoRepository : IBaseRepostiry<InfoEventoEntity, int>
    {
        Task<List<EventoOutputModel>> BuscarTodos(CategoriaEnum? categoria, int? idUsuario, List<int> idEventoParticipante);
        Task<bool> AdicionarEvento(AdicionarEventoInputModel model);
        Task<List<EventoOutputModel>> BuscarEventosParticipanteAsync(List<int> idEventos);
        Task<List<EventoOutputModel>> BuscarEventosOrganizadorAsync(int idUsuario);
        Task<InfoEventoEntity> CancelarEventoAsync(int idEvento, int idUsuario);
    }
}
