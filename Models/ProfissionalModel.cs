namespace Api.Models
{
    public class ProfissionalModel
    {
        public int ProfissionalId { get; set; }

        public string NomeProfissional { get; set; } = string.Empty;

        public string FotoProfissional { get; set; } = string.Empty;

        public int TipoProfissionalId { get; set; }


        public static implicit operator List<object>(ProfissionalModel v)
        {
            throw new NotImplementedException();
        }
    }
}
