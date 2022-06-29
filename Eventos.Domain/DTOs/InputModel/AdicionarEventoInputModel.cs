using Eventos.Domain.Enums;
using System;

namespace Eventos.Domain.DTOs.InputModel
{
    public class AdicionarEventoInputModel
    {
        public string Imagem { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string TamanhoLocal { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public int IdUsuarioOrganizador { get; set; }
        public string ValorIngresso { get; set; }

        public int QtdePessoa
        {
            get => (int)Math.Round(Convert.ToDouble(TamanhoLocal) / 1.50);
        }
        public DateTime DataEHora
        {
            get => new DateTime(Data.Year, Data.Month, Data.Day, Hora.Hour, Hora.Minute, Hora.Second);
        }
        public string Localidade
        {
            get => $"{Rua}- {Numero}- {Bairro}- {Cidade}- {Estado}";
        }
    }
}
