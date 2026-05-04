using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Interfaces;

public interface IOrderRepository
{
    Task<int> GetTotalProductsByOrderIdAsync(int orderId);
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<object?> GetTopClientAsync();
    Task<IEnumerable<string>> GetProductsByClientIdAsync(int clientId);
}