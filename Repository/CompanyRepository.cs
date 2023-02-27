using Microsoft.EntityFrameworkCore;
using OMS.Interface;
using OMS.Data;
using OMS.Models;

namespace OMS.Repository
{
    public class CompanyRepository : ICompany
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Company> CreateData(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> DeleteData(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> EditData(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            var data = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
            return data;
        }

        public async Task<Company> GetByName(string? name)
        {
            var data = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyName == name);
            return data;
        }
    }
}
