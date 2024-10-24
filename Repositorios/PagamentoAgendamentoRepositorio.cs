using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class PagamentoAgendamentoRepositorio : IPagamentoAgendamentoRepositorio
    {
        private readonly Contexto _dbContext;

        public PagamentoAgendamentoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PagamentoAgendamentoModel>> GetAll()
        {
            return await _dbContext.PagamentoAgendamento.ToListAsync();
        }

        public async Task<PagamentoAgendamentoModel> GetById(int id)
        {
            return await _dbContext.PagamentoAgendamento.FirstOrDefaultAsync(x => x.PagamentoAgendamentoId == id);
        }

        public async Task<PagamentoAgendamentoModel> InsertPagamentoAgendamento(PagamentoAgendamentoModel pagamentoAgendamento)
        {
            await _dbContext.PagamentoAgendamento.AddAsync(pagamentoAgendamento);
            await _dbContext.SaveChangesAsync();
            return pagamentoAgendamento;
        }

        public async Task<PagamentoAgendamentoModel> UpdatePagamentoAgendamento(PagamentoAgendamentoModel pagamentoAgendamento, int id)
        {
            PagamentoAgendamentoModel pagamentoAgendamento1 = await GetById(id);
            if(pagamentoAgendamento1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                pagamentoAgendamento1.AgendamentoId = pagamentoAgendamento.AgendamentoId;
                pagamentoAgendamento1.FormaPagamentoId = pagamentoAgendamento.FormaPagamentoId;
                _dbContext.PagamentoAgendamento.Update(pagamentoAgendamento1);
                await _dbContext.SaveChangesAsync();
            }
            return pagamentoAgendamento1;
           
        }

        public async Task<bool> DeletePagamentoAgendamento(int id)
        {
            PagamentoAgendamentoModel pagamentoAgendamento = await GetById(id);
            if (pagamentoAgendamento == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.PagamentoAgendamento.Remove(pagamentoAgendamento);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
