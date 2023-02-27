using OMS.Models;

namespace OMS.Interface
{
    public interface IOrderMaster
    {
        Task<IEnumerable<OrderMaster>> GetAll();

        Task<OrderMaster> CreateData(OrderMaster orderMaster);

        Task<OrderMaster> GetById(int id);

        Task<OrderMaster> EditData(OrderMaster orderMaster);

        Task<OrderMaster> GetByName(string? name);

        Task<OrderMaster> DeleteData(OrderMaster orderMaster);

        Task<OrderMaster> DetailsData(int id);
    }
}
