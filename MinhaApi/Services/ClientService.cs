using MinhaApi.Dtos;
using MinhaApi.Models;
using MinhaApi.Repositories;
using System;
using System.Threading.Tasks;

namespace MinhaApi.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> CreateAsync(CreateClientDto createClientDto)
        {
            await ValidateUniqueFields(createClientDto);

            var newClient = new Client
            {
                FullName = createClientDto.FullName,
                Cpf = createClientDto.Cpf,
                Email = createClientDto.Email,
                PreferredColor = createClientDto.PreferredColor,
                Observations = createClientDto.Observations
            };

            await _clientRepository.AddAsync(newClient);
            return newClient;
        }

        private async Task ValidateUniqueFields(CreateClientDto createClientDto)
        {
            if (await _clientRepository.GetByCpfAsync(createClientDto.Cpf) != null)
            {
                throw new Exception("CPF já cadastrado.");
            }

            if (await _clientRepository.GetByEmailAsync(createClientDto.Email) != null)
            {
                throw new Exception("E-mail já cadastrado.");
            }
        }
    }
}

