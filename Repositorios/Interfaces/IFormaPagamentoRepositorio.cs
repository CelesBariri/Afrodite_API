using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IFormaPagamentoRepositorio
    {
        Task<List<FormaPagamentoModel>> GetAll();

        Task<FormaPagamentoModel> GetById(int id);

        Task<FormaPagamentoModel> InsertFormaPagamento(FormaPagamentoModel formaPagamento);

        Task<FormaPagamentoModel> UpdateFormaPagamento(FormaPagamentoModel formaPagamento, int id);

        Task<bool> DeleteFormaPagamento(int id);
    }
}
