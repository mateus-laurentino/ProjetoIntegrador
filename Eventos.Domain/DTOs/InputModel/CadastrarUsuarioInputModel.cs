using System;

namespace Eventos.Domain.DTOs.InputModel
{
    public class CadastrarUsuarioInputModel
    {
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public int? Cvc { get; set; }
        public DateTime? DataVencimento { get; set; }

    }
}
