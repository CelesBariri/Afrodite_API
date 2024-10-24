using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class PagamentoAssinaturaRepositorio : IPagamentoAssinaturaRepositorio
    {
        private readonly Contexto _dbContext;

        public PagamentoAssinaturaRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PagamentoAssinaturaModel>> GetAll()
        {
            return await _dbContext.PagamentoAssinatura.ToListAsync();
        }

        public async Task<PagamentoAssinaturaModel> GetById(int id)
        {
            return await _dbContext.PagamentoAssinatura.FirstOrDefaultAsync(x => x.PagamentoAssinaturaId == id);
        }

        public async Task<PagamentoAssinaturaModel> InsertPagamentoAssinatura(PagamentoAssinaturaModel pagamentoAssinatura)
        {
            await _dbContext.PagamentoAssinatura.AddAsync(pagamentoAssinatura);
            await _dbContext.SaveChangesAsync();
            return pagamentoAssinatura;
        }

        public async Task<PagamentoAssinaturaModel> UpdatePagamentoAssinatura(PagamentoAssinaturaModel pagamentoAssinatura, int id)
        {
            PagamentoAssinaturaModel pagamentoAssinatura1 = await GetById(id);
            if(pagamentoAssinatura1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                pagamentoAssinatura1.AssinaturaClubeId = pagamentoAssinatura.AssinaturaClubeId;
                pagamentoAssinatura1.FormaPagamentoId = pagamentoAssinatura.FormaPagamentoId;
                _dbContext.PagamentoAssinatura.Update(pagamentoAssinatura1);
                await _dbContext.SaveChangesAsync();
            }
            return pagamentoAssinatura1;
           
        }

        public async Task<bool> DeletePagamentoAssinatura(int id)
        {
            PagamentoAssinaturaModel pagamentoAssinatura = await GetById(id);
            if (pagamentoAssinatura == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.PagamentoAssinatura.Remove(pagamentoAssinatura);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
