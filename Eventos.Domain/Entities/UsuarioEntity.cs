using Eventos.Domain.Entities.Base;
using System;

namespace Eventos.Domain.Entities
{
    public class UsuarioEntity : BaseEntity<int>
    {
        public string Usuario { get; private set; }
        public string Password { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public UsuarioEntity(string usuario, string password, string nome, int idade, DateTime dataNascimento)
        {
            Usuario = usuario;
            Password = password;
            Nome = nome;
            Idade = idade;
            DataNascimento = dataNascimento;
        }
    }
}
