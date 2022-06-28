using Eventos.Domain.DTOs.OutputModel;
using Eventos.Domain.Interfaces.IRepository;
using Eventos.Domain.Interfaces.IService;
using System.Threading.Tasks;

namespace Eventos.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
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
    }
}
