using System.ComponentModel;

namespace Eventos.Domain.Enums
{
    public enum CategoriaEnum : short
    {
        [Description("Todas Categorias")]
        TodasCategorias = 0,

        [Description("Aniversario")]
        Aniversario = 1,

        [Description("Festival De Compras")]
        Compras = 2,

        [Description("Festa Fantasia")]
        Fantasia = 3,

        [Description("Karaoke")]
        Karaoke = 4,

        [Description("Musica")]
        Musica = 5,

        [Description("Teatro")]
        Teatro = 6
    }
}
