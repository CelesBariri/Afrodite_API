namespace Api.Models
{
    public class PagamentoAssinaturaModel
    {
        public int PagamentoAssinaturaId { get; set; }

        public int AssinaturaClubeId { get; set; }

        public int FormaPagamentoId { get; set; }


        public static implicit operator List<object>(PagamentoAssinaturaModel v)
        {
            throw new NotImplementedException();
        }
    }
}
