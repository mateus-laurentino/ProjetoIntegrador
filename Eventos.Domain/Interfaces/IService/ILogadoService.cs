using Eventos.Domain.DTOs.OutputModel;
using System.Threading.Tasks;

namespace Eventos.Domain.Interfaces.IService
{
    public interface ILogadoService
    {
        Task<string> VerificarSeLogadoAsync();
        Task<string> DeslogarAsync();
        Task<bool> Logar(string usuario);
    }
}
