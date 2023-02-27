using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class SalesPersonRepository : ISalesPerson
    {
        private readonly ApplicationDbContext _context;
        public SalesPersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SalesPerson> CreateData(SalesPerson salesPerson)
        {
            _context.SalesPersons.Add(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<SalesPerson> DeleteData(SalesPerson salesPerson)
        {
            _context.SalesPersons.Remove(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }

        public Task<SalesPerson> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SalesPerson> EditData(SalesPerson salesPerson)
        {
            _context.SalesPersons.Update(salesPerson);
            await _context.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<IEnumerable<SalesPerson>> GetAll()
        {
            return await _context.SalesPersons.ToListAsync();
        }

        public async Task<SalesPerson> GetById(int id)
        {
            var data = await _context.SalesPersons.FirstOrDefaultAsync(c => c.SalesPersonId == id);
            return data;
        }

        public Task<SalesPerson> GetByName(string? name)
        {
            throw new NotImplementedException();
        }
    }
}
