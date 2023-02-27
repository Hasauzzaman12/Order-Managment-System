using OMS.Models;

namespace OMS.Interface
{
    public interface ISalesPerson
    {
        Task<IEnumerable<SalesPerson>> GetAll();

        Task<SalesPerson> CreateData(SalesPerson salesPerson);

        Task<SalesPerson> GetById(int id);

        Task<SalesPerson> EditData(SalesPerson salesPerson);

        Task<SalesPerson> GetByName(string? name);

        Task<SalesPerson> DeleteData(SalesPerson salesPerson);

        Task<SalesPerson> DetailsData(int id);
    }
}
