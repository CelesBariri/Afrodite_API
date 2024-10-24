using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ProcedimentoRepositorio : IProcedimentoRepositorio
    {
        private readonly Contexto _dbContext;

        public ProcedimentoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProcedimentoModel>> GetAll()
        {
            return await _dbContext.Procedimento.ToListAsync();
        }

        public async Task<ProcedimentoModel> GetById(int id)
        {
            return await _dbContext.Procedimento.FirstOrDefaultAsync(x => x.ProcedimentoId == id);
        }

        public async Task<ProcedimentoModel> InsertProcedimento(ProcedimentoModel procedimento)
        {
            await _dbContext.Procedimento.AddAsync(procedimento);
            await _dbContext.SaveChangesAsync();
            return procedimento;
        }

        public async Task<ProcedimentoModel> UpdateProcedimento(ProcedimentoModel procedimento, int id)
        {
            ProcedimentoModel procedimento1 = await GetById(id);
            if(procedimento1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                procedimento1.NomeProcedimento = procedimento.NomeProcedimento;
                procedimento1.ValorProcedimento = procedimento.ValorProcedimento;
                _dbContext.Procedimento.Update(procedimento1);
                await _dbContext.SaveChangesAsync();
            }
            return procedimento1;
           
        }

        public async Task<bool> DeleteProcedimento(int id)
        {
            ProcedimentoModel procedimento = await GetById(id);
            if (procedimento == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Procedimento.Remove(procedimento);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
