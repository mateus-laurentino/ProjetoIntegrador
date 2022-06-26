using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface IUsuarioRepository
    {
        Task<UsuarioOutputModel> LoginValidoAsync(LoginInputModel model);
        Task<UsuarioOutputModel> BuscarUsuarioAsync(string nomeUsuario);
    }
}
