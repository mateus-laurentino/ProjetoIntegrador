using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IService
{
    public interface IEventoService
    {
        Task<List<EventoOutputModel>> BuscarTodos(CategoriaEnum? categoria, int? idUsuario);
        Task<bool> AdicionarEvento(AdicionarEventoInputModel model);
        Task<UsuarioOutputModel> LoginValidoAsync(LoginInputModel model);
        Task<EventoOutputModel> BuscarPorId(int id);
        Task<bool> CancelarParticipacaoEventoAsync(int idEvento, int idUsuario);
        Task<bool> CancelarEventoAsync(int idEvento, int idUsuario);
    }
}
