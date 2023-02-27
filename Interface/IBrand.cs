using OMS.Models;

namespace OMS.Interface
{
    public interface IBrand
    {
        Task<IEnumerable<Brand>> GetAll();

        Task<Brand> CreateData(Brand brand);

        Task<Brand> GetById(int id);

        Task<Brand> EditData(Brand brand);

        Task<Brand> GetByName(string? name);

        Task<Brand> DeleteData(Brand brand);

        Task<Brand> DetailsData(int id);
    }
}
