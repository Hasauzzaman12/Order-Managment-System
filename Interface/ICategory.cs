using OMS.Models;

namespace OMS.Interface
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAll();

        Task<Category> CreateData(Category category);

        Task<Category> GetById(int id);

        Task<Category> EditData(Category category);

        Task<Category> GetByName(string? name);

        Task<Category> DeleteData(Category category);

        Task<Category> DetailsData(int id);
    }
}
