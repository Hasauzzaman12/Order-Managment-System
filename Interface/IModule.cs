using OMS.Models;

namespace OMS.Interface
{
    public interface IModule
    {
        Task<IEnumerable<Module>> GetAll();

        Task<Module> CreateData(Module module);

        Task<Module> GetById(int id);

        Task<Module> EditData(Module module);

        Task<Module> GetByName(string? name);

        Task<Module> DeleteData(Module module);

        Task<IEnumerable<Module>> GetContextView();
    }
}
