namespace Eventos.Domain.DTOs.InputModel
{
    public class ComprarInputModel
    {
        public int? IdUsuario { get; set; }
        public int? IdEvento { get; set; }
        public int? Cvc { get; set; }
        public int Parcelamento { get; set; }
    }
}
/*
        < div class= "div-informacoes-pagamento" >
            < label > Numero do cartão:</ label >
            < label > @Model.CartaoUsuario.NumeroCartao </ label >
            < label > Nome do cartão:</ label >
            < label > @Model.CartaoUsuario.NomeCartao </ label >
            < label > Data Vencimento:</ label >
            < label > @string.Format("{0}/{1}", @Model.CartaoUsuario.DataVencimento.Month, @Model.CartaoUsuario.DataVencimento.Year) </ label >
        </ div >
*/