using System.Collections.Generic;

namespace Eventos.Domain.DTOs.OutputModel
{
    public class EventosUsuarioOutputModel
    {
        public UsuarioOutputModel Usuario { get; set; }
        public List<EventoOutputModel> EventosParticipante { get; set; }
        public List<EventoOutputModel> EventosOrganizador { get; set; }
    }
}
