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

    public async Task<Product?> GetMostExpensiveAsync()
    {
        return await _repository.GetMostExpensiveProductAsync();
    }

    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _repository.GetAveragePriceAsync();
    }

    public async Task<IEnumerable<Product>> GetMissingDescriptionsAsync()
    {
        return await _repository.GetProductsWithoutDescriptionAsync();
    }

    public async Task<IEnumerable<string>> GetBuyersByProductIdAsync(int productId)
    {
        return await _repository.GetClientsByProductIdAsync(productId);
    }
}