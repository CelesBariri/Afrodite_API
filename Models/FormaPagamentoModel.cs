namespace Api.Models
{
    public class FormaPagamentoModel
    {
        public int FormaPagamentoId { get; set; }

        public string NomeFormaPagamento { get; set; } = string.Empty;


        public static implicit operator List<object>(FormaPagamentoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
