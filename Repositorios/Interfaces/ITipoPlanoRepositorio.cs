using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoPlanoRepositorio
    {
        Task<List<TipoPlanoModel>> GetAll();

        Task<TipoPlanoModel> GetById(int id);

        Task<TipoPlanoModel> InsertTipoPlano(TipoPlanoModel tipoPlano);

        Task<TipoPlanoModel> UpdateTipoPlano(TipoPlanoModel tipoPlano, int id);

        Task<bool> DeleteTipoPlano(int id);
    }
}
