using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface ITipoClubeRepositorio
    {
        Task<List<TipoClubeModel>> GetAll();

        Task<TipoClubeModel> GetById(int id);

        Task<TipoClubeModel> InsertTipoClube(TipoClubeModel tipoClube);

        Task<TipoClubeModel> UpdateTipoClube(TipoClubeModel tipoClube, int id);

        Task<bool> DeleteTipoClube(int id);
    }
}
