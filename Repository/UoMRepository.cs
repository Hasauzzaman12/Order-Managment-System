using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;

namespace OMS.Repository
{
    public class UoMRepository : IUoM
    {
        private readonly ApplicationDbContext _context;

        public UoMRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Models.UoM> CreateData(Models.UoM uoM)
        {
            _context.UoMs.Add(uoM);
            await _context.SaveChangesAsync();
            return uoM;
        }

        public async Task<Models.UoM> DeleteData(Models.UoM uoM)
        {
            _context.UoMs.Remove(uoM);
            await _context.SaveChangesAsync();
            return uoM;
        }

        public async Task<Models.UoM> EditData(Models.UoM uoM)
        {
            _context.UoMs.Update(uoM);
            await _context.SaveChangesAsync();
            return uoM;
        }

        public async Task<IEnumerable<Models.UoM>> GetAll()
        {
            return await _context.UoMs.ToListAsync();
        }

        public async Task<Models.UoM> GetById(int id)
        {
            var data = await _context.UoMs.FirstOrDefaultAsync(c => c.UoMId == id);
            return data;
        }

        public async Task<Models.UoM> GetByName(string? name)
        {
            var data = await _context.UoMs.FirstOrDefaultAsync(c => c.UoMName == name);
            return data;
        }
    }
}
