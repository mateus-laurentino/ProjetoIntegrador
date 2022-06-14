using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Infra.Context;
using Eventos.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Infra.Repositories
{
    public class EventoRepository : BaseRepository<InfoEventoEntity, int>, IEventoRepository
    {
        public EventoRepository(EventoContext context) : base(context)
        {
        }

        public async Task<List<EventoOutputModel>> BuscarTodos()
            =>await _dataSet
            .Select(e => new EventoOutputModel
            {
                Id = e.Id,
                Nome = e.Nome,
                Categoria = e.Categoria,
                DataEHora = e.DataEHora,
                Localidade = e.Localidade,
                QtdeTotalPessoa = e.QtdeTotalPessoa
            }).ToListAsync();
    }
}
