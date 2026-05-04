using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> SearchByNameAsync(string name);
}