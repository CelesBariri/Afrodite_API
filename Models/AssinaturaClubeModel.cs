namespace Api.Models
{
    public class AssinaturaClubeModel
    {
        public int AssinaturaClubeId { get; set; }

        public int ClienteId { get; set; }

        public int ClubeId { get; set; }

        public static implicit operator List<object>(AssinaturaClubeModel v)
        {
            throw new NotImplementedException();
        }
    }
}
