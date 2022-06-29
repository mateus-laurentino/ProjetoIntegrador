using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IRepository.Common;
using Eventos.Domain.Interfaces.IService;
using Eventos.Infra.Context;
using System;
using System.Threading.Tasks;

namespace Eventos.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IUnitOfWork<EventoContext> _uow;

        public UsuarioService(IUsuarioRepository usuarioRepository,
            ICartaoRepository cartaoRepository,
            IUnitOfWork<EventoContext> uow)
        {
            _usuarioRepository = usuarioRepository;
            _cartaoRepository = cartaoRepository;
            _uow = uow;
        }

        public async Task<UsuarioOutputModel> BuscarUsuarioAsync(string nomeUsuario)
            => await _usuarioRepository.BuscarUsuarioAsync(nomeUsuario);

        public async Task<UsuarioOutputModel> BuscarUsuarioPorIdAsync(int id)
        {
            var result = await _usuarioRepository.ProcurarPorIdAsync(id);

            return new UsuarioOutputModel
            {
                Id = result.Id,
                Idade = result.Idade,
                Nome = result.Nome,
                DataNascimento = result.DataNascimento,
                Usuario = result.Usuario
            };
        }

        public async Task<bool> CadastrarUsuario(CadastrarUsuarioInputModel model)
        {
            var ehUsuario = await _usuarioRepository.BuscarUsuarioAsync(model.Usuario);
            if (ehUsuario != null)
                return false;

            var novoUsuario = new UsuarioEntity().CriarUsuario(
                model.Usuario, model.Password, model.Nome, model.Idade ?? 0, model.DataNascimento ?? DateTime.Now);

            await _usuarioRepository.InserirAsync(novoUsuario);
            await _uow.CommitAsync();

            var usuario = await _usuarioRepository.BuscarUsuarioAsync(model.Usuario);

            var cartao = new CartaoUsuarioEntity().CadastrarCartao(
                usuario.Id ?? 0, model.NumeroCartao, model.NomeCartao, model.Cvc ?? 0, model.DataVencimento ?? DateTime.Now);

            
            await _cartaoRepository.InserirAsync(cartao);

            await _uow.CommitAsync();

            return true;
        }
    }
}
