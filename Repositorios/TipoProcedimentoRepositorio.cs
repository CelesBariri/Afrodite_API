using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class TipoProcedimentoRepositorio : ITipoProcedimentoRepositorio
    {
        private readonly Contexto _dbContext;

        public TipoProcedimentoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TipoProcedimentoModel>> GetAll()
        {
            return await _dbContext.TipoProcedimento.ToListAsync();
        }

        public async Task<TipoProcedimentoModel> GetById(int id)
        {
            return await _dbContext.TipoProcedimento.FirstOrDefaultAsync(x => x.TipoProcedimentoId == id);
        }

        public async Task<TipoProcedimentoModel> InsertTipoProcedimento(TipoProcedimentoModel tipoProcedimento)
        {
            await _dbContext.TipoProcedimento.AddAsync(tipoProcedimento);
            await _dbContext.SaveChangesAsync();
            return tipoProcedimento;
        }

        public async Task<TipoProcedimentoModel> UpdateTipoProcedimento(TipoProcedimentoModel tipoProcedimento, int id)
        {
            TipoProcedimentoModel tipoProcedimento1 = await GetById(id);
            if(tipoProcedimento1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                tipoProcedimento1.NomeTipoProcedimento = tipoProcedimento.NomeTipoProcedimento;
                _dbContext.TipoProcedimento.Update(tipoProcedimento1);
                await _dbContext.SaveChangesAsync();
            }
            return tipoProcedimento1;
           
        }

        public async Task<bool> DeleteTipoProcedimento(int id)
        {
            TipoProcedimentoModel tipoProcedimento = await GetById(id);
            if (tipoProcedimento == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.TipoProcedimento.Remove(tipoProcedimento);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
