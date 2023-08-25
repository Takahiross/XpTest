using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpTest.Application.DTOs;

namespace XpTest.Application.Services.Interfaces
{
    public interface IClientService
    {
        Task<ResultService<ClientDTO>> CreateAsync(ClientDTO clientDTO);
        Task<ResultService<ICollection<ClientResponseDTO>>> GetAllAsync();
        Task<ResultService<ClientDTO>> GetByIdAsync(int id);
        Task<ResultService> UpdateAsync(ClientDTO clientDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
