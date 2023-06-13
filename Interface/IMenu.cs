using OMS.Models;

namespace OMS.Interface
{
    public interface IMenu
    {
        Task<IEnumerable<Menu>> GetAll();
        Task<IEnumerable<Menu>> MenuList();

        Task<Menu> CreateData(Menu menu);

        Task<Menu> GetById(int id);

        Task<Menu> EditData(Menu menu);

        Task<Menu> GetByName(string? name);

        Task<Menu> DeleteData(Menu menu);

        Task<Menu> DetailsData(int id);
    }
}
