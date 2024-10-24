using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Contexto _dbContext;

        public ClienteRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClienteModel>> GetAll()
        {
            return await _dbContext.Cliente.ToListAsync();
        }

        public async Task<ClienteModel> GetById(int id)
        {
            return await _dbContext.Cliente.FirstOrDefaultAsync(x => x.ClienteId == id);
        }

        public async Task<ClienteModel> Login(string email , string password )
        {
            return await _dbContext.Cliente.FirstOrDefaultAsync(x => x.EmailCliente == email && x.SenhaCliente == password );
        }

        public async Task<ClienteModel> InsertCliente(ClienteModel cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClienteModel> UpdateCliente(ClienteModel cliente, int id)
        {
            ClienteModel cliente1 = await GetById(id);
            if(cliente1 == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                cliente1.NomeCliente = cliente.NomeCliente;
                cliente1.DataNascimentoCliente = cliente.DataNascimentoCliente;
                cliente1.SexoCliente = cliente.SexoCliente;
                cliente1.CpfCliente = cliente.CpfCliente;
                cliente1.TelCliente = cliente.TelCliente;
                cliente1.EmailCliente = cliente.EmailCliente;
                cliente1.SenhaCliente = cliente.SenhaCliente;
                _dbContext.Cliente.Update(cliente1);
                await _dbContext.SaveChangesAsync();
            }
            return cliente1;
           
        }

        public async Task<bool> DeleteCliente(int id)
        {
            ClienteModel cliente = await GetById(id);
            if (cliente == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Cliente.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
