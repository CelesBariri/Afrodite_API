using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class FormaPagamentoRepositorio : IFormaPagamentoRepositorio
    {
        private readonly Contexto _dbContext;

        public FormaPagamentoRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FormaPagamentoModel>> GetAll()
        {
            return await _dbContext.FormaPagamento.ToListAsync();
        }

        public async Task<FormaPagamentoModel> GetById(int id)
        {
            return await _dbContext.FormaPagamento.FirstOrDefaultAsync(x => x.FormaPagamentoId == id);
        }

        public async Task<FormaPagamentoModel> InsertFormaPagamento(FormaPagamentoModel formaPagamento)
        {
            await _dbContext.FormaPagamento.AddAsync(formaPagamento);
            await _dbContext.SaveChangesAsync();
            return formaPagamento;
        }

        public async Task<FormaPagamentoModel> UpdateFormaPagamento(FormaPagamentoModel formaPagamento, int id)
        {
            FormaPagamentoModel formaPagamento1 = await GetById(id);
            if(formaPagamento1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                formaPagamento1.NomeFormaPagamento = formaPagamento.NomeFormaPagamento;
                _dbContext.FormaPagamento.Update(formaPagamento1);
                await _dbContext.SaveChangesAsync();
            }
            return formaPagamento1;
           
        }

        public async Task<bool> DeleteFormaPagamento(int id)
        {
            FormaPagamentoModel formaPagamento = await GetById(id);
            if (formaPagamento == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.FormaPagamento.Remove(formaPagamento);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
