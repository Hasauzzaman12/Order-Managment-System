using Microsoft.EntityFrameworkCore;
using OMS.Interface;
using OMS.Data;
using OMS.Models;
using System.Xml.Linq;

namespace OMS.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateData(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> DeleteData(Department department)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> EditData(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            var data = await _context.Departments.FirstOrDefaultAsync(c => c.DepartmentId == id);
            return data;
        }

        public async Task<Department> GetByName(string? name)
        {
            var data = await _context.Departments.FirstOrDefaultAsync(c => c.DepartmentName == name);
            return data;
        }
    }
}
