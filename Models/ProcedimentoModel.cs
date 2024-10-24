namespace Api.Models
{
    public class ProcedimentoModel
    {
        public int ProcedimentoId { get; set; }

        public string NomeProcedimento { get; set; } = string.Empty;

        public int ValorProcedimento { get; set; }


        public static implicit operator List<object>(ProcedimentoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
