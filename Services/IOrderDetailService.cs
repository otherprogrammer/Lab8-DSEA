namespace Lab08_MattiasMarquez.Services;

public interface IOrderDetailService
{
    Task<IEnumerable<object>> GetOrderDetailsAsync(int orderId);
    Task<IEnumerable<object>> GetAllDetailsProjectedAsync();
}