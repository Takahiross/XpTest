using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpTest.Domain.Entities;
using XpTest.Domain.Repositories;
using XpTest.Infra.Data.Context;

namespace XpTest.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClientAsync(Client client)
        {
            _context.Remove(client); 
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Client>> GetClientAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdASync(int id)
        {
            return await _context.Clients.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
