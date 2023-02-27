using OMS.Models;

namespace OMS.Interface
{
    public interface IOrderType
    {
        Task<IEnumerable<OrderType>> GetAll();

        Task<OrderType> CreateData(OrderType orderType);

        Task<OrderType> GetById(int id);

        Task<OrderType> EditData(OrderType orderType);

        Task<OrderType> GetByName(string? name);

        Task<OrderType> DeleteData(OrderType orderType);

        Task<OrderType> DetailsData(int id);
    }
}
