using Eventos.Domain.Interfaces.IRepository.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Eventos.Infra.Repositories.Common
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : DbContext
    {
        private readonly T _context;

        public UnitOfWork(T context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
