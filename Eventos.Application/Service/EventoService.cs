using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Enums;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Application.Service
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEventoParticipanteRepository _eventoParticipanteRepository;

        public EventoService(IEventoRepository eventoRepository,
            IUsuarioRepository usuarioRepository,
            ICartaoRepository cartaoRepository,
            IEventoParticipanteRepository eventoParticipanteRepository)
        {
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
            _eventoParticipanteRepository = eventoParticipanteRepository;
        }

        public async Task<List<EventoOutputModel>> BuscarTodos(CategoriaEnum? categoria, int? idUsuario)
        {
            var listaEventosParticipante = await _eventoParticipanteRepository.BuscarEventosIdUsuario(idUsuario);


            return await _eventoRepository.BuscarTodos(categoria, idUsuario, listaEventosParticipante);
        }

        public async Task<bool> AdicionarEvento(AdicionarEventoInputModel model)
            => await _eventoRepository.AdicionarEvento(model);

        public async Task<UsuarioOutputModel> LoginValidoAsync(LoginInputModel model)
            => await _usuarioRepository.LoginValidoAsync(model);

        public async Task<EventoOutputModel> BuscarPorId(int id)
        {
            var dados = await _eventoRepository.ProcurarPorIdAsync(id);

            return new EventoOutputModel
            {
                Categoria = dados.Categoria,
                DataEHora = dados.DataEHora,
                Id = dados.Id,
                Imagem = dados.Imagem,
                Localidade = dados.Localidade,
                Nome = dados.Nome,
                QtdeTotalPessoa = dados.QtdeTotalPessoa,
                ValorIngresso = dados.ValorIngresso
            };
        }
    }
}
