using Eventos.Domain.Enums;
using System;

namespace Eventos.Domain.DTOs.OutputModel
{
    public class EventoOutputModel
    {
        public int Id { get; set; }
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Localidade { get; set; }
        public DateTime DataEHora { get; set; }
        public int QtdeTotalPessoa { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public string CaminhoImagem
        {
            get => Categoria.ToString() + ".png";
        }
    }
}
