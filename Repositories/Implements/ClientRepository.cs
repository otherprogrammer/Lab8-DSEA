using Lab08_MattiasMarquez.Interfaces;
using Lab08_MattiasMarquez.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab08_MattiasMarquez.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly Lab08DbContext _context;

    public ClientRepository(Lab08DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
    }
}