using Eventos.Domain.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IRepository.Base
{
    public interface IBaseRepostiry<T, TPK> where T : BaseEntity<TPK>
    {
        Task<T> InserirAsync(T entity);
        Task<T> AtualizarAsync(T entity);
        Task<bool> DeletarAsync(TPK id);
        Task<T> ProcurarPorIdAsync(TPK id);
        Task<IEnumerable<T>> BuscarTodosAsync();
    }
}
