using Lab08_MattiasMarquez.Interfaces;
using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Services.Implements;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Client>> SearchByNameAsync(string name)
    {
        return await _repository.GetClientsByNameAsync(name);
    }
}