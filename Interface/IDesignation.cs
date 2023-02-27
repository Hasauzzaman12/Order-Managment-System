using OMS.Models;

namespace OMS.Interface
{
    public interface IDesignation
    {
        Task<IEnumerable<Designation>> GetAll();

        Task<Designation> CreateData(Designation designation);

        Task<Designation> GetById(int id);

        Task<Designation> EditData(Designation designation);

        Task<Designation> GetByName(string? name);

        Task<Designation> DeleteData(Designation designation);
    }
}
