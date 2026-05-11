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

    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _context.Products
            .AverageAsync(p => p.Price);
    }

    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> GetClientsByProductIdAsync(int productId)
    {
        return await _context.Orderdetails
            .Where(od => od.Productid == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();
    }
}