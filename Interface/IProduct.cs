using OMS.Models;

namespace OMS.Interface
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> CreateData(Product product);

        Task<Product> GetById(int id);

        Task<Product> EditData(Product product);

        Task<Product> GetByName(string? name);

        Task<Product> DeleteData(Product product);

        Task<Product> DetailsData(int id);
    }
}
