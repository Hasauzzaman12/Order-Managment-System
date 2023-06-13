using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class MainMenuRepository : IMainMenu
    {
        private readonly ApplicationDbContext _context;

        public MainMenuRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MainMenu> CreateData(MainMenu mainMenu)
        {
            _context.MainMenus.Add(mainMenu);
            await _context.SaveChangesAsync();
            return mainMenu;
        }

        public async Task<MainMenu> DeleteData(MainMenu mainMenu)
        {
            _context.MainMenus.Remove(mainMenu);
            await _context.SaveChangesAsync();
            return mainMenu;
        }

        public async Task<MainMenu> DetailsData(int id)
        {
            var data = await _context.MainMenus.Include(c => c.Module).FirstOrDefaultAsync(c => c.MainMenuId == id);

            return data;
        }

        public async Task<MainMenu> EditData(MainMenu mainMenu)
        {
            _context.MainMenus.Update(mainMenu);
            await _context.SaveChangesAsync();
            return mainMenu;
        }

        public async Task<IEnumerable<MainMenu>> GetAll()
        {
            var data = await _context.MainMenus.Include(c => c.Module).Include(c => c.SubMenus).Where(c=>c.IsActive==true).ToListAsync();

            return data;
        }

        public async Task<MainMenu> GetById(int id)
        {
            var data = await _context.MainMenus.FirstOrDefaultAsync(c => c.MainMenuId == id);
            return data;
        }

        public async Task<MainMenu> GetByName(string? name)
        {
            var data = await _context.MainMenus.FirstOrDefaultAsync(c => c.MainMenuName == name);
            return data;
        }

        public async Task<IEnumerable<MainMenu>> MenuList()
        {
            var data = await _context.MainMenus
                .Include(c => c.Module)
                .Include(c => c.SubMenus)
                .ToListAsync();

            return data;
        }
    }
}
