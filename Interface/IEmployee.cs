using OMS.Models;

namespace OMS.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> CreateData(Employee employee);

        Task<Employee> GetById(int id);

        Task<Employee> EditData(Employee employee);

        Task<Employee> GetByName(string? name);

        Task<Employee> DeleteData(Employee employee);

        Task<Employee> DetailsData(int id);
    }
}
