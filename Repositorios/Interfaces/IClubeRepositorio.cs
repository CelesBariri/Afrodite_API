using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IClubeRepositorio
    {
        Task<List<ClubeModel>> GetAll();

        Task<ClubeModel> GetById(int id);

        Task<ClubeModel> InsertClube(ClubeModel clube);

        Task<ClubeModel> UpdateClube(ClubeModel clube, int id);

        Task<bool> DeleteClube(int id);
    }
}
