using Eventos.Domain.Entities.Base;
using System;

namespace Eventos.Domain.Entities
{
    public class CartaoUsuarioEntity : BaseEntity<int>
    {
        public int IdUsuario { get; private set; }
        public string NumeroCartao { get; private set; }
        public string NomeCartao { get; private set; }
        public int Cvc { get; private set; }
        public DateTime DataVencimento { get; private set; }

        public CartaoUsuarioEntity()
        {

        }

        public CartaoUsuarioEntity CadastrarCartao(int idUsuario, string numeroCartao, string nomeCartao, int cvc, DateTime dataVencimento)
        {
            IdUsuario = idUsuario;
            NumeroCartao = numeroCartao;
            NomeCartao = nomeCartao;
            Cvc = cvc;
            DataVencimento = dataVencimento;

            return this;
        }
    }
}
