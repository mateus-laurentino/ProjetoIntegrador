using Eventos.Domain.Entities.Base;
using Eventos.Domain.Enums;
using System;

namespace Eventos.Domain.Entities
{
    public class InfoEventoEntity : BaseEntity<int>
    {
        public string Nome { get; private set; }
        public string Localidade { get; private set; }
        public DateTime DataEHora { get; private set; }
        public int QtdeTotalPessoa { get; private set; }
        public CategoriaEnum Categoria { get; private set; }

        public InfoEventoEntity()
        {

        }
    }
}
