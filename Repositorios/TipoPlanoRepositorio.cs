using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class TipoPlanoRepositorio : ITipoPlanoRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoPlanoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoPlanoModel>> GetAll()
        {
            return await _dbContext.TipoPlano.ToListAsync();
        }

        public async Task<TipoPlanoModel> GetById(int id)
        {
            return await _dbContext.TipoPlano.FirstOrDefaultAsync(x => x.TipoPlanoId == id);
        }

        public async Task<TipoPlanoModel> InsertTipoPlano(TipoPlanoModel tipoPlano)
        {
            await _dbContext.TipoPlano.AddAsync(tipoPlano);
            await _dbContext.SaveChangesAsync();
            return tipoPlano;
        }

        public async Task<TipoPlanoModel> UpdateTipoPlano(TipoPlanoModel tipoPlano, int id)
        {
            TipoPlanoModel tipoPlano1 = await GetById(id);
            if(tipoPlano1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoPlano1.NomeTipoPlano = tipoPlano.NomeTipoPlano;
                _dbContext.TipoPlano.Update(tipoPlano1);
                await _dbContext.SaveChangesAsync();
            }
            return tipoPlano1;
           
        }

        public async Task<bool> DeleteTipoPlano(int id)
        {
            TipoPlanoModel tipoPlano = await GetById(id);
            if (tipoPlano == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoPlano.Remove(tipoPlano);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
