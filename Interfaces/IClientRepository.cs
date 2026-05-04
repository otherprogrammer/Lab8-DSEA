using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
}