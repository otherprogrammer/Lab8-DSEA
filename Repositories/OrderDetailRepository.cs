using Lab08_MattiasMarquez.Interfaces;
using Lab08_MattiasMarquez.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab08_MattiasMarquez.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly Lab08DbContext _context;

    public OrderDetailRepository(Lab08DbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<object>> GetProductDetailsByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Select(od => new { ProductName = od.Product.Name, Quantity = od.Quantity })
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetAllDetailsProjectedAsync()
    {
        return await _context.Orderdetails
            .Select(od => new { ProductName = od.Product.Name, Quantity = od.Quantity })
            .ToListAsync();
    }
}