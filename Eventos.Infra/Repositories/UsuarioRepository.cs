using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Infra.Context;
using Eventos.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity, int>, IUsuarioRepository
    {
        public UsuarioRepository(EventoContext context) : base(context)
        {
        }

        public async Task<UsuarioOutputModel> LoginValidoAsync(LoginInputModel model)
                => await _dataSet
                .Where(x => x.Usuario.Equals(model.Usuario) && x.Password.Equals(model.Password))
                .Select(x => new UsuarioOutputModel
                {
                    Id = x.Id,
                    DataNascimento = x.DataNascimento,
                    Idade = x.Idade,
                    Nome = x.Nome,
                    Usuario = x.Usuario
                })
                .FirstOrDefaultAsync();

        public async Task<UsuarioOutputModel> BuscarUsuarioAsync(string nomeUsuario)
            => await _dataSet
            .Where(x => x.Usuario == nomeUsuario)
            .Select(x => new UsuarioOutputModel
            {
                Nome = x.Nome,
                Usuario = x.Usuario,
                DataNascimento = x.DataNascimento,
                Id = x.Id,
                Idade = x.Idade
            }).FirstOrDefaultAsync();
    }
}
