using Eventos.Domain.Entities.Base;
using Eventos.Domain.Enums;
using System;

namespace Eventos.Domain.Entities
{
    public class InfoEventoEntity : BaseEntity<int>
    {
        public string Imagem { get; private set; }
        public string Nome { get; private set; }
        public string Localidade { get; private set; }
        public DateTime DataEHora { get; private set; }
        public int QtdeTotalPessoa { get; private set; }
        public CategoriaEnum Categoria { get; private set; }
        public int IdUsuario { get; private set; }

        public InfoEventoEntity()
        {

        }

        public InfoEventoEntity(string imagem, string nome, string localidade, DateTime dataEHora, int qtdeTotalPessoa, CategoriaEnum categoria, int idUsuario)
        {
            Imagem = imagem;
            Nome = nome;
            Localidade = localidade;
            DataEHora = dataEHora;
            QtdeTotalPessoa = qtdeTotalPessoa;
            Categoria = categoria;
            IdUsuario = idUsuario;
        }
    }
}
