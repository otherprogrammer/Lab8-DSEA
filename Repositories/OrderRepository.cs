using Lab08_MattiasMarquez.Interfaces;
using Lab08_MattiasMarquez.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab08_MattiasMarquez.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly Lab08DbContext _context;

    public OrderRepository(Lab08DbContext context)
    {
        _context = context;
    }

    public async Task<int> GetTotalProductsByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }

    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.Orderdate > date)
            .ToListAsync();
    }

    public async Task<object?> GetTopClientAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.Clientid)
            .OrderByDescending(g => g.Count())
            .Select(g => new { ClientId = g.Key, TotalOrders = g.Count() })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<string>> GetProductsByClientIdAsync(int clientId)
    {
        return await _context.Orderdetails
            .Where(od => od.Order.Clientid == clientId)
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync();
    }
}