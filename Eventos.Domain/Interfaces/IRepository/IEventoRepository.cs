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
        Task<List<EventoOutputModel>> BuscarTodos(CategoriaEnum? categoria, int? idUsuario);
        Task<bool> AdicionarEvento(AdicionarEventoInputModel model);
    }
}
