using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class TipoProfissionalRepositorio : ITipoProfissionalRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoProfissionalRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoProfissionalModel>> GetAll()
        {
            return await _dbContext.TipoProfissional.ToListAsync();
        }

        public async Task<TipoProfissionalModel> GetById(int id)
        {
            return await _dbContext.TipoProfissional.FirstOrDefaultAsync(x => x.TipoProfissionalId == id);
        }

        public async Task<TipoProfissionalModel> InsertTipoProfissional(TipoProfissionalModel tipoProfissional)
        {
            await _dbContext.TipoProfissional.AddAsync(tipoProfissional);
            await _dbContext.SaveChangesAsync();
            return tipoProfissional;
        }

        public async Task<TipoProfissionalModel> UpdateTipoProfissional(TipoProfissionalModel tipoProfissional, int id)
        {
            TipoProfissionalModel tipoProfissional1 = await GetById(id);
            if(tipoProfissional1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoProfissional1.NomeTipoProfissional = tipoProfissional.NomeTipoProfissional;
                _dbContext.TipoProfissional.Update(tipoProfissional1);
                await _dbContext.SaveChangesAsync();
            }
            return tipoProfissional1;
           
        }

        public async Task<bool> DeleteTipoProfissional(int id)
        {
            TipoProfissionalModel tipoProfissional = await GetById(id);
            if (tipoProfissional == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoProfissional.Remove(tipoProfissional);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
