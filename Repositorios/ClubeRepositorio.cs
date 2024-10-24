using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ClubeRepositorio : IClubeRepositorio
    {
        private readonly Contexto _dbContext;

        public ClubeRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClubeModel>> GetAll()
        {
            return await _dbContext.Clube.ToListAsync();
        }

        public async Task<ClubeModel> GetById(int id)
        {
            return await _dbContext.Clube.FirstOrDefaultAsync(x => x.ClubeId == id);
        }

        public async Task<ClubeModel> InsertClube(ClubeModel clube)
        {
            await _dbContext.Clube.AddAsync(clube);
            await _dbContext.SaveChangesAsync();
            return clube;
        }

        public async Task<ClubeModel> UpdateClube(ClubeModel clube, int id)
        {
            ClubeModel clube1 = await GetById(id);
            if(clube1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                clube1.NomeClube = clube.NomeClube;
                clube1.FotoClube = clube.FotoClube;
                clube1.TipoClubeId = clube.TipoClubeId;
                clube1.TipoPlanoId = clube.TipoPlanoId;
                clube1.DetalhesClube = clube.DetalhesClube;
                clube1.ValorClube = clube.ValorClube;
                _dbContext.Clube.Update(clube1);
                await _dbContext.SaveChangesAsync();
            }
            return clube1;
           
        }

        public async Task<bool> DeleteClube(int id)
        {
            ClubeModel clube = await GetById(id);
            if (clube == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Clube.Remove(clube);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
