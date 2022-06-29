using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository.Base;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface ICartaoRepository : IBaseRepostiry<CartaoUsuarioEntity, int>
    {
        Task<CartaoUsuarioEntity> ProcurarPorIdUsuarioAsync(int idUsuario);
    }
}
