using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class AssinaturaClubeRepositorio : IAssinaturaClubeRepositorio
    {
        private readonly Contexto _dbContext;

        public AssinaturaClubeRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AssinaturaClubeModel>> GetAll()
        {
            return await _dbContext.AssinaturaClube.ToListAsync();
        }

        public async Task<AssinaturaClubeModel> GetById(int id)
        {
            return await _dbContext.AssinaturaClube.FirstOrDefaultAsync(x => x.AssinaturaClubeId == id);
        }

        public async Task<AssinaturaClubeModel> InsertAssinaturaClube(AssinaturaClubeModel assinaturaClube)
        {
            await _dbContext.AssinaturaClube.AddAsync(assinaturaClube);
            await _dbContext.SaveChangesAsync();
            return assinaturaClube;
        }

        public async Task<AssinaturaClubeModel> UpdateAssinaturaClube(AssinaturaClubeModel requisicao, int id)
        {
            AssinaturaClubeModel assinaturaClube = await GetById(id);
            if(assinaturaClube == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                assinaturaClube.ClienteId = requisicao.ClienteId;
                assinaturaClube.ClubeId = requisicao.ClubeId;
                _dbContext.AssinaturaClube.Update(assinaturaClube);
                await _dbContext.SaveChangesAsync();
            }
            return assinaturaClube;
           
        }

        public async Task<bool> DeleteAssinaturaClube(int id)
        {
            AssinaturaClubeModel assinaturaClube = await GetById(id);
            if (assinaturaClube == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.AssinaturaClube.Remove(assinaturaClube);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
