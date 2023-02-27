using OMS.Models;

namespace OMS.Interface
{
    public interface IDepartment
    {
        Task <IEnumerable<Department>> GetAll();

        Task<Department> CreateData (Department department);
        
        Task<Department> GetById (int id);
        
        Task<Department> EditData (Department department);
        
        Task<Department> GetByName(string? name);

        Task<Department> DeleteData(Department department);
    }
}
