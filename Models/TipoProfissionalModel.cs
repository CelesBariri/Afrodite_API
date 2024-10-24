namespace Api.Models
{
    public class TipoProfissionalModel
    {
        public int TipoProfissionalId { get; set; }

        public string NomeTipoProfissional { get; set; } = string.Empty;


        public static implicit operator List<object>(TipoProfissionalModel v)
        {
            throw new NotImplementedException();
        }
    }
}
