using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class TipoClubeRepositorio : ITipoClubeRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoClubeRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoClubeModel>> GetAll()
        {
            return await _dbContext.TipoClube.ToListAsync();
        }

        public async Task<TipoClubeModel> GetById(int id)
        {
            return await _dbContext.TipoClube.FirstOrDefaultAsync(x => x.TipoClubeId == id);
        }

        public async Task<TipoClubeModel> InsertTipoClube(TipoClubeModel tipoClube)
        {
            await _dbContext.TipoClube.AddAsync(tipoClube);
            await _dbContext.SaveChangesAsync();
            return tipoClube;
        }

        public async Task<TipoClubeModel> UpdateTipoClube(TipoClubeModel tipoClube, int id)
        {
            TipoClubeModel tipoClube1 = await GetById(id);
            if(tipoClube1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoClube1.NomeTipoClube = tipoClube.NomeTipoClube;
                _dbContext.TipoClube.Update(tipoClube1);
                await _dbContext.SaveChangesAsync();
            }
            return tipoClube1;
           
        }

        public async Task<bool> DeleteTipoClube(int id)
        {
            TipoClubeModel tipoClube = await GetById(id);
            if (tipoClube == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoClube.Remove(tipoClube);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
