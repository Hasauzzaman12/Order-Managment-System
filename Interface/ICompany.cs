using OMS.Models;

namespace OMS.Interface
{
    public interface ICompany
    {
        Task<IEnumerable<Company>> GetAll();

        Task<Company> CreateData(Company company);

        Task<Company> GetById(int id); //for showing details

        Task<Company> EditData(Company company);

        Task<Company> GetByName(string? name); //for checking duplicate data <>>>

        Task<Company> DeleteData(Company company);
    }
}
