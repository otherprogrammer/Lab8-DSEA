using Lab08_MattiasMarquez.Interfaces;
using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Services.Implements;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> GetTotalQuantityAsync(int orderId)
    {
        return await _repository.GetTotalProductsByOrderIdAsync(orderId);
    }

    public async Task<IEnumerable<Order>> GetOrdersRecentAsync(DateTime date)
    {
        return await _repository.GetOrdersAfterDateAsync(date);
    }

    public async Task<object?> GetTopClientAsync()
    {
        return await _repository.GetTopClientAsync();
    }

    public async Task<IEnumerable<string>> GetProductNamesByClientAsync(int clientId)
    {
        return await _repository.GetProductsByClientIdAsync(clientId);
    }
}