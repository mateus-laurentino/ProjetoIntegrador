using System.ComponentModel;

namespace Eventos.Domain.Enums
{
    public enum CategoriaEnum : short
    {
        [Description("Aniversario")]
        Aniversario = 0,

        [Description("Festival De Compras")]
        FestivalDeCompras = 1,

        [Description("Festa Fantasia")]
        FestaFantasia = 2,

        [Description("Karaoke")]
        Karaoke = 3,

        [Description("Musica")]
        Musica = 4,

        [Description("Teatro")]
        Teatro = 5
    }
}
