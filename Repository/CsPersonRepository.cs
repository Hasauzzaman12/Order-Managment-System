using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class CsPersonRepository : ICsPerson
    {
        private readonly ApplicationDbContext _context;
        public CsPersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CsPerson> CreateData(CsPerson csPerson)
        {
            _context.CsPersons.Add(csPerson);
            await _context.SaveChangesAsync();
            return csPerson;
        }

        public async Task<CsPerson> DeleteData(CsPerson csPerson)
        {
            _context.CsPersons.Remove(csPerson);
            await _context.SaveChangesAsync();
            return csPerson;
        }

        public Task<CsPerson> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CsPerson> EditData(CsPerson csPerson)
        {
            _context.CsPersons.Update(csPerson);
            await _context.SaveChangesAsync();
            return csPerson;
        }

        public async Task<IEnumerable<CsPerson>> GetAll()
        {
            return await _context.CsPersons.ToListAsync();
        }

        public async Task<CsPerson> GetById(int id)
        {
            var data = await _context.CsPersons.FirstOrDefaultAsync(c => c.CsPersonId == id);
            return data;
        }

        public async Task<CsPerson> GetByName(string? name)
        {
            var data = await _context.CsPersons.FirstOrDefaultAsync(c => c.CsPersonName == name);
            return data;
        }
    }
}
