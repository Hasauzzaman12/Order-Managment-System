using OMS.Models;

namespace OMS.Interface
{
    public interface IOrderDetails
    {
        Task<IEnumerable<OrderDetails>> GetAll();

        Task<OrderDetails> CreateData(OrderDetails orderDetails);

        Task<OrderDetails> GetById(int id);

        Task<OrderDetails> EditData(OrderDetails orderDetails);

        Task<OrderDetails> GetByName(string? name);

        Task<OrderDetails> DeleteData(OrderDetails orderDetails);

        Task<OrderDetails> DetailsData(int id);
    }
}
