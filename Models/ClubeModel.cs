namespace Api.Models
{
    public class ClubeModel
    {
        public int ClubeId { get; set; }

        public string NomeClube { get; set; } = string.Empty;

        public string FotoClube { get; set; } = string.Empty;

        public int TipoClubeId { get; set; }

        public int TipoPlanoId { get; set; }

        public string DetalhesClube { get; set; } = string.Empty;

        public int ValorClube { get; set; }

        public static implicit operator List<object>(ClubeModel v)
        {
            throw new NotImplementedException();
        }
    }
}
