using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
    Task<IEnumerable<string>> GetClientsByProductIdAsync(int productId);
}