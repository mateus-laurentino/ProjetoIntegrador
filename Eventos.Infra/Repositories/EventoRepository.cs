using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Enums;
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

        public async Task<List<EventoOutputModel>> BuscarTodos(CategoriaEnum categoria)
        {
            var query = _dataSet.AsQueryable();

            if (categoria != CategoriaEnum.TodasCategorias)
                query = query.Where(x => x.Categoria == categoria);


            var dados = await query
                    .Select(e => new EventoOutputModel
                    {
                        Id = e.Id,
                        Imagem = e.Imagem,
                        Nome = e.Nome,
                        Categoria = e.Categoria,
                        DataEHora = e.DataEHora,
                        Localidade = e.Localidade,
                        QtdeTotalPessoa = e.QtdeTotalPessoa
                    }).ToListAsync();

            return dados;
        }

        public async Task<bool> AdicionarEvento(AdicionarEventoInputModel model)
        {
            var entidade = new InfoEventoEntity(
                                                model.Imagem,
                                                model.Nome,
                                                model.Localidade,
                                                model.DataEHora,
                                                model.QtdePessoa,
                                                model.Categoria
                                               );

            await _context.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
