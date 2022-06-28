using Eventos.Domain.DTOs.InputModel;
using Eventos.Domain.Entities.Base;

namespace Eventos.Domain.Entities
{
    public class EventoParticipanteEntity : BaseEntity<int>
    {
        public int IdEvento { get; private set; }
        public int IdUsuario { get; private set; }
        public int IdCartao { get; private set; }
        public decimal Valor { get; private set; }
        public int Parcelamento { get; private set; }

        public EventoParticipanteEntity()
        {

        }

        public EventoParticipanteEntity CadastrarUsuarioEvento(ComprarInputModel model, int idCartao, decimal valorIngresso)
        {
            IdEvento = model.IdEvento ?? 0;
            IdUsuario = model.IdUsuario ?? 0;
            IdCartao = idCartao;
            Valor = valorIngresso;
            Parcelamento = model.Parcelamento;

            return this;
        }
    }
}
