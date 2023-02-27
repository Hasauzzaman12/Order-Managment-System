using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;
using System.Drawing.Drawing2D;

namespace OMS.Repository
{
    public class BuyerRepository : IBuyer
    {
        private readonly ApplicationDbContext _context;
        public BuyerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Buyer> CreateData(Buyer buyer)
        {
            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();
            return buyer;
        }

        public async Task<Buyer> DeleteData(Buyer buyer)
        {
            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();
            return buyer;
        }

        public Task<Buyer> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Buyer> EditData(Buyer buyer)
        {
            _context.Buyers.Update(buyer);
            await _context.SaveChangesAsync();
            return buyer;
        }

        public async Task<IEnumerable<Buyer>> GetAll()
        {
            return await _context.Buyers.ToListAsync();
        }

        public async Task<Buyer> GetById(int id)
        {
            var data = await _context.Buyers.FirstOrDefaultAsync(c => c.BuyerId == id);
            return data;
        }

        public async Task<Buyer> GetByName(string? name)
        {
            var data = await _context.Buyers.FirstOrDefaultAsync(c => c.BuyerName == name);
            return data;
        }
    }
}
