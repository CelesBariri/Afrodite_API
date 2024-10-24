using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPagamentoAgendamentoRepositorio
    {
        Task<List<PagamentoAgendamentoModel>> GetAll();

        Task<PagamentoAgendamentoModel> GetById(int id);

        Task<PagamentoAgendamentoModel> InsertPagamentoAgendamento(PagamentoAgendamentoModel pagamentoAgendamento);

        Task<PagamentoAgendamentoModel> UpdatePagamentoAgendamento(PagamentoAgendamentoModel pagamentoAgendamento, int id);

        Task<bool> DeletePagamentoAgendamento(int id);
    }
}
