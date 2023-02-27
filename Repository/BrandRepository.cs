using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class BrandRepository : IBrand
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> CreateData(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<Brand> DeleteData(Brand brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public Task<Brand> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Brand> EditData(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return brand;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetById(int id)
        {
            var data = await _context.Brands.FirstOrDefaultAsync(c => c.BrandId == id);
            return data;
        }

        public async Task<Brand> GetByName(string? name)
        {
            var data = await _context.Brands.FirstOrDefaultAsync(c => c.BrandName == name);
            return data;
        }
    }
}
