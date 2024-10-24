using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPagamentoAssinaturaRepositorio
    {
        Task<List<PagamentoAssinaturaModel>> GetAll();

        Task<PagamentoAssinaturaModel> GetById(int id);

        Task<PagamentoAssinaturaModel> InsertPagamentoAssinatura(PagamentoAssinaturaModel pagamentoAssinatura);

        Task<PagamentoAssinaturaModel> UpdatePagamentoAssinatura(PagamentoAssinaturaModel pagamentoAssinatura, int id);

        Task<bool> DeletePagamentoAssinatura(int id);
    }
}
