using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IProcedimentoRepositorio
    {
        Task<List<ProcedimentoModel>> GetAll();

        Task<ProcedimentoModel> GetById(int id);

        Task<ProcedimentoModel> InsertProcedimento(ProcedimentoModel procedimento);

        Task<ProcedimentoModel> UpdateProcedimento(ProcedimentoModel procedimento, int id);

        Task<bool> DeleteProcedimento(int id);
    }
}
