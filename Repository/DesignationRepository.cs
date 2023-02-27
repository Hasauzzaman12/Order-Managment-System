using Microsoft.EntityFrameworkCore;
using OMS.Interface;
using OMS.Data;
using OMS.Models;

namespace OMS.Repository
{
    public class DesignationRepository : IDesignation
    {
        private readonly ApplicationDbContext _context;

        public DesignationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Designation> CreateData(Designation designation)
        {
            _context.Designations.Add(designation);
            await _context.SaveChangesAsync();
            return designation;
        }

        public async Task<Designation> DeleteData(Designation designation)
        {
            _context.Designations.Remove(designation);
            await _context.SaveChangesAsync();
            return designation;
        }

        public async Task<Designation> EditData(Designation designation)
        {
            _context.Designations.Update(designation);
            await _context.SaveChangesAsync();
            return designation;
        }

        public async Task<IEnumerable<Designation>> GetAll()
        {
            return await _context.Designations.ToListAsync();
        }

        public async Task<Designation> GetById(int id)
        {
            var data = await _context.Designations.FirstOrDefaultAsync(c => c.DesignationId == id);
            return data;
        }

        public async Task<Designation> GetByName(string? name)
        {
            var data = await _context.Designations.FirstOrDefaultAsync(c => c.DesignationName == name);
            return data;
        }
    }
}
