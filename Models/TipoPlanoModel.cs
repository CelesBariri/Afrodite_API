namespace Api.Models
{
    public class TipoPlanoModel
    {
        public int TipoPlanoId { get; set; }

        public string NomeTipoPlano { get; set; } = string.Empty;

        public static implicit operator List<object>(TipoPlanoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
