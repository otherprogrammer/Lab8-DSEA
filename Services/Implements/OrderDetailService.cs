using Lab08_MattiasMarquez.Interfaces;

namespace Lab08_MattiasMarquez.Services.Implements;

public class OrderDetailService : IOrderDetailService
{
    private readonly IOrderDetailRepository _repository;

    public OrderDetailService(IOrderDetailRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<object>> GetOrderDetailsAsync(int orderId)
    {
        return await _repository.GetProductDetailsByOrderIdAsync(orderId);
    }

    public async Task<IEnumerable<object>> GetAllDetailsProjectedAsync()
    {
        return await _repository.GetAllDetailsProjectedAsync();
    }
}