using Lab08_MattiasMarquez.Models;

namespace Lab08_MattiasMarquez.Services;

public interface IOrderService
{
    Task<int> GetTotalQuantityAsync(int orderId);
    Task<IEnumerable<Order>> GetOrdersRecentAsync(DateTime date);
    Task<object?> GetTopClientAsync();
    Task<IEnumerable<string>> GetProductNamesByClientAsync(int clientId);
}