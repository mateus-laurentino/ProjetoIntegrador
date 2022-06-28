using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository.Base;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface IUsuarioRepository : IBaseRepostiry<UsuarioEntity, int>
    {
        Task<UsuarioOutputModel> LoginValidoAsync(LoginInputModel model);
        Task<UsuarioOutputModel> BuscarUsuarioAsync(string nomeUsuario);
    }
}
