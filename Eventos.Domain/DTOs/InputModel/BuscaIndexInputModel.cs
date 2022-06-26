using Eventos.Domain.Enums;

namespace Eventos.Domain.DTOs.InputModel
{
    public class BuscaIndexInputModel
    {
        public string Nome { get; set; }
        public CategoriaEnum Categoria { get; set; }
    }
}
