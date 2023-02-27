using OMS.Models;

namespace OMS.Interface
{
    public interface IUoM
    {
        Task<IEnumerable<UoM>> GetAll();

        Task<UoM> CreateData(UoM uoM);

        Task<UoM> GetById(int id);

        Task<UoM> EditData(UoM uoM);

        Task<UoM> GetByName(string? name);

        Task<UoM> DeleteData(UoM uoM);
    }
}
