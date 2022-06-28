using System;

namespace Eventos.Domain.DTOs.OutputModel
{
    public class CartaoUsuarioOutputModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public int Cvc { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
