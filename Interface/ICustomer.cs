using OMS.Models;

namespace OMS.Interface
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<Customer> CreateData(Customer customer);

        Task<Customer> GetById(int id);

        Task<Customer> EditData(Customer customer);

        Task<Customer> GetByName(string? name);

        Task<Customer> DeleteData(Customer customer);

        Task<Customer> DetailsData(int id);
    }
}
