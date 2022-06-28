using Eventos.Domain.Entities.Base;
using Eventos.Domain.Interfaces.IRepository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Infra.Repositories.Base
{
    public abstract class BaseRepository<T, TPK> : IBaseRepostiry<T, TPK> where T : BaseEntity<TPK>
    {
        protected readonly DbContext _context;

        protected readonly DbSet<T> _dataSet;

        protected BaseRepository(DbContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public async Task<T> InserirAsync(T entity)
        {
            await _dataSet.AddAsync(entity);
            return entity;
        }
        public async Task<T> AtualizarAsync(T entity)
        {
            T result = await _dataSet.FindAsync(entity.Id);
            if (result == null)
            {
                return null;
            }

            _context.Entry(result).CurrentValues.SetValues(entity);
            return entity;
        }
        public async Task<bool> DeletarAsync(TPK id)
        {
            T result = await _dataSet.FindAsync(id);
            if (result == null)
            {
                return false;
            }

            _dataSet.Remove(result);
            return true;
        }
        public async Task<T> ProcurarPorIdAsync(TPK id)
            => await _dataSet.FindAsync(id);
        public async Task<IEnumerable<T>> BuscarTodosAsync()
            => await _dataSet.ToListAsync();
    }
}
