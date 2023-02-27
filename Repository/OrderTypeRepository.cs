using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class OrderTypeRepository : IOrderType
    {
        private readonly ApplicationDbContext _context;
        public OrderTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderType> CreateData(OrderType orderType)
        {
            _context.OrderTypes.Add(orderType);
            await _context.SaveChangesAsync();
            return orderType;
        }

        public async Task<OrderType> DeleteData(OrderType orderType)
        {
            _context.OrderTypes.Remove(orderType);
            await _context.SaveChangesAsync();
            return orderType;
        }

        public Task<OrderType> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderType> EditData(OrderType orderType)
        {
            _context.OrderTypes.Update(orderType);
            await _context.SaveChangesAsync();
            return orderType;
        }

        public async Task<IEnumerable<OrderType>> GetAll()
        {
            return await _context.OrderTypes.ToListAsync();
        }

        public async Task<OrderType> GetById(int id)
        {
            var data = await _context.OrderTypes.FirstOrDefaultAsync(c => c.OrderTypeId == id);
            return data;
        }

        public async Task<OrderType> GetByName(string? name)
        {
            var data = await _context.OrderTypes.FirstOrDefaultAsync(c => c.OrderTypeName == name);
            return data;
        }
    }
}
