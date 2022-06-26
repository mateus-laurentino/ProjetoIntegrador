using Eventos.Domain.Entities.Base;

namespace Eventos.Domain.Entities
{
    public class LogadoEntity : BaseEntity<int>
    {
        public bool UsuarioLogado { get; private set; }
        public string Usuario { get; private set; }

        public LogadoEntity()
        {

        }

        public LogadoEntity Deslogar()
        {
            UsuarioLogado = false;
            Usuario = "Visitante";

            return this;
        }

        public LogadoEntity Logar(string usuario)
        {
            UsuarioLogado = false;
            Usuario = usuario;

            return this;
        }
    }
}
