using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class SubMenuRepository : ISubMenu
    {
        private readonly ApplicationDbContext _context;

        public SubMenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SubMenu> CreateData(SubMenu subMenu)
        {
            _context.SubMenus.Add(subMenu);
            await _context.SaveChangesAsync();
            return subMenu;
        }

        public async Task<SubMenu> DeleteData(SubMenu subMenu)
        {
            _context.SubMenus.Remove(subMenu);
            await _context.SaveChangesAsync();
            return subMenu;
        }

        public async Task<SubMenu> DetailsData(int id)
        {
            var data = await _context.SubMenus.Include(c => c.MainMenu).FirstOrDefaultAsync(c => c.SubMenuId == id);

            return data;
        }

        public async Task<SubMenu> EditData(SubMenu subMenu)
        {
            _context.SubMenus.Update(subMenu);
            await _context.SaveChangesAsync();
            return subMenu;
        }

        public async Task<IEnumerable<SubMenu>> GetAll()
        {
            var data = await _context.SubMenus.Include(c => c.MainMenu).ToListAsync();

            return data;
        }

        public async Task<SubMenu> GetById(int id)
        {
            var data = await _context.SubMenus.FirstOrDefaultAsync(c => c.SubMenuId == id);
            return data;
        }

        public async Task<SubMenu> GetByName(string? name)
        {
            var data = await _context.SubMenus.FirstOrDefaultAsync(c => c.SubMenuName == name);
            return data;
        }
    }
}
