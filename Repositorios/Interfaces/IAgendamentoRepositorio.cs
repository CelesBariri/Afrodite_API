using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IAgendamentoRepositorio
    {
        Task<List<AgendamentoModel>> GetAll();

        Task<AgendamentoModel> GetById(int id);

        Task<AgendamentoModel> InsertAgendamento(AgendamentoModel agendamento);

        Task<AgendamentoModel> UpdateAgendamento(AgendamentoModel agendamento, int id);

        Task<bool> DeleteAgendamento(int id);
    }
}
