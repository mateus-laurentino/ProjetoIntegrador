using Eventos.Domain.DTOs.OutputModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IService
{
    public interface IEventoService
    {
        Task<List<EventoOutputModel>> BuscarTodos();
    }
}
