using Eventos.Domain.Entities;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface ICartaoRepository
    {
        Task<CartaoUsuarioEntity> ProcurarPorIdUsuarioAsync(int idUsuario);
    }
}
