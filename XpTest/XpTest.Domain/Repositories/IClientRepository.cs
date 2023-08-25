using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpTest.Domain.Entities;

namespace XpTest.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetClientByIdASync(int id);
        Task<ICollection<Client>> GetClientAsync();
        Task<Client> CreateAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Client client);
    }
}
