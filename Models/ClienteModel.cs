using Microsoft.VisualBasic;

namespace Api.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }

        public string NomeCliente { get; set; } = string.Empty;

        public DateTime DataNascimentoCliente { get; set; }

        public string SexoCliente { get; set; } = string.Empty;

        public int CpfCliente { get; set; }

        public int TelCliente { get; set; }

        public string EmailCliente { get; set; } = string.Empty;

        public string SenhaCliente { get; set; } = string.Empty;

        public static implicit operator List<object>(ClienteModel v)
        {
            throw new NotImplementedException();
        }
    }
}
