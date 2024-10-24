namespace Api.Models
{
    public class PagamentoAgendamentoModel
    {
        public int PagamentoAgendamentoId { get; set; }

        public int AgendamentoId { get; set; }

        public int FormaPagamentoId { get; set; }


        public static implicit operator List<object>(PagamentoAgendamentoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
