using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class MenuRepository : IMenu
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu> CreateData(Menu menu)
        {
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<Menu> DeleteData(Menu menu)
        {
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<Menu> DetailsData(int id)
        {
            var data = await _context.Menus.Include(c => c.Module).FirstOrDefaultAsync(c => c.MenuId == id);

            return data;
        }

        public async Task<Menu> EditData(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            var dd = new Module();
            return await _context.Menus
                .Include(x => x.Module)
                .Where(c => c.IsActive == true)
                .Where( c => c.ModuleId ==c.Module.ModuleId)
                .ToListAsync();
        }

        public async Task<Menu> GetById(int id)
        {
            var data = await _context.Menus.FirstOrDefaultAsync(c => c.MenuId == id);
            return data;
        }

        public async Task<Menu> GetByName(string? name)
        {
            var data = await _context.Menus.FirstOrDefaultAsync(c => c.MenuName == name);
            return data;
        }

        public Task<IEnumerable<Menu>> MenuList()
        {
            throw new NotImplementedException();
        }
    }
}
