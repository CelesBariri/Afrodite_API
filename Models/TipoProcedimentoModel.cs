namespace Api.Models
{
    public class TipoProcedimentoModel
    {
        public int TipoProcedimentoId { get; set; }

        public string NomeTipoProcedimento { get; set; } = string.Empty;


        public static implicit operator List<object>(TipoProcedimentoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
