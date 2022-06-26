using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Infra.Context;
using Eventos.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Infra.Repositories
{
    public class LogadoRepositoty : BaseRepository<LogadoEntity, int>, ILogadoRepositoty
    {
        public LogadoRepositoty(EventoContext context) : base(context)
        {
        }

        public async Task<LogadoEntity> VerificarSeLogadoAsync()
            =>await _dataSet.FirstOrDefaultAsync();
    }
}
