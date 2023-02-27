using OMS.Models;

namespace OMS.Interface
{
    public interface ICsPerson
    {
        Task<IEnumerable<CsPerson>> GetAll();

        Task<CsPerson> CreateData(CsPerson csPerson);

        Task<CsPerson> GetById(int id);

        Task<CsPerson> EditData(CsPerson csPerson);

        Task<CsPerson> GetByName(string? name);

        Task<CsPerson> DeleteData(CsPerson csPerson);

        Task<CsPerson> DetailsData(int id);
    }
}
