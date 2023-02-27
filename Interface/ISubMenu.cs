using OMS.Models;

namespace OMS.Interface
{
    public interface ISubMenu
    {
        Task<IEnumerable<SubMenu>> GetAll();

        Task<SubMenu> CreateData(SubMenu subMenu);

        Task<SubMenu> GetById(int id);

        Task<SubMenu> EditData(SubMenu subMenu);

        Task<SubMenu> GetByName(string? name);

        Task<SubMenu> DeleteData(SubMenu subMenu);

        Task<SubMenu> DetailsData(int id);
    }
}
