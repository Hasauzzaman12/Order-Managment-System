using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateData(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteData(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public Task<Customer> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> EditData(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            var data = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            return data;
        }

        public async Task<Customer> GetByName(string? name)
        {
            var data = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerName == name);
            return data;
        }
    }
}
