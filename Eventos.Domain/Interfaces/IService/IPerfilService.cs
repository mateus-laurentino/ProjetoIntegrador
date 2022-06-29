using Eventos.Domain.DTOs.OutputModel;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IService
{
    public interface IPerfilService
    {
        Task<EventosUsuarioOutputModel> BuscarInformacoesUsuarioAsync(string nomeUsuario);
    }
}
