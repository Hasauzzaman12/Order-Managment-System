using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class OrderMasterRepository : IOrderMaster
    {
        private readonly ApplicationDbContext _context;
        public OrderMasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderMaster> CreateData(OrderMaster orderMaster)
        {
            _context.OrderMasters.Add(orderMaster);
            await _context.SaveChangesAsync();
            return orderMaster;
        }

        public async Task<OrderMaster> DeleteData(OrderMaster orderMaster)
        {
            _context.OrderMasters.Remove(orderMaster);
            await _context.SaveChangesAsync();
            return orderMaster;
        }

        public Task<OrderMaster> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderMaster> EditData(OrderMaster orderMaster)
        {
            _context.OrderMasters.Update(orderMaster);
            await _context.SaveChangesAsync();
            return orderMaster;
        }

        public async Task<IEnumerable<OrderMaster>> GetAll()
        {
            return await _context.OrderMasters.ToListAsync();
        }

        public async Task<OrderMaster> GetById(int id)
        {
            var data = await _context.OrderMasters.FirstOrDefaultAsync(c => c.OrderMasterId == id);
            return data;
        }

        public Task<OrderMaster> GetByName(string? name)
        {
            throw new NotImplementedException();
        }
    }
}
