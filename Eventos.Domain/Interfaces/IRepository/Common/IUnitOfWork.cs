using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository.Common
{
    public interface IUnitOfWork<T> where T : DbContext
    {
        Task CommitAsync();
    }
}
