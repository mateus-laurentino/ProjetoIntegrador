using System;

namespace Eventos.Domain.DTOs.OutputModel
{
    public class UsuarioOutputModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Usuario { get; set; }
    }
}
