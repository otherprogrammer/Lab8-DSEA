namespace Lab08_MattiasMarquez.Interfaces;

public interface IOrderDetailRepository
{
    Task<IEnumerable<object>> GetProductDetailsByOrderIdAsync(int orderId);
    Task<IEnumerable<object>> GetAllDetailsProjectedAsync();
}