using OMS.Models;

namespace OMS.Interface
{
    public interface IMainMenu
    {
        Task<IEnumerable<MainMenu>> GetAll();

        Task<MainMenu> CreateData(MainMenu mainMenu);

        Task<MainMenu> GetById(int id);

        Task<MainMenu> EditData(MainMenu mainMenu);

        Task<MainMenu> GetByName(string? name);

        Task<MainMenu> DeleteData(MainMenu mainMenu);

        Task<MainMenu> DetailsData(int id);
    }
}
