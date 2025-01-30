using MinhaApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using MinhaApi.Data;

namespace MinhaApi.Repositories
{
    public class ClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client?> GetByCpfAsync(string cpf)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

        public async Task<Client?> GetByEmailAsync(string email)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }
    }
}
