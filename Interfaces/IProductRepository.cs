using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsByPriceAsync(decimal minPrice);
}