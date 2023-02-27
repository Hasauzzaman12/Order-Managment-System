using Microsoft.EntityFrameworkCore;
using OMS.Data;
using OMS.Interface;
using OMS.Models;

namespace OMS.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateData(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteData(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public Task<Product> DetailsData(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> EditData(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(c => c.ProductId == id);
            return data;
        }

        public async Task<Product> GetByName(string? name)
        {
            var data = await _context.Products.FirstOrDefaultAsync(c => c.ProductName == name);
            return data;
        }
    }
}
