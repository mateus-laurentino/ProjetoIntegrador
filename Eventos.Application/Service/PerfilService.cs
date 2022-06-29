using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IService;
using System.Threading.Tasks;

namespace Eventos.Application.Service
{
    public class PerfilService : IPerfilService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEventoParticipanteRepository _eventoParticipanteRepository;
        private readonly IEventoRepository _eventoRepository;

        public PerfilService(IUsuarioRepository usuarioRepository,
            IEventoParticipanteRepository eventoParticipanteRepository,
            IEventoRepository eventoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _eventoParticipanteRepository = eventoParticipanteRepository;
            _eventoRepository = eventoRepository;
        }

        public async Task<EventosUsuarioOutputModel> BuscarInformacoesUsuarioAsync(string nomeUsuario)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioAsync(nomeUsuario);

            var eventosUsuario = await _eventoParticipanteRepository.BuscarEventosIdUsuario(usuario.Id ?? 0);

            var eventoParticipante = await _eventoRepository.BuscarEventosParticipanteAsync(eventosUsuario);

            var eventoOrganizador = await _eventoRepository.BuscarEventosOrganizadorAsync(usuario.Id ?? 0);

            return new EventosUsuarioOutputModel
            {
                Usuario = usuario,
                EventosParticipante = eventoParticipante,
                EventosOrganizador = eventoOrganizador
            };
        }
    }
}
