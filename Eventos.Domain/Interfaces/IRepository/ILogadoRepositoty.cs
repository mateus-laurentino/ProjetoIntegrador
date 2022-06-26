using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository.Base;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository
{
    public interface ILogadoRepositoty : IBaseRepostiry<LogadoEntity, int>
    {
        Task<LogadoEntity> VerificarSeLogadoAsync();
    }
}
