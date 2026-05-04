using Lab08_MattiasMarquez.Interfaces;
using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Services.Implements;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetProductsHigherThanPriceAsync(decimal price)
    {
        return await _repository.GetProductsByPriceAsync(price);
    }
}