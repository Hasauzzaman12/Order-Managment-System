using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMS.Interface;
using OMS.Data;
using OMS.Models;

namespace OMS.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateData(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteData(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DetailsData(int id)
        {
            var data = await _context.Employees.Include(c => c.Company).Include(c => c.Department).Include(c => c.Designation).FirstOrDefaultAsync(c => c.EmployeeId == id);
            
            return data;
        }

        public async Task<Employee> EditData(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var data = await _context.Employees.Include(c => c.Company).Include(c => c.Department).Include(c => c.Designation).ToListAsync();

            return data;
        }

        public async Task<Employee> GetById(int id)
        {
            var data = await _context.Employees.FirstOrDefaultAsync(c => c.EmployeeId == id);
            return data;
        }

        public async Task<Employee> GetByName(string? name)
        {
            var data = await _context.Employees.FirstOrDefaultAsync(c => c.EmpIdCardNo == name);
            return data;
        }
    }
}
