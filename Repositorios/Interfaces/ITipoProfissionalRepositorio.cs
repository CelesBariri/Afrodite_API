using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoProfissionalRepositorio
    {
        Task<List<TipoProfissionalModel>> GetAll();

        Task<TipoProfissionalModel> GetById(int id);

        Task<TipoProfissionalModel> InsertTipoProfissional(TipoProfissionalModel tipoProfissional);

        Task<TipoProfissionalModel> UpdateTipoProfissional(TipoProfissionalModel tipoProfissional, int id);

        Task<bool> DeleteTipoProfissional(int id);
    }
}
