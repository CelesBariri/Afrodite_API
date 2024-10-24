using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoProcedimentoRepositorio
    {
        Task<List<TipoProcedimentoModel>> GetAll();

        Task<TipoProcedimentoModel> GetById(int id);

        Task<TipoProcedimentoModel> InsertTipoProcedimento(TipoProcedimentoModel tipoProcedimento);

        Task<TipoProcedimentoModel> UpdateTipoProcedimento(TipoProcedimentoModel tipoProcedimento, int id);

        Task<bool> DeleteTipoProcedimento(int id);
    }
}
