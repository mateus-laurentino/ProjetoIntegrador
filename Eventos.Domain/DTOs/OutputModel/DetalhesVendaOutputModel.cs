namespace Eventos.Domain.DTOs.OutputModel
{
    public class DetalhesVendaOutputModel
    {
        public EventoOutputModel Evento { get; set; }
        public UsuarioOutputModel Usuario { get; set; }

        public DetalhesVendaOutputModel(EventoOutputModel evento, UsuarioOutputModel usuario)
        {
            Evento = evento;
            Usuario = usuario;
        }
    }
}
