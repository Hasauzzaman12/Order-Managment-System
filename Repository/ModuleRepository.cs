using Microsoft.EntityFrameworkCore;
using OMS.Interface;
using OMS.Data;
using OMS.Models;

namespace OMS.Repository
{
    public class ModuleRepository : IModule
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Module> CreateData(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<Module> DeleteData(Module module)
        {
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<Module> EditData(Module module)
        {
            _context.Modules.Update(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<IEnumerable<Module>> GetAll()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<Module> GetById(int id)
        {
            var data = await _context.Modules.FirstOrDefaultAsync(c => c.ModuleId == id);
            return data;
        }

        public async Task<Module> GetByName(string? name)
        {
            var data = await _context.Modules.FirstOrDefaultAsync(c => c.ModuleName == name);
            return data;
        }

        public async Task<IEnumerable<Module>> GetContextView()
        {
            return await _context.Modules.ToListAsync();
        }
    }
}
