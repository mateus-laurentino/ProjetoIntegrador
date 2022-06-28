using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Entities;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IRepository.Common;
using Eventos.Domain.Interfaces.IService;
using Eventos.Infra.Context;
using System.Threading.Tasks;

namespace Eventos.Application.Service
{
    public class LogadoService : ILogadoService
    {
        private readonly ILogadoRepositoty _logadoRepositoty;
        private readonly IUnitOfWork<EventoContext> _uow;
        public LogadoService(ILogadoRepositoty logadoRepositoty,
            IUsuarioRepository usuarioRepository,
            IUnitOfWork<EventoContext> uow)
        {
            _logadoRepositoty = logadoRepositoty;
            _uow = uow;
        }

        public async Task<string> VerificarSeLogadoAsync()
        {
            var result = await _logadoRepositoty.VerificarSeLogadoAsync();

            if (result == null)
                return "Visitante";

            return result.Usuario;
        }

        public async Task<string> DeslogarAsync()
        {
            var logado = await _logadoRepositoty.VerificarSeLogadoAsync();

            await _logadoRepositoty.DeletarAsync(logado.Id);

            var login = new LogadoEntity().Deslogar();
            await _logadoRepositoty.InserirAsync(login);

            await _uow.CommitAsync();

            return login.Usuario;
        }

        public async Task<bool> Logar(string usuario)
        {
            var logs = await _logadoRepositoty.VerificarSeLogadoAsync();

            if (logs == null)
                return false;

            await _logadoRepositoty.DeletarAsync(logs.Id);

            var user = new LogadoEntity().Logar(usuario);
            await _logadoRepositoty.InserirAsync(user);

            await _uow.CommitAsync();

            return true;
        }
    }
}
