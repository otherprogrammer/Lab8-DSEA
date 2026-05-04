using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductsHigherThanPriceAsync(decimal price);
}