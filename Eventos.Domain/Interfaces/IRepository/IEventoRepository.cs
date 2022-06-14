using Eventos.Domain.DTOs.OutputModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface IEventoRepository
    {
        Task<List<EventoOutputModel>> BuscarTodos();
    }
}
