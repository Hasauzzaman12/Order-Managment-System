using OMS.Models;

namespace OMS.Interface
{
    public interface IBuyer
    {
        Task<IEnumerable<Buyer>> GetAll();

        Task<Buyer> CreateData(Buyer buyer);

        Task<Buyer> GetById(int id);

        Task<Buyer> EditData(Buyer buyer);

        Task<Buyer> GetByName(string? name);

        Task<Buyer> DeleteData(Buyer buyer);

        Task<Buyer> DetailsData(int id);
    }
}
