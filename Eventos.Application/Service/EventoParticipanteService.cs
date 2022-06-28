using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IRepository.Common;
using Eventos.Domain.Interfaces.IService;
using Eventos.Infra.Context;
using System.Threading.Tasks;

namespace Eventos.Application.Service
{
    public class EventoParticipanteService : IEventoParticipanteService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IEventoParticipanteRepository _eventoParticipanteRepository;
        private readonly IUnitOfWork<EventoContext> _uow;

        public EventoParticipanteService(IEventoRepository eventoRepository,
            IUsuarioRepository usuarioRepository,
            ICartaoRepository cartaoRepository,
            IEventoParticipanteRepository eventoParticipanteRepository,
            IUnitOfWork<Infra.Context.EventoContext> uow)
        {
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
            _cartaoRepository = cartaoRepository;
            _eventoParticipanteRepository = eventoParticipanteRepository;
            _uow = uow;
        }

        public async Task<bool> ConfirmarParticipacaoAsync(ComprarInputModel model)
        {
            var usuario = await _usuarioRepository.ProcurarPorIdAsync(model.IdUsuario ?? 0);

            var evento = await _eventoRepository.ProcurarPorIdAsync(model.IdEvento ?? 0);

            var cartao = await _cartaoRepository.ProcurarPorIdUsuarioAsync(model.IdUsuario ?? 0);
            if (cartao.Cvc != model.Cvc)
                return false;

            var finalizar = new EventoParticipanteEntity().CadastrarUsuarioEvento(model, cartao.Id, evento.ValorIngresso);
            await _eventoParticipanteRepository.InserirAsync(finalizar);
            await _uow.CommitAsync();

            return true;
        }
    }
}
