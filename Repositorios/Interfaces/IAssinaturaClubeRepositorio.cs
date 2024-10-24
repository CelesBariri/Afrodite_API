using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IAssinaturaClubeRepositorio
    {
        Task<List<AssinaturaClubeModel>> GetAll();

        Task<AssinaturaClubeModel> GetById(int id);

        Task<AssinaturaClubeModel> InsertAssinaturaClube(AssinaturaClubeModel assinaturaClube);

        Task<AssinaturaClubeModel> UpdateAssinaturaClube(AssinaturaClubeModel assinaturaClube, int id);

        Task<bool> DeleteAssinaturaClube(int id);
    }
}
