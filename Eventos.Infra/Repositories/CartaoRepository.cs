using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Infra.Context;
using Eventos.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Eventos.Infra.Repositories
{
    public class CartaoRepository : BaseRepository<CartaoUsuarioEntity, int>, ICartaoRepository
    {
        public CartaoRepository(EventoContext context) : base(context)
        {

        }

        public async Task<CartaoUsuarioEntity> ProcurarPorIdUsuarioAsync(int idUsuario)
            => await _dataSet
            .FirstOrDefaultAsync(x => x.IdUsuario == idUsuario);
    }
}
