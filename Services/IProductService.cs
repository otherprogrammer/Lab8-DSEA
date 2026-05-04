using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsHigherThanPriceAsync(decimal price);
    Task<Product?> GetMostExpensiveAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<IEnumerable<Product>> GetMissingDescriptionsAsync();
    Task<IEnumerable<string>> GetBuyersByProductIdAsync(int productId);
}