namespace Api.Models
{
    public class AgendamentoModel
    {
        public int AgendamentoId { get; set; }

        public int ProcedimentoId { get; set; }

        public DateTime DataHoraAgendamento { get; set; } 

        public int ProfissionalId { get; set; } 
        
        public string ObservacaoAgendamento { get; set; } = string.Empty;

        public int ClienteId { get; set; }

        public static implicit operator List<object>(AgendamentoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
