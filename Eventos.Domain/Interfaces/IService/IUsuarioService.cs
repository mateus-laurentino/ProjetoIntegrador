using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IService
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputModel> BuscarUsuarioAsync(string nomeUsuario);
        Task<UsuarioOutputModel> BuscarUsuarioPorIdAsync(int id);
        Task<bool> CadastrarUsuario(CadastrarUsuarioInputModel model);
    }
}
