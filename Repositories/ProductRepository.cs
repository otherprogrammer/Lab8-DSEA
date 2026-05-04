using Lab08_MattiasMarquez.Interfaces;
using Lab08_MattiasMarquez.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab08_MattiasMarquez.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly Lab08DbContext _context;

    public ProductRepository(Lab08DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice)
    {
        return await _context.Products
            .Where(p => p.Price > minPrice)
            .ToListAsync();
    }
}