namespace Api.Models
{
    public class TipoClubeModel
    {
        public int TipoClubeId { get; set; }

        public string NomeTipoClube { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoClubeModel v)
        {
            throw new NotImplementedException();
        }
    }
}
