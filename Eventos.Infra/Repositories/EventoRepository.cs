using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Enums;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Infra.Context;
using Eventos.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<List<EventoOutputModel>> BuscarTodos(CategoriaEnum? categoria, int? idUsuario, List<int> idEventoParticipante)
        {
            var query = _dataSet.AsQueryable();

            if (categoria != null)
                query = query.Where(x => x.Categoria == categoria);

            if (idUsuario != null)
                query = query.Where(x => x.IdUsuario != idUsuario);

            if(idEventoParticipante.Count > 0)
                query = query.Where(x=> !idEventoParticipante.Contains(x.Id));

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
            var valorIngresso = Convert.ToDecimal(model.ValorIngresso);

            var entidade = new InfoEventoEntity(
                                                model.Imagem,
                                                model.Nome,
                                                model.Localidade,
                                                model.DataEHora,
                                                model.QtdePessoa,
                                                model.Categoria,
                                                model.IdUsuarioOrganizador,
                                                valorIngresso
                                               );

            await _context.AddAsync(entidade);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<EventoOutputModel>> BuscarEventosParticipanteAsync(List<int> idEventos)
            => await _dataSet
            .Where(x=>idEventos.Contains(x.Id))
            .Select(x=> new EventoOutputModel
            {
                Categoria = x.Categoria,
                DataEHora = x.DataEHora,
                Id = x.Id,
                Imagem = x.Imagem,
                Localidade = x.Localidade,
                Nome = x.Nome,
                QtdeTotalPessoa = x.QtdeTotalPessoa,
                ValorIngresso = x.ValorIngresso,
            })
            .ToListAsync();

        public async Task<List<EventoOutputModel>> BuscarEventosOrganizadorAsync(int idUsuario)
            => await _dataSet
            .Where(x => x.IdUsuario == idUsuario)
            .Select(x=>new EventoOutputModel
            {
                Categoria = x.Categoria,
                DataEHora = x.DataEHora,
                Id = x.Id,
                Imagem = x.Imagem,
                Localidade = x.Localidade,
                Nome = x.Nome,
                QtdeTotalPessoa = x.QtdeTotalPessoa,
                ValorIngresso = x.ValorIngresso
            })
            .ToListAsync();

        public async Task<InfoEventoEntity> CancelarEventoAsync(int idEvento, int idUsuario)
            =>await _dataSet
                .Where(x => x.Id == idEvento
                        && x.IdUsuario == idUsuario)
                .FirstOrDefaultAsync();
    }
}
