using AutoMapper;
using System;
using System.IO.Pipes;
using XpTest.Application.DTOs;
using XpTest.Application.DTOs.Validations;
using XpTest.Application.Services.Interfaces;
using XpTest.Domain.Entities;
using XpTest.Domain.Repositories;

namespace XpTest.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ClientDTO>> CreateAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null)
                return ResultService.Fail<ClientDTO>("Object must be informed!");

            var result = new ClientDtoValidator().Validate(clientDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ClientDTO>("Validation issues\r\n", result);

            var client = _mapper.Map<Client>(clientDTO);
            var data = await _clientRepository.CreateAsync(client);
            return ResultService.Ok<ClientDTO>(_mapper.Map<ClientDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var client = await _clientRepository.GetClientByIdASync(id);
            if (client == null)
                return ResultService.Fail<ClientDTO>("Client not found!");
            await _clientRepository.DeleteClientAsync(client);
            return ResultService.Ok($"Client id: {id} has been deleted");
        }

        public async Task<ResultService<ICollection<ClientResponseDTO>>> GetAllAsync()
        {
            var client = await _clientRepository.GetClientAsync();
            return ResultService.Ok<ICollection<ClientResponseDTO>>(_mapper.Map<ICollection<ClientResponseDTO>>(client));
        }

        public async Task<ResultService<ClientDTO>> GetByIdAsync(int id)
        {
            var client = await _clientRepository.GetClientByIdASync(id);
            if (client == null)
                return ResultService.Fail<ClientDTO>("Client not found!");
            return ResultService.Ok(_mapper.Map<ClientDTO>(client));
        }

        public async Task<ResultService> UpdateAsync(ClientDTO clientDTO)
        {
            if (clientDTO == null)
                return ResultService.Fail("Object must be informed!");

            var validation = new ClientDtoValidator().Validate(clientDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Validation issues", validation);

            var client = await _clientRepository.GetClientByIdASync(clientDTO.Id);
            if (client == null)
                return ResultService.Fail("Client not found!");

            client = _mapper.Map<ClientDTO, Client>(clientDTO, client);
            await _clientRepository.UpdateClientAsync(client);
            return ResultService.Ok("Client updated!");
        }
    }
}
